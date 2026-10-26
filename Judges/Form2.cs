using MaterialSkin.Controls;
using MaterialSkin;

using Npgsql;

namespace Judges
{
    public partial class    Form2 : MaterialForm
    {
        public Form2()
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

        private void button1_Click(object sender, EventArgs e)
        {

            string connStr = "Host=localhost;Username=postgres;Password=pass;Database=postgres";

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Одно из полей пустое!");
            }
            else
            {
                using (var connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    string sql = """
                        INSERT INTO court_staff_roles (role_name, access_level, description)
                        SELECT 'гость', 1, 'Просмотр судов и судей'
                        WHERE NOT EXISTS (
                            SELECT 1 FROM court_staff_roles WHERE role_name = 'гость'
                        );

                        INSERT INTO account (login, password, role_id)
                        SELECT @user, @pass, role_id
                        FROM court_staff_roles
                        WHERE role_name = 'гость';
                        """;

                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("user", textBox1.Text.ToLower());
                        command.Parameters.AddWithValue("pass", textBox2.Text);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
