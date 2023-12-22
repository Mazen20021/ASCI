
namespace ASCI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Nametext = new System.Windows.Forms.TextBox();
            this.showpass = new System.Windows.Forms.Button();
            this.hidpass = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(99)))), ((int)(((byte)(101)))));
            this.panel1.Controls.Add(this.showpass);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.ID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Nametext);
            this.panel1.Controls.Add(this.hidpass);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 362);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(-13, 296);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 47);
            this.button2.TabIndex = 6;
            this.button2.Text = "Key Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(12, 141);
            this.ID.MaxLength = 6;
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(360, 39);
            this.ID.TabIndex = 5;
            this.ID.Text = "159159";
            this.ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ID.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "ASCI Login";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(141, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nametext
            // 
            this.Nametext.Location = new System.Drawing.Point(12, 79);
            this.Nametext.Name = "Nametext";
            this.Nametext.Size = new System.Drawing.Size(403, 39);
            this.Nametext.TabIndex = 0;
            this.Nametext.Text = "Name";
            // 
            // showpass
            // 
            this.showpass.BackgroundImage = global::ASCI.Properties.Resources.show;
            this.showpass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showpass.Location = new System.Drawing.Point(378, 141);
            this.showpass.Name = "showpass";
            this.showpass.Size = new System.Drawing.Size(37, 39);
            this.showpass.TabIndex = 7;
            this.showpass.UseVisualStyleBackColor = true;
            this.showpass.Click += new System.EventHandler(this.button3_Click);
            // 
            // hidpass
            // 
            this.hidpass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hidpass.BackgroundImage")));
            this.hidpass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hidpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hidpass.Location = new System.Drawing.Point(378, 141);
            this.hidpass.Name = "hidpass";
            this.hidpass.Size = new System.Drawing.Size(37, 39);
            this.hidpass.TabIndex = 8;
            this.hidpass.UseVisualStyleBackColor = true;
            this.hidpass.Click += new System.EventHandler(this.hidpass_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 354);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASCI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ID;
        public System.Windows.Forms.TextBox Nametext;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button hidpass;
        private System.Windows.Forms.Button showpass;
    }
}

