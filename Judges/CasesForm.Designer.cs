namespace Judges
{
    partial class CasesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelTitle = new Label();
            dataGridViewCases = new DataGridView();
            buttonAddCase = new Button();
            dataGridViewHearings = new DataGridView();
            buttonAddHearing = new Button();
            buttonEditHearing = new Button();
            buttonDeleteHearing = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHearings).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.Location = new Point(25, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(180, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Дела суда";
            // 
            // dataGridViewCases
            // 
            dataGridViewCases.AllowUserToAddRows = false;
            dataGridViewCases.AllowUserToDeleteRows = false;
            dataGridViewCases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCases.Location = new Point(25, 75);
            dataGridViewCases.Name = "dataGridViewCases";
            dataGridViewCases.ReadOnly = true;
            dataGridViewCases.RowHeadersWidth = 62;
            dataGridViewCases.Size = new Size(1050, 430);
            dataGridViewCases.TabIndex = 1;
            dataGridViewCases.CellClick += dataGridViewCases_CellClick;
            // 
            // buttonAddCase
            // 
            buttonAddCase.Location = new Point(25, 530);
            buttonAddCase.Name = "buttonAddCase";
            buttonAddCase.Size = new Size(250, 45);
            buttonAddCase.TabIndex = 2;
            buttonAddCase.Text = "Добавить новое дело";
            buttonAddCase.UseVisualStyleBackColor = true;
            buttonAddCase.Click += buttonAddCase_Click;
            // dataGridViewHearings
            dataGridViewHearings.AllowUserToAddRows = false;
            dataGridViewHearings.AllowUserToDeleteRows = false;
            dataGridViewHearings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHearings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHearings.Location = new Point(25, 650);
            dataGridViewHearings.Name = "dataGridViewHearings";
            dataGridViewHearings.ReadOnly = true;
            dataGridViewHearings.Size = new Size(1050, 180);
            dataGridViewHearings.TabIndex = 3;
            dataGridViewHearings.CellClick += dataGridViewHearings_CellClick;
            // buttonAddHearing
            buttonAddHearing.Location = new Point(300, 530);
            buttonAddHearing.Name = "buttonAddHearing";
            buttonAddHearing.Size = new Size(250, 45);
            buttonAddHearing.TabIndex = 4;
            buttonAddHearing.Text = "Добавить слушание";
            buttonAddHearing.UseVisualStyleBackColor = true;
            buttonAddHearing.Click += buttonAddHearing_Click;
            // buttonEditHearing
            buttonEditHearing.Location = new Point(570, 530);
            buttonEditHearing.Name = "buttonEditHearing";
            buttonEditHearing.Size = new Size(220, 45);
            buttonEditHearing.TabIndex = 5;
            buttonEditHearing.Text = "Изменить слушание";
            buttonEditHearing.UseVisualStyleBackColor = true;
            buttonEditHearing.Click += buttonEditHearing_Click;
            // buttonDeleteHearing
            buttonDeleteHearing.Location = new Point(810, 530);
            buttonDeleteHearing.Name = "buttonDeleteHearing";
            buttonDeleteHearing.Size = new Size(220, 45);
            buttonDeleteHearing.TabIndex = 6;
            buttonDeleteHearing.Text = "Удалить слушание";
            buttonDeleteHearing.UseVisualStyleBackColor = true;
            buttonDeleteHearing.Click += buttonDeleteHearing_Click;
            // 
            // CasesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 860);
            Controls.Add(buttonAddHearing);
            Controls.Add(buttonEditHearing);
            Controls.Add(buttonDeleteHearing);
            Controls.Add(dataGridViewHearings);
            Controls.Add(buttonAddCase);
            Controls.Add(dataGridViewCases);
            Controls.Add(labelTitle);
            Name = "CasesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Дела суда";
            Load += CasesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCases).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHearings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelTitle;
        private DataGridView dataGridViewCases;
        private Button buttonAddCase;
        private DataGridView dataGridViewHearings;
        private Button buttonAddHearing;
        private Button buttonEditHearing;
        private Button buttonDeleteHearing;
    }
}
