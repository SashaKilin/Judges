using System.Data;
using Npgsql;

namespace Judges
{
    public partial class MainForm : Form
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=pass;Database=postgres";
        private string user1;
        private string pass2;
        private string roleName;
        private bool canEdit;
        private object? selectedCourtId;

        public MainForm(string user, string pass, string roleName)
        {
            InitializeComponent();

            this.user1 = user;
            this.pass2 = pass;
            this.roleName = roleName;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            canEdit = string.Equals(roleName, "судья", StringComparison.OrdinalIgnoreCase);
            label1.Text = $"Добро пожаловать, {user1}! Роль: {roleName}";

            labelName.Visible = canEdit;
            textBoxName.Visible = canEdit;
            labelAddress.Visible = canEdit;
            textBoxAddress.Visible = canEdit;
            labelType.Visible = canEdit;
            textBoxType.Visible = canEdit;
            buttonAddCourt.Visible = canEdit;
            labelParticipantId.Visible = !canEdit;
            textBoxParticipantId.Visible = !canEdit;
            buttonLinkParticipant.Visible = !canEdit;
            buttonLinkParticipant.Enabled = !canEdit && selectedCourtId != null;
            buttonOpenCases.Location = canEdit ? new Point(1170, 220) : new Point(720, 166);
            textBoxParticipantId.ReadOnly = true;
            LoadParticipantLinkStatus();
            LoadCourts();
        }

