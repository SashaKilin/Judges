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
            labelDefendant = new Label();
            comboBoxDefendant = new ComboBox();
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
            // labelDefendant
            // 
            labelDefendant.AutoSize = true;
            labelDefendant.Location = new Point(25, 130);
            labelDefendant.Name = "labelDefendant";
            labelDefendant.Size = new Size(90, 15);
            labelDefendant.TabIndex = 4;
            labelDefendant.Text = "Подсудимый";
            // 
            // comboBoxDefendant
            // 
            comboBoxDefendant.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDefendant.FormattingEnabled = true;
            comboBoxDefendant.Location = new Point(25, 148);
            comboBoxDefendant.Name = "comboBoxDefendant";
            comboBoxDefendant.Size = new Size(350, 23);
            comboBoxDefendant.TabIndex = 5;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(25, 185);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(63, 15);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "Название";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(25, 203);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(350, 23);
            textBoxTitle.TabIndex = 7;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(25, 240);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(69, 15);
            labelCategory.TabIndex = 8;
            labelCategory.Text = "Категория";
            // 
            // textBoxCategory
            // 
            textBoxCategory.Location = new Point(25, 258);
            textBoxCategory.Name = "textBoxCategory";
            textBoxCategory.Size = new Size(350, 23);
            textBoxCategory.TabIndex = 9;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(25, 295);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(47, 15);
            labelStatus.TabIndex = 10;
            labelStatus.Text = "Статус";
            // 
            // textBoxStatus
            // 
            textBoxStatus.Location = new Point(25, 313);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.Size = new Size(350, 23);
            textBoxStatus.TabIndex = 11;
            textBoxStatus.Text = "Новое";
            // 
            // labelFillingDate
            // 
            labelFillingDate.AutoSize = true;
            labelFillingDate.Location = new Point(25, 350);
            labelFillingDate.Name = "labelFillingDate";
            labelFillingDate.Size = new Size(78, 15);
            labelFillingDate.TabIndex = 12;
            labelFillingDate.Text = "Дата подачи";
            // 
            // dateTimePickerFillingDate
            // 
            dateTimePickerFillingDate.Format = DateTimePickerFormat.Short;
            dateTimePickerFillingDate.Location = new Point(25, 368);
            dateTimePickerFillingDate.Name = "dateTimePickerFillingDate";
            dateTimePickerFillingDate.Size = new Size(350, 23);
            dateTimePickerFillingDate.TabIndex = 13;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(25, 420);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(165, 32);
            buttonSave.TabIndex = 14;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(210, 420);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(165, 32);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelNoJudges
            // 
            labelNoJudges.AutoSize = true;
            labelNoJudges.ForeColor = Color.Firebrick;
            labelNoJudges.Location = new Point(25, 395);
            labelNoJudges.Name = "labelNoJudges";
            labelNoJudges.Size = new Size(350, 15);
            labelNoJudges.TabIndex = 16;
            labelNoJudges.Text = "Сначала добавьте судью в выбранный суд";
            labelNoJudges.Visible = false;
            // 
            // CaseAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(400, 480);
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
            Controls.Add(comboBoxDefendant);
            Controls.Add(labelDefendant);
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
        private Label labelDefendant;
        private ComboBox comboBoxDefendant;
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
