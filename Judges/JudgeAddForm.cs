namespace Judges
{
    public partial class JudgeAddForm : Form
    {
        public string FullName => textBoxFullName.Text.Trim();
        public string BadgeNumber => textBoxBadgeNumber.Text.Trim();

        public JudgeAddForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullName) || string.IsNullOrWhiteSpace(BadgeNumber))
            {
                MessageBox.Show(
                    "Заполните ФИО и табельный номер судьи.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
