using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SQLite;

namespace ASCI
{
    public partial class Main : Form
    {
        ASCI asc = new ASCI();
        string tags = "";
        string dx_rx = "";
        string name_get = "";
        Connetion c = new Connetion();
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        SerialPort sp = null;
        string sql = null;
        Thread th , pages;
        bool isclosed = false;
        public Main()
        {
            InitializeComponent();
            setserial();
            c.connect();
        }
        private void setserial()
        {
            sp = new SerialPort("COM3", 9600);
            try
            {
                if (!sp.IsOpen)
                {
                    sp.Open();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Couldn't Connect To Port Dueto: " + ex, "Port Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        private void admins()
        {
            Form1 f = new Form1();
            Application.Run(f);
        }
        private void settags(string data)
        {
            this.tags = data;
        }
        private string gettags()
        {
            return this.tags;
        }
        private void getpage()
        {
            ASCI f = new ASCI(gettags());
            Application.Run(f);
        }
        private void mainpage()
        {
            if (pages != null && pages.IsAlive)
            {
                pages.Join(); // Wait for the 'pages' thread to complete before starting 'GetPage'
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Close())); // Invoke 'Close' on the UI thread
            }
            else
            {
                this.Close();
            }

            pages = new Thread(getpage);
            pages.SetApartmentState(ApartmentState.STA);
            pages.Start();
        }

        private void Open()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Close())); // Invoke 'Close' on the UI thread
            }
            else
            {
                this.Close();
            }

            isclosed = true;

            if (pages != null && pages.IsAlive)
            {
                pages.Join(); // Wait for the 'pages' thread to complete before starting 'Admins'
            }
            pages = new Thread(admins);
            pages.SetApartmentState(ApartmentState.STA);
            pages.Start();
        }
        private void startthread()
        {
            if(isclosed)
            {
                Close();
            }
            else
            {
                th = new Thread(getdata);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }
        private string getnameofad(int tag)
        {
            c.connect();
            try
            {
                sql = "select Name from Admins where KeyID=@ID";
                cmd = new SQLiteCommand(sql, c.getconnetion());
                cmd.Parameters.AddWithValue("@ID", tag);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    name_get = dr["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Couldn't Get Admin Due to: " + ex.Message, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return name_get;
        }
        private string getnameofmem(int tag)
        {
            c.connect();
            try
            {
                sql = "select Name from Members where ID=@ID";
                cmd = new SQLiteCommand(sql, c.getconnetion());
                cmd.Parameters.AddWithValue("@ID", tag);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    name_get =  dr["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Couldn't Get Member Due to: " + ex.Message, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return name_get;
        }
        private bool Adminisfound(int tag)
        {
            c.connect();
            try
            {
                sql = "select KeyID from Admins where KeyID=@ID";
                cmd = new SQLiteCommand(sql, c.getconnetion());
                cmd.Parameters.AddWithValue("@ID", tag);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (tag == int.Parse(dr["KeyID"].ToString()))
                    {
                        getnameofad(tag);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Couldn't Get Admin Due to: " + ex.Message, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        public bool Memberisfound(int tag)
        {
            c.connect();
            try
            {
                sql = "select ID from Members where ID=@ID";
                cmd = new SQLiteCommand(sql, c.getconnetion());
                cmd.Parameters.AddWithValue("@ID", tag);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (tag == int.Parse(dr["ID"].ToString()))
                    {
                        getnameofmem(tag);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Couldn't Get Member Due to: " + ex.Message, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private void getdata()
        {
            string dx_rx = sp.ReadLine();
            c.connect();
            while (Adminisfound(int.Parse(dx_rx)) || Memberisfound(int.Parse(dx_rx)))
            {
                string state = "";
                string message = "";
                if (Adminisfound(int.Parse(dx_rx)))
                {
                    message = "Welcome Sir: " + name_get + "You Arrived at " +DateTime.Now.ToString("ddd // hh:mm:ss // dd:MM:yyy");
                            settags(dx_rx);
                            mainpage();
                }
                else if (Memberisfound(int.Parse(dx_rx)))
                {
                    if(int.Parse(DateTime.Now.ToString("hh")) > 9 && int.Parse(DateTime.Now.ToString("mm")) > 30 && int.Parse(DateTime.Now.ToString("ss")) > 0)
                    {
                        state = "Late";
                    }
                    else
                    {
                        state = "Early";
                    }
                    message = "Welcome Sir: " + name_get + "You Arrived at " + DateTime.Now.ToString("ddd // hh:mm:ss // dd:MM:yyy") + " And You are " + state;
                    Invoke((MethodInvoker)delegate
                    {
                        setattendance();
                    }); 
                }
                // Invoke the UI update on the main thread
                if (richTextBox1.InvokeRequired)
                {
                    if (richTextBox1.IsHandleCreated)
                    {
                        richTextBox1.Invoke((MethodInvoker)delegate
                        {
                            richTextBox1.Text = message;
                        });
                    }
                    else
                    {
                        // The control's handle hasn't been created yet.
                        // You can try using BeginInvoke instead.
                        richTextBox1.BeginInvoke((MethodInvoker)delegate
                        {
                            richTextBox1.Text = message;
                        });
                    }
                }
                else
                {
                    richTextBox1.Text = message;
                }

                dx_rx = sp.ReadLine();
            }
            MessageBox.Show("User Not Found Wanna Add Him ? His ID is: " + dx_rx);
             
        }
        private string getday()
        {
            string das = "";
            c.connect();
            try
            {
                sql = "select Day from Attendance WHERE Name = @Name";
                cmd = new SQLiteCommand(sql, c.getconnetion());
                cmd.Parameters.AddWithValue("@Name", name_get);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    das = dr["Day"].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in getting day of attendance data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return das;
        }
        private void checkiffound()
        {
            c.connect();
            try
            {
                string sql = "SELECT Day, [Left] FROM Attendance WHERE Name = @Name";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c.getconnetion()))
                {
                    cmd.Parameters.AddWithValue("@Name", name_get);
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string day = dr["Day"].ToString();
                            string left = dr["Left"].ToString();
                            if (day == DateTime.Now.ToString("ddd:dd/MM/yyyy") && left == "Not Yet")
                            {
                                // Update the "Left" time for the existing attendance record
                                try
                                {
                                    string updateSql = "UPDATE Attendance SET [Left] = @Left , [Type] = @Type WHERE Name = @Name AND Day = @Day";
                                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateSql, c.getconnetion()))
                                    {
                                        if(int.Parse(DateTime.Now.ToString("hh")) > 9 && int.Parse(DateTime.Now.ToString("mm")) > 30 && int.Parse(DateTime.Now.ToString("ss")) > 0)
                                        {
                                            updateCmd.Parameters.AddWithValue("@Type", "Late");
                                        }
                                        else if (int.Parse(DateTime.Now.ToString("hh"))  == 9 && int.Parse(DateTime.Now.ToString("mm")) == 30 && int.Parse(DateTime.Now.ToString("ss")) == 0)
                                        {
                                            updateCmd.Parameters.AddWithValue("@Type", "OnTime");
                                        }
                                        else
                                        {
                                            updateCmd.Parameters.AddWithValue("@Type", "Early");
                                        }
                                        updateCmd.Parameters.AddWithValue("@Left", DateTime.Now.ToString("hh:mm:ss"));
                                        updateCmd.Parameters.AddWithValue("@Name", name_get);
                                        updateCmd.Parameters.AddWithValue("@Day", day);
                                        updateCmd.ExecuteNonQuery();
                                        MessageBox.Show(name_get + " Updated.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error in updating Left Time: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in selecting attendance data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string getleft()
        {
            string left = "";
            c.connect();
            try
            {
                sql = "select Left from Attendance WHERE Name = @Name";
                cmd = new SQLiteCommand(sql, c.getconnetion());
                cmd.Parameters.AddWithValue("@Name", name_get);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    left = dr["Left"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getting Left of attendance data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return left;
        }
        private void setattendance()
        {
            c.connect();
            string days = DateTime.Now.ToString("ddd:dd/MM/yyyy");
            string lefts = "Not Yet";
            if(days.Equals(getday()) && lefts.Equals(getleft()))
            {
                checkiffound();
            }
            else 
            {
                if (!days.Equals(getday()))
                {
                    try
                    {
                        string sql = "INSERT INTO Attendance (Name, Arrived, [Left], Day , Type) VALUES (@N, @a, @l, @d , @t)";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, c.getconnetion()))
                        {
                            cmd.Parameters.AddWithValue("@N", name_get);
                            cmd.Parameters.AddWithValue("@a", DateTime.Now.ToString("hh:mm:ss"));
                            cmd.Parameters.AddWithValue("@l", "Not Yet");
                            cmd.Parameters.AddWithValue("@d", DateTime.Now.ToString("ddd:dd/MM/yyyy"));
                            cmd.Parameters.AddWithValue("@t", "None");
                            cmd.ExecuteNonQuery();
                            MessageBox.Show(name_get + " added.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in inserting attendance data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            startthread();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Open();
        }
    }
}
