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

        private void CaseAddForm_Load(object sender, EventArgs e)
        {
            LoadJudges();
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
                buttonSave.Enabled = judges.Rows.Count > 0;

                if (judges.Rows.Count == 0)
                {
                    labelNoJudges.Visible = true;
                }
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (SelectedJudgeId == null ||
                string.IsNullOrWhiteSpace(CaseNumber) ||
                string.IsNullOrWhiteSpace(Title) ||
                string.IsNullOrWhiteSpace(Category) ||
                string.IsNullOrWhiteSpace(Status))
            {
                MessageBox.Show(
                    "Заполните все поля и выберите судью.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand("""
                    INSERT INTO cases
                        (case_number, judge_id, court_id, title, category, status, filling_date)
                    VALUES
                        (@case_number, @judge_id, @court_id, @title, @category, @status, @filling_date)
                    """, connection);
                command.Parameters.AddWithValue("case_number", CaseNumber);
                command.Parameters.AddWithValue("judge_id", SelectedJudgeId);
                command.Parameters.AddWithValue("court_id", courtId);
                command.Parameters.AddWithValue("title", Title);
                command.Parameters.AddWithValue("category", Category);
                command.Parameters.AddWithValue("status", Status);
                command.Parameters.AddWithValue("filling_date", FillingDate);
                command.ExecuteNonQuery();

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
