using System.Data;
using Npgsql;

namespace Judges
{
    public partial class CasesForm : Form
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=pass;Database=postgres";
        private readonly object courtId;
        private readonly string courtName;
        private readonly string userName;
        private readonly bool canEdit;
        private object? selectedCaseId;
        private object? selectedHearingId;

        public CasesForm(object courtId, string courtName, string userName, string roleName)
        {
            InitializeComponent();
            this.courtId = courtId;
            this.courtName = courtName;
            this.userName = userName;
            canEdit = string.Equals(roleName, "судья", StringComparison.OrdinalIgnoreCase);
        }

        private void CasesForm_Load(object sender, EventArgs e)
        {
            labelTitle.Text = $"Дела суда: {courtName}";
            buttonAddCase.Visible = true;
            buttonAddCase.Enabled = canEdit;
            buttonAddHearing.Visible = true;
            buttonAddHearing.Enabled = canEdit;
            buttonEditHearing.Visible = true;
            buttonEditHearing.Enabled = canEdit;
            buttonDeleteHearing.Visible = true;
            buttonDeleteHearing.Enabled = canEdit;
            EnsureFillingDateColumn();
            LoadCases();
        }

        private void dataGridViewHearings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewHearings.Rows.Count)
            {
                return;
            }

            var value = dataGridViewHearings.Rows[e.RowIndex].Cells[0].Value;
            selectedHearingId = value == null || value == DBNull.Value ? null : value;
        }

        private void EnsureFillingDateColumn()
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand("""
                    DO $$
                    BEGIN
                        IF EXISTS (
                            SELECT 1
                            FROM information_schema.columns
                            WHERE table_schema = current_schema()
                              AND table_name = 'cases'
                              AND column_name = 'filling-date'
                        ) AND NOT EXISTS (
                            SELECT 1
                            FROM information_schema.columns
                            WHERE table_schema = current_schema()
                              AND table_name = 'cases'
                              AND column_name = 'filling_date'
                        ) THEN
                            ALTER TABLE cases RENAME COLUMN "filling-date" TO filling_date;
                        END IF;
                    END $$;
                    """, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось обновить структуру таблицы cases: {ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCases()
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand("""
                    SELECT c.case_id,
                           c.case_number,
                           j.full_name AS judge_name,
                           c.title,
                           c.category,
                           c.status,
                           c.filling_date
                    FROM cases c
                    LEFT JOIN judges j ON j.judge_id = c.judge_id
                    WHERE c.court_id = @court_id
                    ORDER BY c.filling_date DESC, c.case_number
                    """, connection);
                command.Parameters.AddWithValue("court_id", courtId);

                using var reader = command.ExecuteReader();
                var cases = new DataTable();
                cases.Load(reader);
                dataGridViewCases.DataSource = cases;

                if (dataGridViewCases.Columns.Count >= 7)
                {
                    dataGridViewCases.Columns[0].Visible = false;
                    dataGridViewCases.Columns[1].HeaderText = "Номер дела";
                    dataGridViewCases.Columns[2].HeaderText = "Судья";
                    dataGridViewCases.Columns[3].HeaderText = "Название";
                    dataGridViewCases.Columns[4].HeaderText = "Категория";
                    dataGridViewCases.Columns[5].HeaderText = "Статус";
                    dataGridViewCases.Columns[6].HeaderText = "Дата подачи";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить дела: {ex.Message}",
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewCases.Rows.Count)
            {
                return;
            }

            var value = dataGridViewCases.Rows[e.RowIndex].Cells[0].Value;
            if (value == null || value == DBNull.Value)
            {
                return;
            }

            selectedCaseId = value;
            LoadHearings();
        }

        private void LoadHearings()
        {
            if (selectedCaseId == null)
            {
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var command = new NpgsqlCommand("""
                    SELECT hearing_id, hearing_date, room_number, result_summary
                    FROM hearings
                    WHERE case_id = @case_id
                    ORDER BY hearing_date
                    """, connection);
                command.Parameters.AddWithValue("case_id", selectedCaseId);
                using var reader = command.ExecuteReader();
                var hearings = new DataTable();
                hearings.Load(reader);
                dataGridViewHearings.DataSource = hearings;

                if (dataGridViewHearings.Columns.Count >= 4)
                {
                    dataGridViewHearings.Columns[0].Visible = false;
                    dataGridViewHearings.Columns[1].HeaderText = "Дата и время";
                    dataGridViewHearings.Columns[2].HeaderText = "Зал";
                    dataGridViewHearings.Columns[3].HeaderText = "Результат";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить слушания: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddHearing_Click(object sender, EventArgs e)
        {
            if (!canEdit || selectedCaseId == null)
            {
                MessageBox.Show("Сначала выберите дело.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var hearingForm = new HearingAddForm(selectedCaseId, courtId);
            if (hearingForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadHearings();
            }
        }

        private void buttonAddCase_Click(object sender, EventArgs e)
        {
            using var caseAddForm = new CaseAddForm(courtId);
            if (caseAddForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadCases();
            }
        }
    }
}
