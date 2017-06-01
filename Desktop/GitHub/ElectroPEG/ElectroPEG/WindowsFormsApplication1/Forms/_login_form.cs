using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class _login_form : Form
    {
        MySqlConnection connection = new MySqlConnection(_global_var.connection_string);

        int type;
        bool login;

        #region watermakrs
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        #endregion

        public _login_form()
        {
            
            InitializeComponent();

            // General properties
            SendMessage(textBox1.Handle, EM_SETCUEBANNER, 0, "Username");
            SendMessage(textBox2.Handle, EM_SETCUEBANNER, 0, "Password");

            textBox2.PasswordChar = '*';
        }
        private void check_connection()
        {
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    //  MessageBox.Show("Connection to host succed! Press ok to proceed", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Connection to host failed! Please conctact administrator", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                connection.Close();
                Application.Exit();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            check_connection();
        }

        #region buttons 
        private void button1_Click_1(object sender, EventArgs e)
        {
            connection.Close();

            string sql_command = "SELECT * FROM users";
            MySqlCommand cmd = new MySqlCommand(sql_command, connection);
            connection.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            login = false;
            while (reader.Read())
            {
                string username = reader.GetString("userName");
                string password = reader.GetString("userPass");

                string textbox_password = textBox2.Text;
                string hashed_password = _MD5.MD5Hash(textbox_password);

                if (password.Equals(hashed_password) && (textBox1.Text.Equals((username))))
                {
                    login = true;
                    type = reader.GetUInt16("userType");
                }
            }
            if (login && type == 1)
            {
                this.Hide();
                _admin_cp second_form = new _admin_cp();
                //  MessageBox.Show("Welcome to admin control panel", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                second_form.ShowDialog();
                this.Close();
                connection.Close();
            }
            if (login && type == 0)
            {
                this.Hide();
                Form3 third_form = new Form3();
                //   MessageBox.Show("Welcome to user control panel", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                third_form.ShowDialog();
                this.Close();
                connection.Close();
            }
            if (!login)
            {
                MessageBox.Show("Insert a valid username or password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
    