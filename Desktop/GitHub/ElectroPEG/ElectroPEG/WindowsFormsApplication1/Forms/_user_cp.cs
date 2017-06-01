using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        MySqlConnection connection = new MySqlConnection(_global_var.connection_string);
        DataTable dt = new DataTable();
        MySqlDataAdapter adapter;

        public Form3()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            retrieve_data(_global_var.clienti, dt);
        }
        public void retrieve_data(string table, DataTable data_table)
        {
            // first clear all data so we dont get duplicates when we recall function
            data_table.Rows.Clear();
            data_table.Columns.Clear();
            dataGridView1.DataSource = data_table;

            // insert values to dgv
            MySqlCommand cmd;
            cmd = new MySqlCommand(table, connection);
            connection.Open();
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(data_table);
            dataGridView1.DataSource = data_table;
            dataGridView1.Columns[0].Visible = false; // UID is always first column
            connection.Close();
        }

        // export methods
        private void export_as_xls()
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet = workbook.Sheets["Sheet1"];

                // storing header part in Excel
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("File has been succesfully created");

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
        private void export_as_pdf()
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 4;
            pdfTable.WidthPercentage = 37;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            // Headers
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                pdfTable.AddCell(cell);
            }
            // Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {

                    }
                    else
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                }
            }
            // Exporting PDF 
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Filter = "PDF files (*.pdf)|*.pdf";
            savedialog.FilterIndex = 2;
            if (savedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream stream = new FileStream(savedialog.FileName, FileMode.Create);
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();

            }
         
        }

        // retrieve data cmds
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            retrieve_data(_global_var.achizitii, dt);
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            retrieve_data(_global_var.clienti, dt);
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            retrieve_data(_global_var.acumulatori, dt);
        }

        // menustrip cmds
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _about_form about_form = new _about_form();
            about_form.ShowDialog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // connection.Close();
            this.Hide();
            _login_form first_form = new _login_form();
            first_form.ShowDialog(this);
            this.Close();
        }

        // export cmds
        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export_as_xls();
        }
        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export_as_pdf();
        }

        // buttons
        private void delete_button_Click(object sender, EventArgs e)
        {
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(adapter);
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

            adapter.Update(dt);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _search_form search = new _search_form();
            search.ShowDialog();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            retrieve_data(_global_var.clienti, dt);
        }

        private void angajatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            retrieve_data(_global_var.angajati, dt);
        }

        private void salariiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            retrieve_data(_global_var.salarii, dt);
        }
    }
}
