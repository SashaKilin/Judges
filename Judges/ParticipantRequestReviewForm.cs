using System.Data;
using Npgsql;

namespace Judges
{
    public partial class ParticipantRequestReviewForm : Form
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;******;Database=postgres";
        private readonly object courtId;
        private readonly string courtName;
        private object? selectedRequestId;

        public ParticipantRequestReviewForm(object courtId, string courtName)
        {
            InitializeComponent();
            this.courtId = courtId;
            this.courtName = courtName;
            Text = $"Заявки на привязку: {courtName}";
        }

        private void ParticipantRequestReviewForm_Load(object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void InitializeComponent()
        {
            labelTitle = new Label();
            dataGridViewRequests = new DataGridView();
            buttonApprove = new Button();
            buttonReject = new Button();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRequests).BeginInit();
            SuspendLayout();

            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.Location = new Point(25, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(350, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Новые заявки на привязку";

            dataGridViewRequests.AllowUserToAddRows = false;
            dataGridViewRequests.AllowUserToDeleteRows = false;
            dataGridViewRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRequests.Location = new Point(25, 75);
            dataGridViewRequests.Name = "dataGridViewRequests";
            dataGridViewRequests.ReadOnly = true;
            dataGridViewRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRequests.MultiSelect = false;
            dataGridViewRequests.Size = new Size(850, 430);
            dataGridViewRequests.TabIndex = 1;
            dataGridViewRequests.SelectionChanged += dataGridViewRequests_SelectionChanged;

            buttonApprove.Location = new Point(25, 530);
            buttonApprove.Name = "buttonApprove";
            buttonApprove.Size = new Size(220, 45);
            buttonApprove.TabIndex = 2;
            buttonApprove.Text = "Подтвердить";
            buttonApprove.UseVisualStyleBackColor = true;
            buttonApprove.Click += buttonApprove_Click;

            buttonReject.Location = new Point(265, 530);
            buttonReject.Name = "buttonReject";
            buttonReject.Size = new Size(220, 45);
            buttonReject.TabIndex = 3;
            buttonReject.Text = "Отклонить";
            buttonReject.UseVisualStyleBackColor = true;
            buttonReject.Click += buttonReject_Click;

            buttonClose.Location = new Point(655, 530);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(220, 45);
            buttonClose.TabIndex = 4;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += (_, _) => Close();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 610);
            Controls.Add(buttonApprove);
            Controls.Add(buttonReject);
            Controls.Add(buttonClose);
            Controls.Add(dataGridViewRequests);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ParticipantRequestReviewForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += ParticipantRequestReviewForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dataGridViewRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRequests.CurrentRow == null)
            {
                selectedRequestId = null;
                return;
            }

            var value = dataGridViewRequests.CurrentRow.Cells[0].Value;
            selectedRequestId = value == null || value == DBNull.Value ? null : value;
        }

        private void LoadRequests()
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();

                using var command = new NpgsqlCommand("""
                    SELECT pr.request_id,
                           pr.login,
                           pr.created_at,
                           a.participant_id
                    FROM participant_requests pr
                    LEFT JOIN account a ON a.login = pr.login
                    WHERE pr.court_id = @court_id AND pr.status = 'pending'
                    ORDER BY pr.created_at DESC
                    """, connection);
                command.Parameters.AddWithValue("court_id", courtId);

                using var reader = command.ExecuteReader();
                var requests = new DataTable();
                requests.Load(reader);
                dataGridViewRequests.DataSource = requests;

                if (dataGridViewRequests.Columns.Count >= 4)
                {
                    dataGridViewRequests.Columns[0].Visible = false;
                    dataGridViewRequests.Columns[1].HeaderText = "Логин";
                    dataGridViewRequests.Columns[2].HeaderText = "Дата заявки";
                    dataGridViewRequests.Columns[3].HeaderText = "participant_id";
                }

                if (dataGridViewRequests.Rows.Count == 0)
                {
                    selectedRequestId = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить заявки: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == null)
            {
                MessageBox.Show("Выберите заявку для подтверждения.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var login = dataGridViewRequests.CurrentRow?.Cells[1].Value?.ToString();
            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Не удалось определить логин участника.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var transaction = connection.BeginTransaction();

                object? participantId = null;
                using (var getAccountCommand = new NpgsqlCommand("""
                    SELECT participant_id
                    FROM account
                    WHERE login = @login
                    """, connection, transaction))
                {
                    getAccountCommand.Parameters.AddWithValue("login", login);
                    var existingParticipantId = getAccountCommand.ExecuteScalar();
                    participantId = existingParticipantId == null || existingParticipantId == DBNull.Value ? null : existingParticipantId;
                }

                if (participantId == null || participantId == DBNull.Value)
                {
                    using var createParticipantCommand = new NpgsqlCommand("""
                        INSERT INTO participants (full_name, type, phone, email)
                        VALUES (@full_name, 'подсудимый', '', '')
                        RETURNING participant_id
                        """, connection, transaction);
                    createParticipantCommand.Parameters.AddWithValue("full_name", login);
                    participantId = createParticipantCommand.ExecuteScalar();
                }

                using (var updateAccountCommand = new NpgsqlCommand("""
                    UPDATE account
                    SET participant_id = @participant_id,
                        court_id = @court_id,
                        role_id = (SELECT role_id FROM court_staff_roles WHERE role_name = 'подсудимый')
                    WHERE login = @login
                    """, connection, transaction))
                {
                    updateAccountCommand.Parameters.AddWithValue("participant_id", participantId);
                    updateAccountCommand.Parameters.AddWithValue("court_id", courtId);
                    updateAccountCommand.Parameters.AddWithValue("login", login);
                    updateAccountCommand.ExecuteNonQuery();
                }

                using (var updateRequestCommand = new NpgsqlCommand("""
                    UPDATE participant_requests
                    SET status = 'confirmed', participant_id = @participant_id
                    WHERE request_id = @request_id AND status = 'pending'
                    """, connection, transaction))
                {
                    updateRequestCommand.Parameters.AddWithValue("participant_id", participantId);
                    updateRequestCommand.Parameters.AddWithValue("request_id", selectedRequestId);
                    updateRequestCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Заявка подтверждена.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подтвердить заявку: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == null)
            {
                MessageBox.Show("Выберите заявку для отклонения.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                using var command = new NpgsqlCommand("""
                    UPDATE participant_requests
                    SET status = 'rejected'
                    WHERE request_id = @request_id AND status = 'pending'
                    """, connection);
                command.Parameters.AddWithValue("request_id", selectedRequestId);

                if (command.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Заявка уже обработана.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Заявка отклонена.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось отклонить заявку: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Label labelTitle;
        private DataGridView dataGridViewRequests;
        private Button buttonApprove;
        private Button buttonReject;
        private Button buttonClose;
    }
}
