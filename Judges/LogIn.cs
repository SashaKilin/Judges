using MaterialSkin;
using MaterialSkin.Controls;

using Npgsql;

namespace Judges
{
    public partial class LogIn : MaterialForm
    {
        public LogIn()
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

        public string user = string.Empty;
        public string pass = string.Empty;

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите логин и пароль.", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = "Host=localhost;Username=postgres;Password=pass;Database=postgres";
            user = textBox1.Text.Trim();
            pass = textBox2.Text;

            try
            {
                using var connection = new NpgsqlConnection(connStr);
                await connection.OpenAsync();

                EnsureRoles(connection);
                EnsureParticipantAccountLink(connection);
                EnsureParticipants(connection);
                EnsureCaseParticipants(connection);

                const string sql = """
                    SELECT COALESCE(csr.role_name, 'гость')
                    FROM account a
                    LEFT JOIN court_staff_roles csr ON csr.role_id = a.role_id
                    WHERE a.login = @user AND a.password = @pass
                    LIMIT 1
                    """;

                string? roleName = null;
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.CommandTimeout = 5;
                    command.Parameters.AddWithValue("user", user);
                    command.Parameters.AddWithValue("pass", pass);
                    roleName = (await command.ExecuteScalarAsync()) as string;
                }

                if (string.IsNullOrWhiteSpace(roleName))
                {
                    MessageBox.Show("Учетная запись не найдена!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Успешный вход!");

                var mainForm = new MainForm(user, pass, roleName);
                mainForm.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подключиться к базе данных: {ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void EnsureParticipantAccountLink(NpgsqlConnection connection)
        {
            const string sql = """
                ALTER TABLE account
                ADD COLUMN IF NOT EXISTS participant_id integer NULL;

                ALTER TABLE account
                ADD COLUMN IF NOT EXISTS court_id integer NULL;

                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1
                        FROM pg_constraint
                        WHERE conname = 'account_participant_id_fkey'
                    ) THEN
                        ALTER TABLE account
                        ADD CONSTRAINT account_participant_id_fkey
                        FOREIGN KEY (participant_id) REFERENCES participants(participant_id);
                    END IF;

                    IF NOT EXISTS (
                        SELECT 1
                        FROM pg_constraint
                        WHERE conname = 'account_court_id_fkey'
                    ) THEN
                        ALTER TABLE account
                        ADD CONSTRAINT account_court_id_fkey
                        FOREIGN KEY (court_id) REFERENCES courts(court_id);
                    END IF;
                END $$;
                """;

            using var command = new NpgsqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        private static void EnsureParticipants(NpgsqlConnection connection)
        {
            const string sql = """
                CREATE TABLE IF NOT EXISTS participants (
                    participant_id serial PRIMARY KEY,
                    full_name text NOT NULL,
                    type text NOT NULL DEFAULT 'подсудимый',
                    phone text NOT NULL DEFAULT '',
                    email text NOT NULL DEFAULT ''
                );
                """;

            using var command = new NpgsqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        private static void EnsureCaseParticipants(NpgsqlConnection connection)
        {
            const string sql = """
                CREATE TABLE IF NOT EXISTS case_participants (
                    case_id integer NOT NULL REFERENCES cases(case_id),
                    participant_id integer NOT NULL REFERENCES participants(participant_id),
                    PRIMARY KEY (case_id, participant_id)
                );
                """;

            using var command = new NpgsqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        private static void EnsureRoles(NpgsqlConnection connection)
        {
            const string sql = """
                INSERT INTO court_staff_roles (role_name, access_level, description)
                SELECT @role_name, @access_level, @description
                WHERE NOT EXISTS (
                    SELECT 1 FROM court_staff_roles WHERE role_name = @role_name
                );

                UPDATE court_staff_roles
                SET access_level = @access_level,
                    description = @description
                WHERE role_name = @role_name
                """;

            var roles = new[]
            {
                (Name: "гость", AccessLevel: 1, Description: "Просмотр судов и судей"),
                (Name: "подсудимый", AccessLevel: 2, Description: "Просмотр судов и судей"),
                (Name: "судья", AccessLevel: 3, Description: "Добавление судов и судей")
            };

            foreach (var role in roles)
            {
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("role_name", role.Name);
                command.Parameters.AddWithValue("access_level", role.AccessLevel);
                command.Parameters.AddWithValue("description", role.Description);
                command.ExecuteNonQuery();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();

            var form1 = new Form1();
            form1.Show();
        }
    }
}
