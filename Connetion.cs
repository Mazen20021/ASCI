using System;
using System.Windows.Forms;
using System.Data.SQLite;
namespace ASCI
{
    class Connetion
    {
        static private string database = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ASCI.db");
        SQLiteConnection connection = new SQLiteConnection("Data Source=" + database);
        public void connect()
        {
            try
            {
                if(connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error Couldn't Connect To DB Dueto: " + ex, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void closeconnection()
        {
            connection.Close();
        }
        public SQLiteConnection getconnetion()
        {
            return connection;
        }
    }
}
