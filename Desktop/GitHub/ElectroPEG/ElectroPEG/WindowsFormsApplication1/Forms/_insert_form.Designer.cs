namespace WindowsFormsApplication1
{
    partial class Insert_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Insert_form));
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_usertype = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(44, 46);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(146, 20);
            this.textBox_username.TabIndex = 0;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(44, 72);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(146, 20);
            this.textBox_password.TabIndex = 1;
            // 
            // textBox_usertype
            // 
            this.textBox_usertype.Location = new System.Drawing.Point(44, 98);
            this.textBox_usertype.Name = "textBox_usertype";
            this.textBox_usertype.Size = new System.Drawing.Size(146, 20);
            this.textBox_usertype.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Insert_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 205);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_usertype);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_username);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Insert_form";
            this.Text = "Insert_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_usertype;
        private System.Windows.Forms.Button button1;
    }
}