
namespace ASCI
{
    partial class ASCI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASCI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.timetext = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Tapspage = new System.Windows.Forms.TabControl();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.Responsetext = new System.Windows.Forms.TextBox();
            this.BotResponse = new System.Windows.Forms.RichTextBox();
            this.nametext = new System.Windows.Forms.Label();
            this.Employees = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.empname = new System.Windows.Forms.TextBox();
            this.empid = new System.Windows.Forms.TextBox();
            this.Empdata = new System.Windows.Forms.DataGridView();
            this.atendance = new System.Windows.Forms.TabPage();
            this.attendancedata = new System.Windows.Forms.DataGridView();
            this.feedback = new System.Windows.Forms.TabPage();
            this.settings = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.joinedtext = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.changedname = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.confirmchid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.changedid = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Tapspage.SuspendLayout();
            this.MainPage.SuspendLayout();
            this.Employees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Empdata)).BeginInit();
            this.atendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendancedata)).BeginInit();
            this.settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(183)))), ((int)(((byte)(184)))));
            this.panel1.Controls.Add(this.timetext);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Tapspage);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(-5, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 462);
            this.panel1.TabIndex = 0;
            // 
            // timetext
            // 
            this.timetext.AutoSize = true;
            this.timetext.Location = new System.Drawing.Point(30, 415);
            this.timetext.Name = "timetext";
            this.timetext.Size = new System.Drawing.Size(112, 32);
            this.timetext.TabIndex = 12;
            this.timetext.Text = "00:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Time";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::ASCI.Properties.Resources.Pictogrammers_Material_Account_circle_outline1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Tapspage
            // 
            this.Tapspage.Controls.Add(this.MainPage);
            this.Tapspage.Controls.Add(this.Employees);
            this.Tapspage.Controls.Add(this.atendance);
            this.Tapspage.Controls.Add(this.feedback);
            this.Tapspage.Controls.Add(this.settings);
            this.Tapspage.Location = new System.Drawing.Point(169, 3);
            this.Tapspage.Name = "Tapspage";
            this.Tapspage.SelectedIndex = 0;
            this.Tapspage.Size = new System.Drawing.Size(639, 456);
            this.Tapspage.TabIndex = 0;
            // 
            // MainPage
            // 
            this.MainPage.Controls.Add(this.button6);
            this.MainPage.Controls.Add(this.Responsetext);
            this.MainPage.Controls.Add(this.BotResponse);
            this.MainPage.Controls.Add(this.nametext);
            this.MainPage.Location = new System.Drawing.Point(4, 41);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainPage.Size = new System.Drawing.Size(631, 411);
            this.MainPage.TabIndex = 0;
            this.MainPage.Text = "Mainpage";
            this.MainPage.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(99)))), ((int)(((byte)(101)))));
            this.button6.BackgroundImage = global::ASCI.Properties.Resources.send;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(571, 379);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(54, 29);
            this.button6.TabIndex = 2;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Responsetext
            // 
            this.Responsetext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(99)))), ((int)(((byte)(101)))));
            this.Responsetext.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Responsetext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Responsetext.ForeColor = System.Drawing.SystemColors.Info;
            this.Responsetext.Location = new System.Drawing.Point(0, 379);
            this.Responsetext.Name = "Responsetext";
            this.Responsetext.Size = new System.Drawing.Size(568, 29);
            this.Responsetext.TabIndex = 1;
            // 
            // BotResponse
            // 
            this.BotResponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(99)))), ((int)(((byte)(101)))));
            this.BotResponse.Location = new System.Drawing.Point(0, 0);
            this.BotResponse.Name = "BotResponse";
            this.BotResponse.ReadOnly = true;
            this.BotResponse.Size = new System.Drawing.Size(631, 411);
            this.BotResponse.TabIndex = 0;
            this.BotResponse.Text = "";
            // 
            // nametext
            // 
            this.nametext.AutoSize = true;
            this.nametext.Location = new System.Drawing.Point(174, 3);
            this.nametext.Name = "nametext";
            this.nametext.Size = new System.Drawing.Size(63, 32);
            this.nametext.TabIndex = 4;
            this.nametext.Text = ".......";
            // 
            // Employees
            // 
            this.Employees.Controls.Add(this.button9);
            this.Employees.Controls.Add(this.button8);
            this.Employees.Controls.Add(this.empname);
            this.Employees.Controls.Add(this.empid);
            this.Employees.Controls.Add(this.Empdata);
            this.Employees.Location = new System.Drawing.Point(4, 41);
            this.Employees.Name = "Employees";
            this.Employees.Padding = new System.Windows.Forms.Padding(3);
            this.Employees.Size = new System.Drawing.Size(631, 411);
            this.Employees.TabIndex = 1;
            this.Employees.Text = "Employee";
            this.Employees.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(442, 319);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(178, 46);
            this.button9.TabIndex = 5;
            this.button9.Text = "Remove";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(3, 319);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(170, 46);
            this.button8.TabIndex = 4;
            this.button8.Text = "ADD";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // empname
            // 
            this.empname.Location = new System.Drawing.Point(266, 274);
            this.empname.Name = "empname";
            this.empname.Size = new System.Drawing.Size(354, 39);
            this.empname.TabIndex = 3;
            this.empname.Text = "Name";
            // 
            // empid
            // 
            this.empid.Location = new System.Drawing.Point(3, 274);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(257, 39);
            this.empid.TabIndex = 1;
            this.empid.Text = "ID";
            // 
            // Empdata
            // 
            this.Empdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Empdata.Location = new System.Drawing.Point(3, 6);
            this.Empdata.Name = "Empdata";
            this.Empdata.RowHeadersWidth = 51;
            this.Empdata.RowTemplate.Height = 25;
            this.Empdata.Size = new System.Drawing.Size(617, 262);
            this.Empdata.TabIndex = 0;
            // 
            // atendance
            // 
            this.atendance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.atendance.Controls.Add(this.attendancedata);
            this.atendance.Location = new System.Drawing.Point(4, 41);
            this.atendance.Name = "atendance";
            this.atendance.Padding = new System.Windows.Forms.Padding(3);
            this.atendance.Size = new System.Drawing.Size(631, 411);
            this.atendance.TabIndex = 2;
            this.atendance.Text = "Attendance";
            this.atendance.UseVisualStyleBackColor = true;
            // 
            // attendancedata
            // 
            this.attendancedata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attendancedata.Location = new System.Drawing.Point(-2, -2);
            this.attendancedata.Name = "attendancedata";
            this.attendancedata.RowHeadersWidth = 51;
            this.attendancedata.RowTemplate.Height = 25;
            this.attendancedata.Size = new System.Drawing.Size(631, 411);
            this.attendancedata.TabIndex = 0;
            // 
            // feedback
            // 
            this.feedback.Location = new System.Drawing.Point(4, 41);
            this.feedback.Name = "feedback";
            this.feedback.Padding = new System.Windows.Forms.Padding(3);
            this.feedback.Size = new System.Drawing.Size(631, 411);
            this.feedback.TabIndex = 3;
            this.feedback.Text = "FeedBack";
            this.feedback.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.settings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.settings.Controls.Add(this.button10);
            this.settings.Controls.Add(this.joinedtext);
            this.settings.Controls.Add(this.label6);
            this.settings.Controls.Add(this.label4);
            this.settings.Controls.Add(this.label3);
            this.settings.Controls.Add(this.changedname);
            this.settings.Controls.Add(this.button7);
            this.settings.Controls.Add(this.confirmchid);
            this.settings.Controls.Add(this.label2);
            this.settings.Controls.Add(this.changedid);
            this.settings.Location = new System.Drawing.Point(4, 41);
            this.settings.Name = "settings";
            this.settings.Padding = new System.Windows.Forms.Padding(3);
            this.settings.Size = new System.Drawing.Size(631, 411);
            this.settings.TabIndex = 4;
            this.settings.Text = "Settings";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(320, 193);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(171, 39);
            this.button10.TabIndex = 9;
            this.button10.Text = "Change";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // joinedtext
            // 
            this.joinedtext.AutoSize = true;
            this.joinedtext.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.joinedtext.Location = new System.Drawing.Point(109, 93);
            this.joinedtext.Name = "joinedtext";
            this.joinedtext.Size = new System.Drawing.Size(112, 32);
            this.joinedtext.TabIndex = 8;
            this.joinedtext.Text = "..............";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(6, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "Joined:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(109, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "..............";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name:";
            // 
            // changedname
            // 
            this.changedname.Location = new System.Drawing.Point(143, 193);
            this.changedname.Name = "changedname";
            this.changedname.Size = new System.Drawing.Size(171, 39);
            this.changedname.TabIndex = 4;
            this.changedname.Text = "Name";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(143, 326);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(348, 50);
            this.button7.TabIndex = 3;
            this.button7.Text = "Change";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // confirmchid
            // 
            this.confirmchid.Location = new System.Drawing.Point(320, 254);
            this.confirmchid.Name = "confirmchid";
            this.confirmchid.Size = new System.Drawing.Size(171, 39);
            this.confirmchid.TabIndex = 2;
            this.confirmchid.Text = "Confirm ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(257, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Settings";
            // 
            // changedid
            // 
            this.changedid.Location = new System.Drawing.Point(143, 254);
            this.changedid.Name = "changedid";
            this.changedid.Size = new System.Drawing.Size(171, 39);
            this.changedid.TabIndex = 0;
            this.changedid.Text = "ID";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(0, 306);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(185, 44);
            this.button5.TabIndex = 5;
            this.button5.Text = "Logout";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(0, 134);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 44);
            this.button4.TabIndex = 9;
            this.button4.Text = "Employees";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(0, 263);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 44);
            this.button3.TabIndex = 8;
            this.button3.Text = "Settings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 44);
            this.button2.TabIndex = 7;
            this.button2.Text = "FeedBack";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Atendance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ASCI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ASCI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASCI";
            this.Load += new System.EventHandler(this.ASCI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Tapspage.ResumeLayout(false);
            this.MainPage.ResumeLayout(false);
            this.MainPage.PerformLayout();
            this.Employees.ResumeLayout(false);
            this.Employees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Empdata)).EndInit();
            this.atendance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attendancedata)).EndInit();
            this.settings.ResumeLayout(false);
            this.settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl Tapspage;
        private System.Windows.Forms.TabPage MainPage;
        private System.Windows.Forms.TabPage Employees;
        private System.Windows.Forms.TabPage atendance;
        private System.Windows.Forms.TabPage feedback;
        private System.Windows.Forms.TabPage settings;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox Responsetext;
        private System.Windows.Forms.RichTextBox BotResponse;
        private System.Windows.Forms.Label nametext;
        private System.Windows.Forms.TextBox empid;
        private System.Windows.Forms.DataGridView Empdata;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox empname;
        private System.Windows.Forms.Label joinedtext;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox changedname;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox confirmchid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox changedid;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label timetext;
        private System.Windows.Forms.DataGridView attendancedata;
    }
}