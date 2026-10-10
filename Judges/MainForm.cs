namespace Judges
{
    public partial class MainForm : Form
    {
        private string user1;
        private string pass2;

        public MainForm(string user, string pass)
        {
            InitializeComponent();

            this.user1 = user;
            this.pass2 = pass;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Добро пожаловать, " + user1 + "!";
        }
    }
}
