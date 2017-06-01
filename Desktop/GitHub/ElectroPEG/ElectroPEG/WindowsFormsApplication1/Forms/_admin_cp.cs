using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class _admin_cp : Form
    {
        MySqlConnection connection = new MySqlConnection(_global_var.connection_string);
        DataTable dt = new DataTable();

        public _admin_cp()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        private void _admin_cp_Load(object sender, EventArgs e)
        {
            retrieve_data(_global_var.users, dt);
        }

        public void retrieve_data(string table, DataTable data_table)
        {
            // first clear all data so we dont get duplicates when we recall function
            data_table.Rows.Clear();
            data_table.Columns.Clear();
            dataGridView1.DataSource = data_table;

            // insert values to dgv
            MySqlCommand cmd;
            MySqlDataAdapter adapter;
            cmd = new MySqlCommand(table, connection);
            connection.Open();
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(data_table);
            dataGridView1.DataSource = data_table;
            dataGridView1.Columns[0].Visible = false; // UID is always first column
            connection.Close();
        }

        private void delete_button_Click_1(object sender, EventArgs e)
        {
            string sql_command = _global_var.users;
            MySqlDataAdapter adapter;
            MySqlCommand cmd = new MySqlCommand(sql_command, connection);
            adapter = new MySqlDataAdapter(cmd);
            
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(adapter);

            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            adapter.Update(dt);
            retrieve_data(_global_var.users, dt);
        }
        private void insert_button_Click(object sender, EventArgs e)
        {
            Insert_form insert = new Insert_form();
            insert.ParentFrm = this;
            insert.ShowDialog();
            insert.Focus();
        }
        private void update_button_Click(object sender, EventArgs e)
        {
            string sql_command = _global_var.users;
            MySqlDataAdapter adapter;
            MySqlCommand cmd = new MySqlCommand(sql_command, connection);
            adapter = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(adapter);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            adapter.Update(dt);
        }
        private void refresh_button_Click_1(object sender, EventArgs e)
        {
            retrieve_data(_global_var.users, dt);
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void db_backup()
        {
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup db_backup = new MySqlBackup(cmd))
                    {
                        string path = string.Format(@"{0}\db_backup.sql", Application.StartupPath);

                        cmd.Connection = connection;
                        connection.Open();

                        db_backup.ExportInfo.AddCreateDatabase = true;
                        db_backup.ExportInfo.ExportTableStructure = true;
                        db_backup.ExportInfo.ExportRows = true;
                        db_backup.ExportToFile(path);
                        connection.Close();

                        MessageBox.Show("A backup of current database has been created in Application startup path!");
                    }
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _about_form about_form = new _about_form();
            about_form.ShowDialog();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            connection.Close();
            this.Hide();
            _login_form first_form = new _login_form();
            first_form.ShowDialog(this);
            this.Close();
        }
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db_backup();
        }
    }
}