        private void buttonLinkParticipant_Click(object sender, EventArgs e)
        {
            if (selectedCourtId == null)
            {
                MessageBox.Show("Сначала выберите суд.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var command = new NpgsqlCommand("""
                    INSERT INTO participant_requests (login, court_id)
                    SELECT @login, @court_id
                    WHERE NOT EXISTS (
                        SELECT 1
                        FROM participant_requests
                        WHERE login = @login AND court_id = @court_id AND status = 'pending'
                    )
                    """, connection);
                command.Parameters.AddWithValue("login", user1);
                command.Parameters.AddWithValue("court_id", selectedCourtId!);

                if (command.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Заявка на этот суд уже ожидает подтверждения.", "Привязка к суду", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                buttonLinkParticipant.Enabled = false;
                textBoxParticipantId.Text = "Заявка ожидает подтверждения судьёй";
                MessageBox.Show("Заявка отправлена. После добавления в слушание участник и participant_id будут созданы автоматически.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить привязку: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadParticipantLinkStatus()
        {
            if (canEdit)
            {
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var command = new NpgsqlCommand("""
                    SELECT a.participant_id,
                           EXISTS (
                               SELECT 1 FROM participant_requests pr
                               WHERE pr.login = a.login AND pr.status = 'pending'
                           ) AS has_pending_request
                    FROM account a
                    WHERE a.login = @login
                    """, connection);
                command.Parameters.AddWithValue("login", user1);
                using var reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    return;
                }

                if (!reader.IsDBNull(0))
                {
                    textBoxParticipantId.Text = $"Ваш participant_id: {reader.GetInt32(0)}";
                    buttonLinkParticipant.Visible = false;
                }
                else if (reader.GetBoolean(1))
                {
                    textBoxParticipantId.Text = "Заявка ожидает подтверждения судьёй";
                    buttonLinkParticipant.Enabled = false;
                }
                else
                {
                    textBoxParticipantId.Text = "Сначала выберите суд";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить статус заявки: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourts()
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand(
                    "SELECT court_id, name, address, type FROM courts ORDER BY name", connection);
                using var reader = command.ExecuteReader();

                var courts = new DataTable();
                courts.Load(reader);
                dataGridViewCourts.DataSource = courts;

                if (dataGridViewCourts.Columns.Count >= 4)
                {
                    dataGridViewCourts.Columns[0].Visible = false;
                    dataGridViewCourts.Columns[1].HeaderText = "Название";
                    dataGridViewCourts.Columns[2].HeaderText = "Адрес";
                    dataGridViewCourts.Columns[3].HeaderText = "Тип суда";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить список судов: {ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCourts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewCourts.Rows.Count)
            {
                return;
            }

            var value = dataGridViewCourts.Rows[e.RowIndex].Cells[0].Value;
            if (value == null || value == DBNull.Value)
            {
                return;
            }

            selectedCourtId = value;
            var courtName = dataGridViewCourts.Rows[e.RowIndex].Cells[1].Value?.ToString();
            labelJudges.Text = $"Судьи суда: {courtName}";
            buttonAddJudge.Enabled = canEdit;
            buttonOpenCases.Enabled = true;
            buttonLinkParticipant.Enabled = !canEdit;
            LoadJudges();
        }

        private void dataGridViewCourts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewCourts.Rows.Count)
            {
                return;
            }

            var courtId = dataGridViewCourts.Rows[e.RowIndex].Cells[0].Value;
            var courtName = dataGridViewCourts.Rows[e.RowIndex].Cells[1].Value?.ToString();

            if (courtId == null || courtId == DBNull.Value || string.IsNullOrWhiteSpace(courtName))
            {
                return;
            }

            using var casesForm = new CasesForm(courtId, courtName, user1, roleName);
            casesForm.ShowDialog(this);
        }

        private void buttonOpenCases_Click(object sender, EventArgs e)
        {
            if (selectedCourtId == null)
            {
                MessageBox.Show("Сначала выберите суд.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridViewCourts.CurrentRow;
            var courtName = row?.Cells[1].Value?.ToString();
            if (string.IsNullOrWhiteSpace(courtName))
            {
                return;
            }

            using var casesForm = new CasesForm(selectedCourtId, courtName, user1, roleName);
            casesForm.ShowDialog(this);
        }

        private void LoadJudges()
        {
            if (selectedCourtId == null)
            {
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand(
                    "SELECT judge_id, full_name, badge_number FROM judges WHERE court_id = @court_id ORDER BY full_name",
                    connection);
                command.Parameters.AddWithValue("court_id", selectedCourtId);

                using var reader = command.ExecuteReader();
                var judges = new DataTable();
                judges.Load(reader);
                dataGridViewJudges.DataSource = judges;

                if (dataGridViewJudges.Columns.Count >= 3)
                {
                    dataGridViewJudges.Columns[0].Visible = false;
                    dataGridViewJudges.Columns[1].HeaderText = "ФИО";
                    dataGridViewJudges.Columns[2].HeaderText = "Табельный номер";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить список судей: {ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonAddJudge_Click(object sender, EventArgs e)
        {
            if (!canEdit || selectedCourtId == null)
            {
                return;
            }

            using var judgeAddForm = new JudgeAddForm();
            if (judgeAddForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand(
                    "INSERT INTO judges (court_id, full_name, badge_number) VALUES (@court_id, @full_name, @badge_number)",
                    connection);
                command.Parameters.AddWithValue("court_id", selectedCourtId);
                command.Parameters.AddWithValue("full_name", judgeAddForm.FullName);
                command.Parameters.AddWithValue("badge_number", judgeAddForm.BadgeNumber);
                command.ExecuteNonQuery();

                LoadJudges();
                MessageBox.Show("Судья успешно добавлен.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось добавить судью: {ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonAddCourt_Click(object sender, EventArgs e)
        {
            if (!canEdit)
            {
                return;
            }

            var name = textBoxName.Text.Trim();
            var address = textBoxAddress.Text.Trim();
            var type = textBoxType.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show(
                    "Заполните название, адрес и тип суда.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand(
                    "INSERT INTO courts (name, address, type) VALUES (@name, @address, @type)",
                    connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("address", address);
                command.Parameters.AddWithValue("type", type);
                command.ExecuteNonQuery();

                textBoxName.Clear();
                textBoxAddress.Clear();
                textBoxType.Clear();
                LoadCourts();

                MessageBox.Show("Суд успешно добавлен.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось добавить суд: {ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
