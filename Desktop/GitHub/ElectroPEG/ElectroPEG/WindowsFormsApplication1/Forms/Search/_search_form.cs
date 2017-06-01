using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class _search_form : Form
    {

        #region watermakrs
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        #endregion

        public _search_form()
        {
            InitializeComponent();
            SendMessage(textBox1.Handle, EM_SETCUEBANNER, 0, "Search in 'angajati' only");
            //   SendMessage(textBox2.Handle, EM_SETCUEBANNER, 0, "Search in 'cheltuieli'");
        }
        private void _search_form_Load(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("angajati"))
            {
                reportViewer1.Visible = true;
                this.angajatiTableAdapter.Fill(this.atestatDataSet.angajati, textBox1.Text); // angajati
                this.reportViewer1.RefreshReport();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("You must select something from combobox!");
            }

            else if (comboBox1.SelectedItem.Equals("angajati"))
            {
                reportViewer2.Visible = false;
                reportViewer3.Visible = false;
                reportViewer4.Visible = false;

                reportViewer1.Visible = true;
                this.angajatiTableAdapter.Fill(this.atestatDataSet.angajati, textBox1.Text); // angajati
                this.reportViewer1.RefreshReport();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("You must select something from combobox!");
            }

            else if (comboBox1.SelectedItem.Equals("angajati"))
            {
                reportViewer2.Visible = false;
                reportViewer3.Visible = false;
                reportViewer4.Visible = false;

                reportViewer1.Visible = true;
                this.angajatiTableAdapter.Fill(this.atestatDataSet.angajati, " "); // angajati
                this.reportViewer1.RefreshReport();

            }

            else if (comboBox1.SelectedItem.Equals("cheltuieli"))
            {

                reportViewer1.Visible = false;
                reportViewer3.Visible = false;
                reportViewer4.Visible = false;
                reportViewer2.Visible = true;
                this.cheltuieliTableAdapter.Fill(this.atestatDataSet.cheltuieli);
                this.reportViewer2.RefreshReport();

            }
            else if (comboBox1.SelectedItem.Equals("salarii"))
            {

                reportViewer1.Visible = false;
                reportViewer2.Visible = false;
                reportViewer4.Visible = false;

                reportViewer3.Visible = true;
                this.salariuTableAdapter.Fill(this.atestatDataSet.salariu);
                this.reportViewer3.RefreshReport();
            }
            else if (comboBox1.SelectedItem.Equals("statii"))
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = false;
                reportViewer3.Visible = false;

                reportViewer4.Visible = true;
                this.statie_acumulareTableAdapter.Fill(this.atestatDataSet.statie_acumulare); // statie
                this.reportViewer4.RefreshReport();
            }
            else if (comboBox1.Equals(null))
            {
                MessageBox.Show("Error,make sure you selected anything");
            }
        }
    }
}
