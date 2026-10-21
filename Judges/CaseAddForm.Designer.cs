namespace Judges
{
    partial class CaseAddForm
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
            labelCaseNumber = new Label();
            textBoxCaseNumber = new TextBox();
            labelJudge = new Label();
            comboBoxJudge = new ComboBox();
            labelTitle = new Label();
            textBoxTitle = new TextBox();
            labelCategory = new Label();
            textBoxCategory = new TextBox();
            labelStatus = new Label();
            textBoxStatus = new TextBox();
            labelFillingDate = new Label();
            dateTimePickerFillingDate = new DateTimePicker();
            buttonSave = new Button();
            buttonCancel = new Button();
            labelNoJudges = new Label();
            SuspendLayout();
            // 
            // labelCaseNumber
            // 
            labelCaseNumber.AutoSize = true;
            labelCaseNumber.Location = new Point(25, 20);
            labelCaseNumber.Name = "labelCaseNumber";
            labelCaseNumber.Size = new Size(80, 15);
            labelCaseNumber.TabIndex = 0;
            labelCaseNumber.Text = "Номер дела";
            // 
            // textBoxCaseNumber
            // 
            textBoxCaseNumber.Location = new Point(25, 38);
            textBoxCaseNumber.Name = "textBoxCaseNumber";
            textBoxCaseNumber.Size = new Size(350, 23);
            textBoxCaseNumber.TabIndex = 1;
            // 
            // labelJudge
            // 
            labelJudge.AutoSize = true;
            labelJudge.Location = new Point(25, 75);
            labelJudge.Name = "labelJudge";
            labelJudge.Size = new Size(43, 15);
            labelJudge.TabIndex = 2;
            labelJudge.Text = "Судья";
            // 
            // comboBoxJudge
            // 
            comboBoxJudge.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJudge.FormattingEnabled = true;
            comboBoxJudge.Location = new Point(25, 93);
            comboBoxJudge.Name = "comboBoxJudge";
            comboBoxJudge.Size = new Size(350, 23);
            comboBoxJudge.TabIndex = 3;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(25, 130);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(63, 15);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Название";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(25, 148);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(350, 23);
            textBoxTitle.TabIndex = 5;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(25, 185);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(69, 15);
            labelCategory.TabIndex = 6;
            labelCategory.Text = "Категория";
            // 
            // textBoxCategory
            // 
            textBoxCategory.Location = new Point(25, 203);
            textBoxCategory.Name = "textBoxCategory";
            textBoxCategory.Size = new Size(350, 23);
            textBoxCategory.TabIndex = 7;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(25, 240);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(47, 15);
            labelStatus.TabIndex = 8;
            labelStatus.Text = "Статус";
            // 
            // textBoxStatus
            // 
            textBoxStatus.Location = new Point(25, 258);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.Size = new Size(350, 23);
            textBoxStatus.TabIndex = 9;
            textBoxStatus.Text = "Новое";
            // 
            // labelFillingDate
            // 
            labelFillingDate.AutoSize = true;
            labelFillingDate.Location = new Point(25, 295);
            labelFillingDate.Name = "labelFillingDate";
            labelFillingDate.Size = new Size(78, 15);
            labelFillingDate.TabIndex = 10;
            labelFillingDate.Text = "Дата подачи";
            // 
            // dateTimePickerFillingDate
            // 
            dateTimePickerFillingDate.Format = DateTimePickerFormat.Short;
            dateTimePickerFillingDate.Location = new Point(25, 313);
            dateTimePickerFillingDate.Name = "dateTimePickerFillingDate";
            dateTimePickerFillingDate.Size = new Size(350, 23);
            dateTimePickerFillingDate.TabIndex = 11;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(25, 365);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(165, 32);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(210, 365);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(165, 32);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelNoJudges
            // 
            labelNoJudges.AutoSize = true;
            labelNoJudges.ForeColor = Color.Firebrick;
            labelNoJudges.Location = new Point(25, 340);
            labelNoJudges.Name = "labelNoJudges";
            labelNoJudges.Size = new Size(350, 15);
            labelNoJudges.TabIndex = 14;
            labelNoJudges.Text = "Сначала добавьте судью в выбранный суд";
            labelNoJudges.Visible = false;
            // 
            // CaseAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(400, 425);
            Controls.Add(labelNoJudges);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(dateTimePickerFillingDate);
            Controls.Add(labelFillingDate);
            Controls.Add(textBoxStatus);
            Controls.Add(labelStatus);
            Controls.Add(textBoxCategory);
            Controls.Add(labelCategory);
            Controls.Add(textBoxTitle);
            Controls.Add(labelTitle);
            Controls.Add(comboBoxJudge);
            Controls.Add(labelJudge);
            Controls.Add(textBoxCaseNumber);
            Controls.Add(labelCaseNumber);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CaseAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Новое дело";
            Load += CaseAddForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelCaseNumber;
        private TextBox textBoxCaseNumber;
        private Label labelJudge;
        private ComboBox comboBoxJudge;
        private Label labelTitle;
        private TextBox textBoxTitle;
        private Label labelCategory;
        private TextBox textBoxCategory;
        private Label labelStatus;
        private TextBox textBoxStatus;
        private Label labelFillingDate;
        private DateTimePicker dateTimePickerFillingDate;
        private Button buttonSave;
        private Button buttonCancel;
        private Label labelNoJudges;
    }
}
