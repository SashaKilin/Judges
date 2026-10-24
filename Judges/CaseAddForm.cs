using System.Data;
using Npgsql;

namespace Judges
{
    public partial class CaseAddForm : Form
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=pass;Database=postgres";
        private readonly object courtId;

        public CaseAddForm(object courtId)
        {
            InitializeComponent();
            this.courtId = courtId;
        }

        public string CaseNumber => textBoxCaseNumber.Text.Trim();
        public string Title => textBoxTitle.Text.Trim();
        public string Category => textBoxCategory.Text.Trim();
        public string Status => textBoxStatus.Text.Trim();
        public DateTime FillingDate => dateTimePickerFillingDate.Value.Date;

        private object? SelectedJudgeId =>
            (comboBoxJudge.SelectedItem as DataRowView)?["judge_id"];

        private object? SelectedDefendantParticipantId =>
            (comboBoxDefendant.SelectedItem as DataRowView)?["participant_id"];

        private void CaseAddForm_Load(object sender, EventArgs e)
        {
            LoadJudges();
            LoadDefendants();
        }

        private void UpdateSaveAvailability()
        {
            buttonSave.Enabled = comboBoxJudge.Items.Count > 0 && comboBoxDefendant.Items.Count > 0;
        }

        private void LoadJudges()
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand(
                    "SELECT judge_id, full_name FROM judges WHERE court_id = @court_id ORDER BY full_name",
                    connection);
                command.Parameters.AddWithValue("court_id", courtId);

                using var reader = command.ExecuteReader();
                var judges = new DataTable();
                judges.Load(reader);

                comboBoxJudge.DataSource = judges;
                comboBoxJudge.DisplayMember = "full_name";
                comboBoxJudge.ValueMember = "judge_id";
                labelNoJudges.Visible = judges.Rows.Count == 0;
                UpdateSaveAvailability();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить судей: {ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                buttonSave.Enabled = false;
            }
        }

        private void LoadDefendants()
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand("""
                    SELECT a.participant_id,
                           COALESCE(p.full_name, a.login) AS full_name,
                           a.login
                    FROM account a
                    LEFT JOIN participants p ON p.participant_id = a.participant_id
                    ORDER BY COALESCE(p.full_name, a.login), a.login
                    """, connection);

                using var reader = command.ExecuteReader();
                var defendants = new DataTable();
                defendants.Load(reader);

                comboBoxDefendant.DataSource = defendants;
                comboBoxDefendant.DisplayMember = "full_name";
                comboBoxDefendant.ValueMember = "participant_id";
                UpdateSaveAvailability();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить подсудимых: {ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                buttonSave.Enabled = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (SelectedJudgeId == null ||
                SelectedDefendantParticipantId == null ||
                string.IsNullOrWhiteSpace(CaseNumber) ||
                string.IsNullOrWhiteSpace(Title) ||
                string.IsNullOrWhiteSpace(Category) ||
                string.IsNullOrWhiteSpace(Status))
            {
                MessageBox.Show(
                    "Заполните все поля и выберите судью и подсудимого.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                var selectedLogin = (comboBoxDefendant.SelectedItem as DataRowView)?["login"]?.ToString();
                if (string.IsNullOrWhiteSpace(selectedLogin))
                {
                    throw new InvalidOperationException("Не удалось определить аккаунт подсудимого.");
                }

                object? defendantParticipantId = SelectedDefendantParticipantId;
                if (defendantParticipantId == null || defendantParticipantId == DBNull.Value)
                {
                    using var createParticipantCommand = new NpgsqlCommand("""
                        INSERT INTO participants (full_name, type, phone, email)
                        VALUES (@full_name, 'подсудимый', '', '')
                        RETURNING participant_id
                        """, connection);
                    createParticipantCommand.Parameters.AddWithValue("full_name", selectedLogin);
                    defendantParticipantId = createParticipantCommand.ExecuteScalar();

                    using var updateAccountCommand = new NpgsqlCommand("""
                        UPDATE account
                        SET participant_id = @participant_id,
                            role_id = (SELECT role_id FROM court_staff_roles WHERE role_name = 'подсудимый')
                        WHERE login = @login
                        """, connection);
                    updateAccountCommand.Parameters.AddWithValue("participant_id", defendantParticipantId);
                    updateAccountCommand.Parameters.AddWithValue("login", selectedLogin);
                    updateAccountCommand.ExecuteNonQuery();
                }

                using var command = new NpgsqlCommand("""
                    INSERT INTO cases
                        (case_number, judge_id, court_id, title, category, status, filling_date)
                    VALUES
                        (@case_number, @judge_id, @court_id, @title, @category, @status, @filling_date)
                    RETURNING case_id
                    """, connection);
                command.Parameters.AddWithValue("case_number", CaseNumber);
                command.Parameters.AddWithValue("judge_id", SelectedJudgeId);
                command.Parameters.AddWithValue("court_id", courtId);
                command.Parameters.AddWithValue("title", Title);
                command.Parameters.AddWithValue("category", Category);
                command.Parameters.AddWithValue("status", Status);
                command.Parameters.AddWithValue("filling_date", FillingDate);
                var caseId = command.ExecuteScalar();

                if (caseId != null && caseId != DBNull.Value)
                {
                    using var participantCommand = new NpgsqlCommand("""
                        INSERT INTO case_participants (case_id, participant_id)
                        SELECT @case_id, @participant_id
                        WHERE NOT EXISTS (
                            SELECT 1 FROM case_participants
                            WHERE case_id = @case_id AND participant_id = @participant_id
                        )
                        """, connection);
                    participantCommand.Parameters.AddWithValue("case_id", caseId);
                    participantCommand.Parameters.AddWithValue("participant_id", defendantParticipantId);
                    participantCommand.ExecuteNonQuery();
                }

                if (caseId != null && caseId != DBNull.Value &&
                    MessageBox.Show(
                        "Добавить первое слушание сейчас?",
                        "Слушание",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using var hearingForm = new HearingAddForm(caseId, courtId);
                    hearingForm.ShowDialog(this);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось добавить дело: {ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
