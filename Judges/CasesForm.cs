using System.Data;
using Microsoft.VisualBasic;
using Npgsql;
using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    public partial class CasesForm : MaterialForm
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=pass;Database=postgres";
        private readonly object courtId;
        private readonly string courtName;
        private readonly string userName;
        private readonly bool canEdit;
        private readonly bool canViewCases;
        private readonly bool isDefendant;
        private object? selectedCaseId;
        private object? selectedHearingId;

        public CasesForm(object courtId, string courtName, string userName, string roleName)
        {
            InitializeComponent();
            ApplyDarkGridTheme(dataGridViewCases);
            dataGridViewCases.EnableHeadersVisualStyles = false;
            dataGridViewCases.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 43, 43);
            ApplyDarkGridTheme(dataGridViewHearings);
            dataGridViewHearings.EnableHeadersVisualStyles = false;
            dataGridViewHearings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 43, 43);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);

            this.courtId = courtId;
            this.courtName = courtName;
            this.userName = userName;
            canEdit = string.Equals(roleName, "судья", StringComparison.OrdinalIgnoreCase);
            canViewCases = !string.Equals(roleName, "гость", StringComparison.OrdinalIgnoreCase);
            isDefendant = string.Equals(roleName, "подсудимый", StringComparison.OrdinalIgnoreCase);
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

        private void CasesForm_Load(object sender, EventArgs e)
        {
            if (!canViewCases)
            {
                MessageBox.Show("Гость не имеет доступа к делам и слушаниям.", "Доступ ограничен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            labelTitle.Text = $"Дела суда: {courtName}";
            buttonAddCase.Visible = canEdit;
            buttonAddCase.Enabled = canEdit;
            buttonAddHearing.Visible = canEdit;
            buttonAddHearing.Enabled = canEdit;
            buttonEditHearing.Visible = canEdit;
            buttonEditHearing.Enabled = canEdit;
            buttonDeleteHearing.Visible = canEdit;
            buttonDeleteHearing.Enabled = canEdit;
            buttonCloseCase.Visible = canEdit;
            buttonCloseCase.Enabled = canEdit;
            buttonArchiveCases.Visible = canEdit;
            buttonArchiveCases.Enabled = canEdit;
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
            if (!canViewCases)
            {
                dataGridViewCases.DataSource = new DataTable();
                dataGridViewHearings.DataSource = new DataTable();
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = isDefendant
                    ? new NpgsqlCommand("""
                        SELECT c.case_id,
                               c.case_number,
                               j.full_name AS judge_name,
                               c.title,
                               c.category,
                               c.status,
                               c.filling_date
                        FROM cases c
                        LEFT JOIN judges j ON j.judge_id = c.judge_id
                        JOIN case_participants cp ON cp.case_id = c.case_id
                        JOIN account a ON a.participant_id = cp.participant_id
                        WHERE c.court_id = @court_id
                          AND a.login = @login
                          AND COALESCE(c.is_archived, false) = false
                        ORDER BY c.filling_date DESC, c.case_number
                        """, connection)
                    : new NpgsqlCommand("""
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
                          AND COALESCE(c.is_archived, false) = false
                        ORDER BY c.filling_date DESC, c.case_number
                        """, connection);
                command.Parameters.AddWithValue("court_id", courtId);
                if (isDefendant)
                {
                    command.Parameters.AddWithValue("login", userName);
                }

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
            if (!canViewCases || selectedCaseId == null)
            {
                dataGridViewHearings.DataSource = new DataTable();
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var command = isDefendant
                    ? new NpgsqlCommand("""
                        SELECT h.hearing_id, h.hearing_date, h.room_number, h.result_summary
                        FROM hearings h
                        WHERE h.case_id = @case_id
                          AND EXISTS (
                              SELECT 1
                              FROM case_participants cp
                              JOIN account a ON a.participant_id = cp.participant_id
                              WHERE cp.case_id = h.case_id
                                AND a.login = @login
                          )
                        ORDER BY h.hearing_date
                        """, connection)
                    : new NpgsqlCommand("""
                        SELECT hearing_id, hearing_date, room_number, result_summary
                        FROM hearings
                        WHERE case_id = @case_id
                        ORDER BY hearing_date
                        """, connection);
                command.Parameters.AddWithValue("case_id", selectedCaseId);
                if (isDefendant)
                {
                    command.Parameters.AddWithValue("login", userName);
                }
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

        private void buttonCloseCase_Click(object sender, EventArgs e)
        {
            if (!canEdit || selectedCaseId == null)
            {
                MessageBox.Show("Сначала выберите дело.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var finalDecision = Interaction.InputBox(
                "Введите итоговое решение по этому делу:",
                "Закрытие дела",
                string.Empty,
                -1,
                -1);

            if (string.IsNullOrWhiteSpace(finalDecision))
            {
                MessageBox.Show("Итоговое решение обязательно для закрытия дела.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Закрыть дело и перенести его в архив?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var command = new NpgsqlCommand("""
                    UPDATE cases
                    SET is_archived = true,
                        final_decision = @final_decision,
                        closed_at = CURRENT_TIMESTAMP
                    WHERE case_id = @case_id
                      AND COALESCE(is_archived, false) = false
                    """, connection);
                command.Parameters.AddWithValue("case_id", selectedCaseId);
                command.Parameters.AddWithValue("final_decision", finalDecision.Trim());

                if (command.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Дело уже закрыто или не найдено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                selectedCaseId = null;
                selectedHearingId = null;
                dataGridViewHearings.DataSource = new DataTable();
                LoadCases();
                MessageBox.Show("Дело закрыто и добавлено в архив.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось закрыть дело: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonArchiveCases_Click(object sender, EventArgs e)
        {
            using var archiveForm = new CaseArchiveForm(courtId, courtName);
            archiveForm.ShowDialog(this);
        }

        private void buttonEditHearing_Click(object sender, EventArgs e)
        {
            if (selectedCaseId == null)
            {
                MessageBox.Show("Сначала выберите дело.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedHearingId == null)
            {
                MessageBox.Show("Сначала выберите слушание.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var hearingForm = new HearingAddForm(selectedCaseId, courtId, selectedHearingId);
            if (hearingForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadHearings();
            }
        }

        private void buttonDeleteHearing_Click(object sender, EventArgs e)
        {
            if (selectedCaseId == null)
            {
                MessageBox.Show("Сначала выберите дело.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedHearingId == null)
            {
                MessageBox.Show("Сначала выберите слушание.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                "Удалить выбранное слушание?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var command = new NpgsqlCommand("""
                    DELETE FROM hearings
                    WHERE hearing_id = @hearing_id AND case_id = @case_id
                    """, connection);
                command.Parameters.AddWithValue("hearing_id", selectedHearingId);
                command.Parameters.AddWithValue("case_id", selectedCaseId);

                if (command.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Слушание уже удалено или не найдено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                selectedHearingId = null;
                LoadHearings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось удалить слушание: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
