namespace Judges
{
    partial class JudgeAddForm
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
            labelFullName = new Label();
            textBoxFullName = new TextBox();
            labelBadgeNumber = new Label();
            textBoxBadgeNumber = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Location = new Point(25, 25);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(42, 15);
            labelFullName.TabIndex = 0;
            labelFullName.Text = "ФИО";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(25, 43);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(350, 23);
            textBoxFullName.TabIndex = 1;
            // 
            // labelBadgeNumber
            // 
            labelBadgeNumber.AutoSize = true;
            labelBadgeNumber.Location = new Point(25, 82);
            labelBadgeNumber.Name = "labelBadgeNumber";
            labelBadgeNumber.Size = new Size(124, 15);
            labelBadgeNumber.TabIndex = 2;
            labelBadgeNumber.Text = "Табельный номер";
            // 
            // textBoxBadgeNumber
            // 
            textBoxBadgeNumber.Location = new Point(25, 100);
            textBoxBadgeNumber.Name = "textBoxBadgeNumber";
            textBoxBadgeNumber.Size = new Size(350, 23);
            textBoxBadgeNumber.TabIndex = 3;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(25, 145);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(165, 32);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(210, 145);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(165, 32);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // JudgeAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(400, 205);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxBadgeNumber);
            Controls.Add(labelBadgeNumber);
            Controls.Add(textBoxFullName);
            Controls.Add(labelFullName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "JudgeAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление судьи";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelFullName;
        private TextBox textBoxFullName;
        private Label labelBadgeNumber;
        private TextBox textBoxBadgeNumber;
        private Button buttonSave;
        private Button buttonCancel;
    }
}
