using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SQLite;

namespace ASCI
{
    public partial class ASCI : Form
    {
        Connetion c = new Connetion();
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        Thread t;
        string sql = null;
        string Aids = null;
        int count = 0;
        bool waiting = false;
        bool found = false;
        int aids = 0;
        bool withkey = false;
        private static List<int> generatedIDs = new List<int>(); // Keep track of generated IDs
        private List<string> empnames = new List<string>();
        public  System.Windows.Forms.Timer progtimer;
        
        public ASCI()
        {
            InitializeComponent();
            settimer();
            bot("");
           // fillattendancetable();

            //setserial();
        }
        public ASCI(string tags)
        {
            InitializeComponent();
            settimer();
            bot("");
            //fillattendancetable();
            intailizedata(tags);
            withkey = true;

        }
        private void intailizedata(string tag)
        {
            aids = int.Parse(tag);
            c.connect();
            try
            {
                sql = "Select Name from Admins Where ID = @Ids";
                cmd = new SQLiteCommand(sql, c.getconnetion());
                cmd.Parameters.AddWithValue("@Ids", int.Parse(tag));
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    nametext.Text = dr["Name"].ToString();
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show("Error in Couldn't Get Admin Due to: " + ex.Message, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void settimer()
        {
           System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Enabled = true;
            t.Interval = 1000;
            t.Start();
            t.Tick += updatetime;
        }
        private void updatetime(object o , EventArgs e)
        {
          timetext.Text = DateTime.Now.ToString("hh:mm:ss");
        }
        private int GetCount()
        {
            c.connect();
            string sql = "SELECT COUNT(Name) FROM Members";
            cmd = new SQLiteCommand(sql, c.getconnetion());
            count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }
        private List<string> names()
        {
            c.connect();
            sql = "select Name From Members";
            cmd = new SQLiteCommand(sql, c.getconnetion());
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                empnames.Add(dr["Name"].ToString());
            }
            return empnames;
        }
        private void bot(string message)
        {
            int count = GetCount();
            List<string> empNames = names();
            if (waiting == false && message == "")
            {
                BotResponse.AppendText("[Bot01]: My Name is Bot01, I am here to help you. Here are some commands that you can use so we could communicate\n");
                BotResponse.AppendText(" 1- Show Me Employees (1/Employees)\n");
                BotResponse.AppendText(" 2- FeedBack (2/FeedBack)\n");
                BotResponse.AppendText(" 3- Tell Me About YourSelf (3/YourSelf)\n");
                BotResponse.AppendText(" 4- Tell Me About The Team (4/Team)\n");
                waiting = true;
            }
            else
            {
                if (message.Contains("Empolyees") || message.Contains("1"))
                {
                    BotResponse.Text += "[Bot01]: Here's what you asked for, Sir " + nametext.Text + " (Empolyees)\n";
                    BotResponse.Text += "[Bot01]: You have " + count + " employees\n";
                    for (int i = 0; i < count; i++)
                    {
                        BotResponse.Text += "[Bot01]: Their names are: " + empNames[i] + "\n";
                    }
                    waiting = true;
                }
                else if (message.Contains("FeedBack") || message.Contains("feedback") || message.Contains("2"))
                {
                    BotResponse.Text += "[Bot01]: Here what you asked for Sir " + nametext.Text + " (FeedBack)\n";
                    BotResponse.Text += "[Bot01]: There are (num) of employees who attended today and they are (names)\n";
                    BotResponse.Text += "[Bot01]: There are (num) of employees who didn't attent today and they are (names)\n";
                    waiting = true;
                }
                else if (message.Contains("yourself") || message.Contains("Yourself") || message.Contains("Your") || message.Contains("your") || message.Contains("3"))
                {
                    BotResponse.Text += "[Bot01]: I am Static Chatbot designed to serve you sir was desgined and implemented on 10/12/2023, my version is 1.0(Beta) so my functions are limited, Happy To Help You\n";
                    waiting = true;
                }
                else if (message.Contains("Hi") || message.Contains("hi"))
                {
                    BotResponse.AppendText("[Bot01]: Hello Sir " + nametext.Text + " My Name is Bot01, I am here to help you. Here are some commands that you can use so we could communicate\n");
                    BotResponse.AppendText(" 1- Show Me Employees (1/Employees)\n");
                    BotResponse.AppendText(" 2- FeedBack (2/FeedBack)\n");
                    BotResponse.AppendText(" 3- Tell Me About YourSelf (3/YourSelf)\n");
                    BotResponse.AppendText(" 4- Tell Me About The Team (4/Team)\n");;
                    waiting = true;
                }
                else if (message.Contains("Team") || message.Contains("team") || message.Contains("4"))
                {
                    BotResponse.AppendText("[Bot01]: This Program Was Created on 10/12/2023 Using c# by Team 3A\n");
                    BotResponse.AppendText("[Bot01]: Team Members\n");
                    BotResponse.AppendText("[Bot01]: Mazen Ahmed (c# developer)\n");
                    BotResponse.AppendText("[Bot01]: Kareem Amr (Empedded developer)\n");
                    BotResponse.AppendText("[Bot01]: Mohamed Salah (Empedded developer)\n");
                    BotResponse.AppendText("[Bot01]: Mohamed Magdy (Empedded developer)\n");
                    waiting = true;
                }
                else if (message.Contains("Functions") || message.Contains("functions") || message.Contains("help") || message.Contains("Help"))
                {
                    BotResponse.AppendText("[Bot01]: Hello Sir " + nametext.Text + " My Name is Bot01, I am here to help you. Here are some commands that you can use so we could communicate\n");
                    BotResponse.AppendText(" 1- Show Me Employees (1/Employees)\n");
                    BotResponse.AppendText(" 2- FeedBack (2/FeedBack)\n");
                    BotResponse.AppendText(" 3- Tell Me About YourSelf (3/YourSelf)\n");
                    BotResponse.AppendText(" 4- Tell Me About The Team (4/Team)\n");
                    waiting = true;
                }
                else
                {
                    BotResponse.Text += "[Bot01]: Sorry I Didn't Get That Please Choose From Above List\n";
                    waiting = true;
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
            {
            BotResponse.Text += Responsetext.Text;
            BotResponse.Text += "\n";
            waiting = false;
            bot(Responsetext.Text);
        }
        public void getname(string name)
        {
            nametext.Text = name;
        }
        private void mainpage()
        {
            Form1 s = new Form1();
            Application.Run(s);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            BotResponse.Text = "";
            waiting = false;
            Close();
            t = new Thread(mainpage);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void setdata()
        {
            c.connect();
            try
            {
                sql = "Select ID , Name , Added , AName from Members";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c.getconnetion()))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dr);
                            Empdata.DataSource = dataTable;
                        }
                        else
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Clear();
                            Empdata.DataSource = dataTable;
                        }
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error in Loading Table Due to: " + ex.Message, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
        private void getjoined()
        {
            c.connect();
            sql = "select Joined from Admins";
            cmd = new SQLiteCommand(sql, c.getconnetion());
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                joinedtext.Text = dr["Joined"].ToString();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            setdata();
            Tapspage.SelectedTab = Employees;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Tapspage.SelectedTab = atendance;
            setattendancedata();
        }
        private void setattendancedata()
        {
            c.connect();
            try
            {
                sql = "Select Name , Arrived , Left , Day , Type from Attendance";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c.getconnetion()))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dr);
                            attendancedata.DataSource = dataTable;
                        }
                        else
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Clear();
                            attendancedata.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Loading Table Due to: " + ex.Message, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fillattendancetable()
        {
            try
            {
                c.connect();

                    sql = "INSERT INTO Attendance (Name, Arrived, Left, Day , Type) " +
                                 "SELECT Name, @a, @l, @d ,@t FROM Members " +
                                 "WHERE NOT EXISTS (SELECT 1 FROM Attendance WHERE Members.Name = Attendance.Name AND Attendance.Day = @d)";
                    using (cmd = new SQLiteCommand(sql, c.getconnetion()))
                    {
                        cmd.Parameters.AddWithValue("@a", "0");
                        cmd.Parameters.AddWithValue("@l", "0");
                        cmd.Parameters.AddWithValue("@d", "0/0/0");
                        cmd.Parameters.AddWithValue("@t", "none");
                        cmd.ExecuteNonQuery();
                    }
                }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error in inserting attendance data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Tapspage.SelectedTab = feedback;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            getjoined();
            label4.Text = nametext.Text;
            Tapspage.SelectedTab = settings;
        }
        private int randomID()
        {
            Random r = new Random();
            int id;
            do
            {
               id = r.Next(10000, 99999); // Generates a random number between 100000 and 999999 (inclusive)
            } while (generatedIDs.Contains(id)); // Check if the generated ID has already been used

            generatedIDs.Add(id); // Add the generated ID to the list of used IDs
            return id;
        }
        public void getid(string id)
        {
            Aids = id;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            c.connect();
            int rand = randomID();
            try
            {
                if(empid.Text.Equals("ID") || empid.Text.Equals("") || empname.Text.Equals("Name") || empname.Text.Equals(""))
                {
                    if((empid.Text.Equals("ID") || empid.Text.Equals("") && !empname.Text.Equals("Name") || !empname.Text.Equals("")))
                    {
                        if(withkey)
                        {
                            MessageBox.Show("Adding Random ID", "Generating ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sql = "Insert Into Members (ID , Name, Added,AID,AName) Values(@IDs,@Names,@added,@AID,@AName)";
                            cmd = new SQLiteCommand(sql, c.getconnetion());
                            cmd.Parameters.AddWithValue("@IDs", rand);
                            cmd.Parameters.AddWithValue("@Names", empname.Text);
                            cmd.Parameters.AddWithValue("@added", DateTime.Now.ToString("(ddd)::(hh:mm:ss)::(dd/MM/yy)"));
                            cmd.Parameters.AddWithValue("@AID", aids);
                            cmd.Parameters.AddWithValue("@AName", nametext.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Member Added Successfully", "Sucess message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setdata();
                            fillattendancetable();
                        }
                        else
                        {
                            MessageBox.Show("Adding Random ID", "Generating ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sql = "Insert Into Members (ID , Name, Added,AID,AName) Values(@IDs,@Names,@added,@AID,@AName)";
                            cmd = new SQLiteCommand(sql, c.getconnetion());
                            cmd.Parameters.AddWithValue("@IDs", rand);
                            cmd.Parameters.AddWithValue("@Names", empname.Text);
                            cmd.Parameters.AddWithValue("@added", DateTime.Now.ToString("(ddd)::(hh:mm:ss)::(dd/MM/yy)"));
                            cmd.Parameters.AddWithValue("@AID", Aids);
                            cmd.Parameters.AddWithValue("@AName", nametext.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Member Added Successfully", "Sucess message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setdata();
                            fillattendancetable();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Invaild Employee data Please enter valid ones", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if(empid.Text.Length < 5)
                    {
                        MessageBox.Show("ID is 5 different numbers", "Length Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if(withkey)
                        {
                            sql = "Insert Into Members (ID , Name, Added,AID,AName) Values(@IDs,@Names,@added,@AID,@AName)";
                            cmd = new SQLiteCommand(sql, c.getconnetion());
                            cmd.Parameters.AddWithValue("@IDs", empid.Text);
                            cmd.Parameters.AddWithValue("@Names", empname.Text);
                            cmd.Parameters.AddWithValue("@added", DateTime.Now.ToString("(ddd)::(hh:mm:ss)::(dd/MM/yy)"));
                            cmd.Parameters.AddWithValue("@AID", aids);
                            cmd.Parameters.AddWithValue("@AName", nametext.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Member Added Successfully", "Sucess message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setdata();
                            fillattendancetable();
                        }
                        else
                        {
                            sql = "Insert Into Members (ID , Name, Added,AID,AName) Values(@IDs,@Names,@added,@AID,@AName)";
                            cmd = new SQLiteCommand(sql, c.getconnetion());
                            cmd.Parameters.AddWithValue("@IDs", empid.Text);
                            cmd.Parameters.AddWithValue("@Names", empname.Text);
                            cmd.Parameters.AddWithValue("@added", DateTime.Now.ToString("(ddd)::(hh:mm:ss)::(dd/MM/yy)"));
                            cmd.Parameters.AddWithValue("@AID", Aids);
                            cmd.Parameters.AddWithValue("@AName", nametext.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Member Added Successfully", "Sucess message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setdata();
                            fillattendancetable();
                        }
                       
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error In adding data dueto: " + ex, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool searchforid(string newid)
        {
            c.connect();
            try
            {
                sql = "select ID from Members where ID=@ID";
                cmd = new SQLiteCommand(sql, c.getconnetion());
                cmd.Parameters.AddWithValue("@ID", newid);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    if(newid.Equals(dr["ID"].ToString()))
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error In getting member id dueto: " + ex, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return found;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            c.connect();
            if (empid.Text.Equals("ID") || empid.Text.Equals(""))
            {
                MessageBox.Show("Invaild Employee ID Please enter valid ID", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult x = MessageBox.Show("Are You Sure You Want To Delete This Member ?", "Deleting Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.Yes)
                {
                    if (searchforid(empid.Text) && (empname.Text != "Name" || empname.Text != ""))
                    {
                        try
                        {
                            sql = "DELETE FROM Members WHERE ID = @ID AND Name = @n; DELETE FROM Attendance WHERE Name = @Name;";
                            cmd = new SQLiteCommand(sql, c.getconnetion());
                            cmd.Parameters.AddWithValue("@ID", empid.Text);
                            cmd.Parameters.AddWithValue("@n", empname.Text);
                            cmd.Parameters.AddWithValue("@Name", empname.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Member is deleted", "Success message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setdata();
                            empid.Text = "ID";
                            empname.Text = "Name";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error in deleting member due to: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Member doesn't exist", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if(changedname.Text == nametext.Text)
            {
                MessageBox.Show("Entered Name Is The Same Saved Name Nothing Changed", "Same Data Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                c.connect();
                try
                {
                    sql = "update Admins set Name = @Name";
                    cmd = new SQLiteCommand(sql, c.getconnetion());
                    cmd.Parameters.AddWithValue("@Name", changedname.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Name Changed", "Sucess Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nametext.Text = changedname.Text;
                    label4.Text = changedname.Text;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Name Not Changed Dueto: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(confirmchid.Text != changedid.Text)
            {
                MessageBox.Show("Error ID UnMatched Try Again", "UnMatched ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                changedid.Text = "ID";
                confirmchid.Text = "Confirm ID";
            }
            else
            {
                if(Aids == changedid.Text)
                {
                    MessageBox.Show("Error ID You Used The Old ID Try With New One", "Old ID Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    changedid.Text = "ID";
                    confirmchid.Text = "Confirm ID";
                }
                else
                {
                    try
                    {
                        c.connect();
                        sql = "UPDATE Admins SET ID = @ID WHERE ID = @Aids";
                        cmd = new SQLiteCommand(sql, c.getconnetion());
                        cmd.Parameters.AddWithValue("@ID", changedid.Text);
                        cmd.Parameters.AddWithValue("@Aids", Aids);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ID Changed", "ID Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changedid.Text = "ID";
                        confirmchid.Text = "Confirm ID";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Couldn't Change ID Dueto: " + ex, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ASCI_Load(object sender, EventArgs e)
        {
            settimer();
        }
    }
}
