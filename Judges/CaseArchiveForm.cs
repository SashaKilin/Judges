using System.Data;
using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;

namespace Judges
{
    public partial class CaseArchiveForm : MaterialForm
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=pass;Database=postgres";
        private readonly object courtId;
        private readonly string courtName;

        public CaseArchiveForm(object courtId, string courtName)
        {
            InitializeComponent();
            ApplyDarkGridTheme(dataGridViewArchive);
            dataGridViewArchive.EnableHeadersVisualStyles = false;
            dataGridViewArchive.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 43, 43);
            this.courtId = courtId;
            this.courtName = courtName;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);
        }

        private void CaseArchiveForm_Load(object sender, EventArgs e)
        {
            Text = $"Архив дел — {courtName}";
            LoadArchive();
        }

        private void ApplyDarkGridTheme(DataGridView grid)
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

        private void LoadArchive()
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
                           c.filling_date,
                           c.closed_at,
                           COALESCE(
                               string_agg(DISTINCT p.full_name, '; ' ORDER BY p.full_name),
                               ''
                           ) AS defendants,
                           c.final_decision
                    FROM cases c
                    LEFT JOIN judges j ON j.judge_id = c.judge_id
                    LEFT JOIN case_participants cp ON cp.case_id = c.case_id
                    LEFT JOIN participants p ON p.participant_id = cp.participant_id
                    WHERE c.court_id = @court_id
                      AND COALESCE(c.is_archived, false) = true
                    GROUP BY c.case_id,
                             c.case_number,
                             j.full_name,
                             c.title,
                             c.category,
                             c.filling_date,
                             c.closed_at,
                             c.final_decision
                    ORDER BY c.closed_at DESC NULLS LAST, c.case_number
                    """, connection);
                command.Parameters.AddWithValue("court_id", courtId);

                using var reader = command.ExecuteReader();
                var archive = new DataTable();
                archive.Load(reader);
                dataGridViewArchive.DataSource = archive;

                if (dataGridViewArchive.Columns.Count >= 9)
                {
                    dataGridViewArchive.Columns[0].Visible = false;
                    dataGridViewArchive.Columns[1].HeaderText = "Номер дела";
                    dataGridViewArchive.Columns[2].HeaderText = "Судья";
                    dataGridViewArchive.Columns[3].HeaderText = "Название";
                    dataGridViewArchive.Columns[4].HeaderText = "Категория";
                    dataGridViewArchive.Columns[5].HeaderText = "Дата подачи";
                    dataGridViewArchive.Columns[6].HeaderText = "Дата закрытия";
                    dataGridViewArchive.Columns[7].HeaderText = "Подсудимые";
                    dataGridViewArchive.Columns[8].HeaderText = "Итоговое решение";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить архив дел: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
