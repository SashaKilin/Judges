namespace Judges
{
    partial class HearingAddForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelDate = new Label();
            dateTimePickerHearingDate = new DateTimePicker();
            labelRoom = new Label();
            textBoxRoom = new TextBox();
            labelResult = new Label();
            textBoxResult = new TextBox();
            labelParticipants = new Label();
            listBoxParticipants = new ListBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // labelDate
            labelDate.AutoSize = true;
            labelDate.Location = new Point(25, 20);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(90, 15);
            labelDate.Text = "Дата и время";
            // dateTimePickerHearingDate
            dateTimePickerHearingDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerHearingDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePickerHearingDate.Location = new Point(25, 38);
            dateTimePickerHearingDate.Name = "dateTimePickerHearingDate";
            dateTimePickerHearingDate.Size = new Size(260, 23);
            // labelRoom
            labelRoom.AutoSize = true;
            labelRoom.Location = new Point(25, 75);
            labelRoom.Name = "labelRoom";
            labelRoom.Text = "Номер зала";
            // textBoxRoom
            textBoxRoom.Location = new Point(25, 93);
            textBoxRoom.Name = "textBoxRoom";
            textBoxRoom.Size = new Size(260, 23);
            // labelResult
            labelResult.AutoSize = true;
            labelResult.Location = new Point(25, 130);
            labelResult.Name = "labelResult";
            labelResult.Text = "Итог слушания";
            // textBoxResult
            textBoxResult.Location = new Point(25, 148);
            textBoxResult.Multiline = true;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.Size = new Size(260, 70);
            // labelParticipants
            labelParticipants.AutoSize = true;
            labelParticipants.Location = new Point(330, 20);
            labelParticipants.Name = "labelParticipants";
            labelParticipants.Text = "Подсудимые (можно выбрать нескольких)";
            // listBoxParticipants
            listBoxParticipants.FormattingEnabled = true;
            listBoxParticipants.ItemHeight = 15;
            listBoxParticipants.Location = new Point(330, 38);
            listBoxParticipants.Name = "listBoxParticipants";
            listBoxParticipants.SelectionMode = SelectionMode.MultiExtended;
            listBoxParticipants.Size = new Size(330, 184);
            // buttonSave
            buttonSave.Location = new Point(25, 245);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(125, 32);
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // buttonCancel
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(160, 245);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(125, 32);
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // HearingAddForm
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(690, 300);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(listBoxParticipants);
            Controls.Add(labelParticipants);
            Controls.Add(textBoxResult);
            Controls.Add(labelResult);
            Controls.Add(textBoxRoom);
            Controls.Add(labelRoom);
            Controls.Add(dateTimePickerHearingDate);
            Controls.Add(labelDate);
            Name = "HearingAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Новое слушание";
            Load += HearingAddForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelDate;
        private DateTimePicker dateTimePickerHearingDate;
        private Label labelRoom;
        private TextBox textBoxRoom;
        private Label labelResult;
        private TextBox textBoxResult;
        private Label labelParticipants;
        private ListBox listBoxParticipants;
        private Button buttonSave;
        private Button buttonCancel;
    }
}
