using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SQLite;

namespace ASCI
{
    public partial class Main : Form
    {
        Connetion c = new Connetion(); //SQL Connection Class
        SQLiteCommand cmd; //Command SQL 
        SQLiteDataReader dr; // Data Reader SQL
        Thread threads, pages; //Making New Threads (threads For Recived Data) , (Pages For New Pages)
        SerialPort sp = null; //intializing the Port
        string[] availablePorts = SerialPort.GetPortNames();
        string selectedPort = "";
        string tags = "";
        string dx_rx = "";
        string name_get = "";
        bool isclosed = false;
        string sql = null;
        bool custom_port = false;
        //start program
        public Main()
        {
            InitializeComponent();
            setports();
            c.connect();
        }
        //creating new threads
        private void newthread()
        {
            //creating new thread to be able to get data continuesly
            threads = new Thread(recive_data);
            //making the thread mode is STA
            threads.SetApartmentState(ApartmentState.STA);
            //starting thread
            threads.Start();
        }
        //getting data from Ports
        private void recive_data()
        {
            string temp = "";
            //always gets data
            while (true)
            {
                try
                {
                    if (richTextBox1.IsHandleCreated)
                    {
                        //working in it's thread
                        BeginInvoke((MethodInvoker)delegate
                        {
                            //checks if recived data is not null
                            if (dx_rx.Length > 0)
                            {
                                temp = dx_rx;
                                //taking only tag
                                temp = temp.Substring(1, 5);
                                //sending tag to check function
                                checkdata(temp);
                                dx_rx = "";
                            }
                        });
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Couldn't Receive Data Due to: " + e, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //decrease load on cpu
                Thread.Sleep(100);
            }
        }
        private void setports()
        {
            
            if (!custom_port)
            {
                if (availablePorts.Length > 0)
                {
                    selectedPort = availablePorts[0]; // Select the first available port
                    sp = new SerialPort(selectedPort, 9600); //baudrate = 9600
                    sp.DataReceived += new SerialDataReceivedEventHandler(data_rx_handler);
                    try
                    {
                        // Open the serial port
                        sp.Open();
                        COMS.Text = selectedPort;
                        //starting reciving thread
                        newthread();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't Connect to Port: " + ex, "Port Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No Ports Found", "Port Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                sp = new SerialPort(selectedPort, 9600); //baudrate = 9600
                sp.DataReceived += new SerialDataReceivedEventHandler(data_rx_handler);
                try
                {
                    // Open the serial port
                    sp.Open();
                    COMS.Text = selectedPort;
                    //starting reciving thread
                    newthread();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't Connect to Port: " + ex, "Port Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }      
        private void data_rx_handler(object sender, SerialDataReceivedEventArgs e)
        {
            //getting data
            sp = (SerialPort)sender;
            dx_rx = sp.ReadExisting();
        }
        private void admins()
        {
            Form1 f = new Form1();
            Application.Run(f);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error in getting day of attendance data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return das;
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
            Close();
            pages = new Thread(getpage);
            pages.SetApartmentState(ApartmentState.STA);
            pages.Start();
        }
        private void Open()
        {
            Close();
            threads = new Thread(admins);
            threads.SetApartmentState(ApartmentState.STA);
            threads.Start();
        }
        private string getnameofad(string tag)
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
        private string getnameofmem(string tag)
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
                    name_get = dr["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Couldn't Get Member Due to: " + ex.Message, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return name_get;
        }
        private bool Adminisfound(string tag)
        {
            c.connect();
            try
            {
                sql = "select KeyID from Admins where KeyID=@KeyID";
                cmd = new SQLiteCommand(sql, c.getconnetion());
                cmd.Parameters.AddWithValue("@KeyID", tag);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (tag == dr["KeyID"].ToString())
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
        public bool Memberisfound(string tag)
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
                    if (tag == dr["ID"].ToString())
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
        private void checkdata(string data)
        {
            c.connect();
            string state = "";
            string message = "";
            richTextBox1.Text = "";
            if (Adminisfound(data))
            {
                message = "Welcome Sir: " + name_get + "You Arrived at " + DateTime.Now.ToString("ddd // hh:mm:ss // dd:MM:yyy");
                settags(data);
                sp.Write("@");
                mainpage();
            }
            else if (Memberisfound(data))
            {

                if (DateTime.Now.Hour > 9 || (DateTime.Now.Hour == 9 && DateTime.Now.Minute >= 30))
                {
                    state = "Late";
                }
                else
                {
                    state = "Early";
                }
                message = "Welcome Sir: " + name_get + "You Arrived at " + DateTime.Now.ToString("ddd // hh:mm:ss // dd:MM:yyy") + " And You are " + state;
                sp.Write("@");
                Invoke((MethodInvoker)delegate
                {
                    setattendance();
                });
            }
            else
            {
                sp.Write("#");
                richTextBox1.Text = "User Not Found";
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

        }
        private void updatemember()
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
                                        if (int.Parse(DateTime.Now.ToString("hh")) > 9 && int.Parse(DateTime.Now.ToString("mm")) > 30 && int.Parse(DateTime.Now.ToString("ss")) > 0)
                                        {
                                            updateCmd.Parameters.AddWithValue("@Type", "Late");
                                        }
                                        else if (int.Parse(DateTime.Now.ToString("hh")) == 9 && int.Parse(DateTime.Now.ToString("mm")) == 30 && int.Parse(DateTime.Now.ToString("ss")) == 0)
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
                                        //MessageBox.Show(name_get + " Updated.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private bool memberfound()
        {
            bool isFound = false;
            c.connect();
            try
            {
                // Check if Attendance Table is empty
                // Assuming you have a database connection object called "connection" and a command object called "command"
                string query = "SELECT COUNT(*) FROM Attendance";
                cmd.CommandText = query;
                int rowCount = (int)cmd.ExecuteScalar();

                if (rowCount > 0)
                {
                    // Check if the member is saved in the database
                    // Assuming you have a member ID stored in a variable called "memberID"
                    query = "SELECT COUNT(*) FROM Attendance WHERE Name = @MemberID";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MemberID", name_get);
                    int memberCount = (int)cmd.ExecuteScalar();

                    if (memberCount > 0)
                    {
                        isFound = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error In Attendance Table: " + e, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isFound;
        }
        private void setattendance()
        {
            c.connect();
            string days = DateTime.Now.ToString("ddd:dd/MM/yyyy");
            string lefts = "Not Yet";
            if (memberfound())
            {
                if (days.Equals(getday()) && lefts.Equals(getleft()))
                {
                    updatemember();
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
                                //MessageBox.Show(name_get + " added.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error in inserting attendance data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
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
                        //MessageBox.Show(name_get + " added.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in inserting attendance data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void COMS_Click(object sender, EventArgs e)
        {
            if(Portsbox.Visible == true)
            {
                Portsbox.Visible = false;
            }
            else
            {
                Portsbox.DataSource = availablePorts;
                Portsbox.Visible = true;
            }
        }

        private void Portsbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPort = Portsbox.SelectedItem.ToString();
            custom_port = true;
            Portsbox.Visible = false;
            setports();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Open();
        }
    }
}
