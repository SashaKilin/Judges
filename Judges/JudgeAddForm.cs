using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    public partial class JudgeAddForm : MaterialForm
    {
        public string FullName => textBoxFullName.Text.Trim();
        public string BadgeNumber => textBoxBadgeNumber.Text.Trim();

        public JudgeAddForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);
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
