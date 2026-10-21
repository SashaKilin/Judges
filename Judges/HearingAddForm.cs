using System.Data;
using Npgsql;

namespace Judges
{
    public partial class HearingAddForm : Form
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=pass;Database=postgres";
        private readonly object caseId;
        private readonly object courtId;
        private readonly object? hearingId;

        public HearingAddForm(object caseId, object courtId)
            : this(caseId, courtId, null)
        {
        }

        public HearingAddForm(object caseId, object courtId, object? hearingId)
        {
            InitializeComponent();
            this.caseId = caseId;
            this.courtId = courtId;
            this.hearingId = hearingId;
        }

        private void HearingAddForm_Load(object sender, EventArgs e)
        {
            if (hearingId != null)
            {
                Text = "Редактирование слушания";
                LoadHearing();
            }
            LoadParticipants();
        }

        private void LoadHearing()
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var command = new NpgsqlCommand("""
                    SELECT hearing_date, room_number, result_summary
                    FROM hearings
                    WHERE hearing_id = @hearing_id AND case_id = @case_id
                    """, connection);
                command.Parameters.AddWithValue("hearing_id", hearingId!);
                command.Parameters.AddWithValue("case_id", caseId);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    dateTimePickerHearingDate.Value = reader.GetDateTime(0);
                    textBoxRoom.Text = reader.GetString(1);
                    textBoxResult.Text = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить слушание: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadParticipants()
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var command = new NpgsqlCommand(
                    """
                    SELECT DISTINCT p.participant_id, p.full_name, p.type, p.phone, p.email,
                                    0 AS request_id, '' AS request_login
                    FROM participants p
                    JOIN account a ON a.participant_id = p.participant_id
                    WHERE a.court_id = @court_id
                    UNION ALL
                    SELECT NULL::integer AS participant_id,
                           'Заявка: ' || pr.login AS full_name,
                           'ожидает подтверждения' AS type,
                           '' AS phone,
                           '' AS email,
                           pr.request_id,
                           pr.login
                    FROM participant_requests pr
                    WHERE pr.court_id = @court_id AND pr.status = 'pending'
                    ORDER BY full_name
                    """,
                    connection);
                command.Parameters.AddWithValue("court_id", courtId);
                using var reader = command.ExecuteReader();
                var participants = new DataTable();
                participants.Load(reader);

                listBoxParticipants.DataSource = participants;
                listBoxParticipants.DisplayMember = "full_name";
                listBoxParticipants.ValueMember = "participant_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить участников: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxRoom.Text))
            {
                MessageBox.Show("Укажите номер зала.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var transaction = connection.BeginTransaction();

                using (var hearingCommand = new NpgsqlCommand(hearingId == null ? """
                    INSERT INTO hearings (case_id, hearing_date, room_number, result_summary)
                    VALUES (@case_id, @hearing_date, @room_number, @result_summary)
                    """ : """
                    UPDATE hearings
                    SET hearing_date = @hearing_date,
                        room_number = @room_number,
                        result_summary = @result_summary
                    WHERE hearing_id = @hearing_id AND case_id = @case_id
                    """, connection, transaction))
                {
                    hearingCommand.Parameters.AddWithValue("case_id", caseId);
                    hearingCommand.Parameters.AddWithValue("hearing_date", dateTimePickerHearingDate.Value);
                    hearingCommand.Parameters.AddWithValue("room_number", textBoxRoom.Text.Trim());
                    hearingCommand.Parameters.AddWithValue("result_summary", textBoxResult.Text.Trim());
                    if (hearingId != null)
                    {
                        hearingCommand.Parameters.AddWithValue("hearing_id", hearingId);
                    }
                    hearingCommand.ExecuteNonQuery();
                }

                if (hearingId == null)
                {
                    foreach (var selectedItem in listBoxParticipants.SelectedItems)
                    {
                        if (selectedItem is not DataRowView row)
                        {
                            continue;
                        }

                        var participantId = row["participant_id"];
                        if (participantId == DBNull.Value)
                        {
                            using var createParticipantCommand = new NpgsqlCommand("""
                            INSERT INTO participants (full_name, type, phone, email)
                            VALUES (@full_name, 'подсудимый', '', '')
                            RETURNING participant_id
                            """, connection, transaction);
                            createParticipantCommand.Parameters.AddWithValue("full_name", row["request_login"]);
                            participantId = createParticipantCommand.ExecuteScalar()!;

                            using var accountCommand = new NpgsqlCommand("""
                            UPDATE account
                            SET participant_id = @participant_id,
                                court_id = @court_id,
                                role_id = (SELECT role_id FROM court_staff_roles WHERE role_name = 'подсудимый')
                            WHERE login = @login
                            """, connection, transaction);
                            accountCommand.Parameters.AddWithValue("participant_id", participantId);
                            accountCommand.Parameters.AddWithValue("court_id", courtId);
                            accountCommand.Parameters.AddWithValue("login", row["request_login"]);
                            accountCommand.ExecuteNonQuery();

                            using var requestCommand = new NpgsqlCommand("""
                            UPDATE participant_requests
                            SET status = 'confirmed', participant_id = @participant_id
                            WHERE request_id = @request_id
                            """, connection, transaction);
                            requestCommand.Parameters.AddWithValue("participant_id", participantId);
                            requestCommand.Parameters.AddWithValue("request_id", row["request_id"]);
                            requestCommand.ExecuteNonQuery();
                        }

                        using var participantCommand = new NpgsqlCommand("""
                        INSERT INTO case_participants (case_id, participant_id)
                        SELECT @case_id, @participant_id
                        WHERE NOT EXISTS (
                            SELECT 1 FROM case_participants
                            WHERE case_id = @case_id AND participant_id = @participant_id
                        )
                        """, connection, transaction);
                        participantCommand.Parameters.AddWithValue("case_id", caseId);
                        participantCommand.Parameters.AddWithValue("participant_id", participantId);
                        participantCommand.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить слушание: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
