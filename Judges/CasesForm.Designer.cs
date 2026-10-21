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
            ((System.ComponentModel.ISupportInitialize)dataGridViewCases).BeginInit();
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
            // 
            // CasesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 600);
            Controls.Add(buttonAddCase);
            Controls.Add(dataGridViewCases);
            Controls.Add(labelTitle);
            Name = "CasesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Дела суда";
            Load += CasesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelTitle;
        private DataGridView dataGridViewCases;
        private Button buttonAddCase;
    }
}
