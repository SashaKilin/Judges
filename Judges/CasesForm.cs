using System.Data;
using Npgsql;

namespace Judges
{
    public partial class CasesForm : Form
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=pass;Database=postgres";
        private readonly object courtId;
        private readonly string courtName;

        public CasesForm(object courtId, string courtName)
        {
            InitializeComponent();
            this.courtId = courtId;
            this.courtName = courtName;
        }

        private void CasesForm_Load(object sender, EventArgs e)
        {
            labelTitle.Text = $"Дела суда: {courtName}";
            EnsureFillingDateColumn();
            LoadCases();
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
