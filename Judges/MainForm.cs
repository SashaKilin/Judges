using System.Data;
using Npgsql;
using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    public partial class MainForm : MaterialForm
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=pass;Database=postgres";
        private string user1;
        private string pass2;
        private string roleName;
        private readonly int accessLevel;
        private bool canEdit;
        private bool canViewCases;
        private object? selectedCourtId;

        public MainForm(string user, string pass, string roleName)
        {
            InitializeComponent();

            ApplyDarkGridTheme(dataGridViewCourts);
            ApplyDarkGridTheme(dataGridViewJudges);

            this.user1 = user;
            this.pass2 = pass;
            this.roleName = roleName;
            accessLevel = GetAccessLevel(roleName);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);
        }

        private static void ApplyDarkGridTheme(DataGridView grid)
        {
            grid.BackgroundColor = Color.FromArgb(33, 33, 33);
            grid.ForeColor = Color.FromArgb(245, 245, 245);
            grid.GridColor = Color.FromArgb(61, 61, 61);
            grid.BorderStyle = BorderStyle.None;
            grid.RowHeadersVisible = false;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            grid.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(245, 245, 245);
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 123, 216);
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(43, 43, 43),
                ForeColor = Color.FromArgb(245, 245, 245),
                SelectionBackColor = Color.FromArgb(73, 123, 216),
                SelectionForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            };
            grid.ColumnHeadersDefaultCellStyle = headerStyle;

            var cellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(33, 33, 33),
                ForeColor = Color.FromArgb(245, 245, 245),
                SelectionBackColor = Color.FromArgb(73, 123, 216),
                SelectionForeColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };
            grid.DefaultCellStyle = cellStyle;
        }

        private static int GetAccessLevel(string roleName)
        {
            if (string.Equals(roleName, "гость", StringComparison.OrdinalIgnoreCase))
            {
                return 1;
            }

            if (string.Equals(roleName, "подсудимый", StringComparison.OrdinalIgnoreCase))
            {
                return 2;
            }

            if (string.Equals(roleName, "судья", StringComparison.OrdinalIgnoreCase))
            {
                return 3;
            }

            return 1;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            SetLoadingState(true);
            try
            {
                canEdit = accessLevel == 3;
                canViewCases = accessLevel > 1;
                label1.Text = $"Добро пожаловать, {user1}! Роль: {roleName}";

                labelName.Visible = canEdit;
                textBoxName.Visible = canEdit;
                labelAddress.Visible = canEdit;
                textBoxAddress.Visible = canEdit;
                labelType.Visible = canEdit;
                textBoxType.Visible = canEdit;
                buttonAddCourt.Visible = canEdit;
                buttonOpenCases.Visible = canViewCases;
                buttonOpenCases.Enabled = canViewCases;
                await LoadCourtsAsync();
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            progressBarLoading.Visible = isLoading;
            UseWaitCursor = isLoading;
            Application.DoEvents();
        }

        private async Task LoadCourtsAsync()
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                await connection.OpenAsync();

                using var command = accessLevel == 2
                    ? new NpgsqlCommand("""
                        SELECT DISTINCT c.court_id, c.name, c.address, c.type
                        FROM courts c
                        JOIN cases cs ON cs.court_id = c.court_id
                        JOIN case_participants cp ON cp.case_id = cs.case_id
                        JOIN account a ON a.participant_id = cp.participant_id
                        WHERE a.login = @login
                        ORDER BY c.name
                        """, connection)
                    : new NpgsqlCommand("SELECT court_id, name, address, type FROM courts ORDER BY name", connection);
                if (accessLevel == 2)
                {
                    command.Parameters.AddWithValue("login", user1);
                }
                using var reader = await command.ExecuteReaderAsync();

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
            buttonOpenCases.Enabled = canViewCases;
            LoadJudges();
        }

        private void dataGridViewCourts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewCourts.Rows.Count)
            {
                return;
            }

            if (accessLevel == 1)
            {
                MessageBox.Show("Гость не имеет доступа к делам и слушаниям.", "Доступ ограничен", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (accessLevel == 1)
            {
                MessageBox.Show("Гость не имеет доступа к делам и слушаниям.", "Доступ ограничен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

        private async void buttonAddCourt_Click(object sender, EventArgs e)
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
                await LoadCourtsAsync();

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
