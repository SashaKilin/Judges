namespace Judges
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            labelName = new Label();
            textBoxName = new TextBox();
            labelAddress = new Label();
            textBoxAddress = new TextBox();
            labelType = new Label();
            textBoxType = new TextBox();
            buttonAddCourt = new Button();
            dataGridViewCourts = new DataGridView();
            labelJudges = new Label();
            dataGridViewJudges = new DataGridView();
            buttonAddJudge = new Button();
            labelParticipantId = new Label();
            textBoxParticipantId = new TextBox();
            buttonLinkParticipant = new Button();
            buttonOpenCases = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewJudges).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(26, 18);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(895, 99);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать, User!";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(35, 135);
            labelName.Name = "labelName";
            labelName.Size = new Size(120, 32);
            labelName.TabIndex = 1;
            labelName.Text = "Название";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(35, 170);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(330, 39);
            textBoxName.TabIndex = 2;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(390, 135);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(80, 32);
            labelAddress.TabIndex = 3;
            labelAddress.Text = "Адрес";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(390, 170);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(430, 39);
            textBoxAddress.TabIndex = 4;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(845, 135);
            labelType.Name = "labelType";
            labelType.Size = new Size(110, 32);
            labelType.TabIndex = 5;
            labelType.Text = "Тип суда";
            // 
            // textBoxType
            // 
            textBoxType.Location = new Point(845, 170);
            textBoxType.Name = "textBoxType";
            textBoxType.Size = new Size(300, 39);
            textBoxType.TabIndex = 6;
            // 
            // buttonAddCourt
            // 
            buttonAddCourt.Location = new Point(1170, 166);
            buttonAddCourt.Name = "buttonAddCourt";
            buttonAddCourt.Size = new Size(220, 47);
            buttonAddCourt.TabIndex = 7;
            buttonAddCourt.Text = "Добавить суд";
            buttonAddCourt.UseVisualStyleBackColor = true;
            buttonAddCourt.Click += buttonAddCourt_Click;
            // 
            // dataGridViewCourts
            // 
            dataGridViewCourts.AllowUserToAddRows = false;
            dataGridViewCourts.AllowUserToDeleteRows = false;
            dataGridViewCourts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCourts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCourts.Location = new Point(35, 245);
            dataGridViewCourts.Name = "dataGridViewCourts";
            dataGridViewCourts.ReadOnly = true;
            dataGridViewCourts.RowHeadersWidth = 62;
            dataGridViewCourts.Size = new Size(1530, 285);
            dataGridViewCourts.TabIndex = 8;
            dataGridViewCourts.CellClick += dataGridViewCourts_CellClick;
            dataGridViewCourts.CellDoubleClick += dataGridViewCourts_CellDoubleClick;
            // 
            // labelJudges
            // 
            labelJudges.AutoSize = true;
            labelJudges.Location = new Point(35, 550);
            labelJudges.Name = "labelJudges";
            labelJudges.Size = new Size(277, 32);
            labelJudges.TabIndex = 9;
            labelJudges.Text = "Судьи выбранного суда";
            // 
            // dataGridViewJudges
            // 
            dataGridViewJudges.AllowUserToAddRows = false;
            dataGridViewJudges.AllowUserToDeleteRows = false;
            dataGridViewJudges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewJudges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewJudges.Location = new Point(35, 590);
            dataGridViewJudges.Name = "dataGridViewJudges";
            dataGridViewJudges.ReadOnly = true;
            dataGridViewJudges.RowHeadersWidth = 62;
            dataGridViewJudges.Size = new Size(1150, 220);
            dataGridViewJudges.TabIndex = 10;
            // 
            // buttonAddJudge
            // 
            buttonAddJudge.Enabled = false;
            buttonAddJudge.Location = new Point(1210, 650);
            buttonAddJudge.Name = "buttonAddJudge";
            buttonAddJudge.Size = new Size(300, 55);
            buttonAddJudge.TabIndex = 11;
            buttonAddJudge.Text = "Внести нового судью";
            buttonAddJudge.UseVisualStyleBackColor = true;
            buttonAddJudge.Click += buttonAddJudge_Click;
            // labelParticipantId
            labelParticipantId.AutoSize = true;
            labelParticipantId.Location = new Point(35, 135);
            labelParticipantId.Name = "labelParticipantId";
            labelParticipantId.Size = new Size(180, 32);
            labelParticipantId.Text = "Привязка к суду";
            // textBoxParticipantId
            textBoxParticipantId.Location = new Point(35, 170);
            textBoxParticipantId.Name = "textBoxParticipantId";
            textBoxParticipantId.Size = new Size(300, 39);
            // buttonLinkParticipant
            buttonLinkParticipant.Location = new Point(390, 166);
            buttonLinkParticipant.Name = "buttonLinkParticipant";
            buttonLinkParticipant.Size = new Size(300, 55);
            buttonLinkParticipant.TabIndex = 14;
            buttonLinkParticipant.Text = "Подать заявку на привязку";
            buttonLinkParticipant.UseVisualStyleBackColor = true;
            buttonLinkParticipant.Click += buttonLinkParticipant_Click;
            // buttonOpenCases
            buttonOpenCases.Enabled = false;
            buttonOpenCases.Location = new Point(720, 166);
            buttonOpenCases.Name = "buttonOpenCases";
            buttonOpenCases.Size = new Size(300, 55);
            buttonOpenCases.TabIndex = 15;
            buttonOpenCases.Text = "Открыть дела суда";
            buttonOpenCases.UseVisualStyleBackColor = true;
            buttonOpenCases.Click += buttonOpenCases_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1600, 900);
            Controls.Add(dataGridViewCourts);
            Controls.Add(buttonAddJudge);
            Controls.Add(buttonLinkParticipant);
            Controls.Add(textBoxParticipantId);
            Controls.Add(labelParticipantId);
            Controls.Add(buttonOpenCases);
            Controls.Add(dataGridViewJudges);
            Controls.Add(labelJudges);
            Controls.Add(buttonAddCourt);
            Controls.Add(textBoxType);
            Controls.Add(labelType);
            Controls.Add(textBoxAddress);
            Controls.Add(labelAddress);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(label1);
            Margin = new Padding(6);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Судебные дела";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewJudges).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelAddress;
        private TextBox textBoxAddress;
        private Label labelType;
        private TextBox textBoxType;
        private Button buttonAddCourt;
        private DataGridView dataGridViewCourts;
        private Label labelJudges;
        private DataGridView dataGridViewJudges;
        private Button buttonAddJudge;
        private Label labelParticipantId;
        private TextBox textBoxParticipantId;
        private Button buttonLinkParticipant;
        private Button buttonOpenCases;
    }
}