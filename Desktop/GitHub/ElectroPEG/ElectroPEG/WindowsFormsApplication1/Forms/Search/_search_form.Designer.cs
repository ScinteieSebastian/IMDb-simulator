namespace WindowsFormsApplication1
{
    partial class _search_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_search_form));
            this.angajatiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atestatDataSet = new WindowsFormsApplication1.atestatDataSet();
            this.cheltuieliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salariuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statie_acumulareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.angajatiTableAdapter = new WindowsFormsApplication1.atestatDataSetTableAdapters.angajatiTableAdapter();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cheltuieliTableAdapter = new WindowsFormsApplication1.atestatDataSetTableAdapters.cheltuieliTableAdapter();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.salariuTableAdapter = new WindowsFormsApplication1.atestatDataSetTableAdapters.salariuTableAdapter();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.statie_acumulareTableAdapter = new WindowsFormsApplication1.atestatDataSetTableAdapters.statie_acumulareTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.angajatiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atestatDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheltuieliBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salariuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statie_acumulareBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // angajatiBindingSource
            // 
            this.angajatiBindingSource.DataMember = "angajati";
            this.angajatiBindingSource.DataSource = this.atestatDataSet;
            // 
            // atestatDataSet
            // 
            this.atestatDataSet.DataSetName = "atestatDataSet";
            this.atestatDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cheltuieliBindingSource
            // 
            this.cheltuieliBindingSource.DataMember = "cheltuieli";
            this.cheltuieliBindingSource.DataSource = this.atestatDataSet;
            // 
            // salariuBindingSource
            // 
            this.salariuBindingSource.DataMember = "salariu";
            this.salariuBindingSource.DataSource = this.atestatDataSet;
            // 
            // statie_acumulareBindingSource
            // 
            this.statie_acumulareBindingSource.DataMember = "statie_acumulare";
            this.statie_acumulareBindingSource.DataSource = this.atestatDataSet;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(158, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(353, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "angajati",
            "cheltuieli",
            "salarii",
            "statii"});
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.angajatiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Forms.Search.Reports.angajati_rep.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 74);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(707, 367);
            this.reportViewer1.TabIndex = 7;
            this.reportViewer1.Visible = false;
            // 
            // angajatiTableAdapter
            // 
            this.angajatiTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer2
            // 
            reportDataSource2.Name = "cheltuieli";
            reportDataSource2.Value = this.cheltuieliBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Forms.Search.Reports.cheltuieli_rep.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(2, 74);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(707, 367);
            this.reportViewer2.TabIndex = 8;
            this.reportViewer2.Visible = false;
            // 
            // cheltuieliTableAdapter
            // 
            this.cheltuieliTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer3
            // 
            reportDataSource3.Name = "salariu";
            reportDataSource3.Value = this.salariuBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Forms.Search.Reports.salarii_rep.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(2, 74);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(707, 367);
            this.reportViewer3.TabIndex = 9;
            this.reportViewer3.Visible = false;
            // 
            // salariuTableAdapter
            // 
            this.salariuTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer4
            // 
            reportDataSource4.Name = "statie_acumulare";
            reportDataSource4.Value = this.statie_acumulareBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Forms.Search.Reports.statie_rep.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(2, 74);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.Size = new System.Drawing.Size(707, 367);
            this.reportViewer4.TabIndex = 10;
            this.reportViewer4.Visible = false;
            // 
            // statie_acumulareTableAdapter
            // 
            this.statie_acumulareTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(434, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Show";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _search_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 443);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.reportViewer4);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "_search_form";
            this.Text = "_search_form";
            this.Load += new System.EventHandler(this._search_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.angajatiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atestatDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheltuieliBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salariuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statie_acumulareBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource angajatiBindingSource;
        private atestatDataSet atestatDataSet;
        private atestatDataSetTableAdapters.angajatiTableAdapter angajatiTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource cheltuieliBindingSource;
        private atestatDataSetTableAdapters.cheltuieliTableAdapter cheltuieliTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource salariuBindingSource;
        private atestatDataSetTableAdapters.salariuTableAdapter salariuTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private System.Windows.Forms.BindingSource statie_acumulareBindingSource;
        private atestatDataSetTableAdapters.statie_acumulareTableAdapter statie_acumulareTableAdapter;
        private System.Windows.Forms.Button button2;
    }
}