using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ASCI
{
    public partial class Form1 : Form
    {
        ASCI asc = new ASCI();
        Connetion c = new Connetion();
        Main m = new Main();
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        Thread thread;
        string times = "";
        string sql = null;
        string ids, names;
        public Form1()
        {
            InitializeComponent();
            hidpass.Visible = false;
            c.connect();
        }
       
        
        private void new_thread()
        {
            Close();
            Thread thread = new Thread(AdminPage);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void AdminPage()
        {
            Application.Run(asc);
        }
        private void Mainpages()
        {
            Application.Run(m);
        }
        private void new_thread2()
        {
            Close();
            Thread thread = new Thread(Mainpages);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new_thread2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showpass.Visible = false;
            showpass.Enabled = false;
            hidpass.Enabled = true;
            hidpass.Visible = true;
            if(ID.UseSystemPasswordChar == true)
            {
                ID.UseSystemPasswordChar = false;
            }
        }

        private void hidpass_Click(object sender, EventArgs e)
        {
            showpass.Visible = true;
            showpass.Enabled = true;
            hidpass.Enabled = false;
            hidpass.Visible = false;
            if (ID.UseSystemPasswordChar == false)
            {
                ID.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.connect();
            sql = "SELECT ID, Name FROM Admins WHERE ID = @IDs";
            using (var cmd = new SQLiteCommand(sql, c.getconnetion()))
            {
                cmd.Parameters.AddWithValue("@IDs", ID.Text);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ids = dr["ID"].ToString();
                        names = dr["Name"].ToString();
                    }
                }
            }
            if(ID.Text == ids && Nametext.Text == names)
            {
                asc.getname(Nametext.Text);
                asc.getid(ID.Text);
                new_thread();
            }
            else
            {
                MessageBox.Show("User Not Found", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
