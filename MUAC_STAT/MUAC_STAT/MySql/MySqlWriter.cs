using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MUAC_STAT
{
    public class MySqlWriter
    {
        private string connString;
        private MySqlConnection MySQLconn;

        public class MySQLConnetionString
        {
            public static string login_name = "root";
            public static string server_name = "localhost";
            public static string database = "cbs_stat";
            public static string table_name = "general";
        }

        public void CloseConnection()
        {
            if (MySQLconn != null)
                MySQLconn.Close();
        }
        public void Commit_One_Flight(OneFlightDataSet Data_Set_One_Flight)
        {

            string query = "INSERT INTO " + MySQLConnetionString.table_name +
                " (IFPLID, ARCID, ADEP, ADES, ARCTYP) " +
                " VALUES (" + Get_With_Quitation(Data_Set_One_Flight.IFPLID) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.ARCID) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.ADEP) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.ADES) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.ARCTYP) + ")";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, MySQLconn);

            try
            {
                //Execute command
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private double ConvertToUNIXTimestamp(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (double)span.TotalSeconds;
        }

        private string Get_With_Quitation(string String_IN)
        {
            return "'" + String_IN + "'";
        }

        private string GetTimeAS_HHMM(DateTime Time_In)
        {
            return Time_In.Hour.ToString("00") + Time_In.Minute.ToString("00");
        }

        public bool Initialise(string server, string database, string login, string table)
        {
            // Set the connection string
            connString = "server=" + MySQLConnetionString.server_name +
               ";User Id=" + MySQLConnetionString.login_name + ";database=" + MySQLConnetionString.database;

            // Open up the connection
            MySQLconn = new MySqlConnection(connString);

            if (MySQLconn != null)
            {
                if (MySQLconn.State == System.Data.ConnectionState.Open)
                {
                    MySQLconn.Close();
                }

                // Set the connection string
                connString = "server=" + MySQLConnetionString.server_name +
                   ";User Id=" + MySQLConnetionString.login_name + ";database=" + MySQLConnetionString.database;

                // Open up the connection
                MySQLconn = new MySqlConnection(connString);

                try
                {
                    MySQLconn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
