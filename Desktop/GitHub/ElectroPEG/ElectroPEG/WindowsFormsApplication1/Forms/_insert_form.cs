using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Insert_form : Form
    {
        public _admin_cp ParentFrm { get; set; }

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        MySqlConnection connection = new MySqlConnection(_global_var.connection_string);

        public Insert_form()
        {
            InitializeComponent();

            SendMessage(textBox_username.Handle, EM_SETCUEBANNER, 0, "Insert username");
            SendMessage(textBox_password.Handle, EM_SETCUEBANNER, 0, "Insert password");
            SendMessage(textBox_usertype.Handle, EM_SETCUEBANNER, 0, "Insert usertype");

            textBox_password.PasswordChar = '*';
        }
        
        private void insert_data(string username, string userpass, string usertype)
        {
            MySqlCommand cmd;
            string hashed_password = _MD5.MD5Hash(userpass);
            string sql_command = "INSERT INTO users(userName,userPass,userType) VALUES(@userName,@userPass,@userType)";

            cmd = new MySqlCommand(sql_command, connection);
            cmd.Parameters.AddWithValue("@userName", username);
            cmd.Parameters.AddWithValue("@userPass", hashed_password);
            cmd.Parameters.AddWithValue("@userType", usertype);
            try
            {
                connection.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully Inserted");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(textBox_username.Text)) || (string.IsNullOrEmpty(textBox_username.Text)) || (string.IsNullOrEmpty(textBox_usertype.Text)))
            {
                MessageBox.Show("You must insert valid data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            else
            {
                insert_data(textBox_username.Text, textBox_password.Text, textBox_usertype.Text);
                ParentFrm.refresh_button.PerformClick(); // clicks refresh button in admin form before disposing current form.
                Insert_form.ActiveForm.Dispose();
            }  
        }
    }
}
