using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MUAC_STAT
{
    public class MySqlHandler
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
                " (IFPLID, ARCID, ADEP, ADES, ARCTYP, EOBD, EOBT, AIRLINE, ARCADDR, RFL, SPEED) " +
                " VALUES (" + Get_With_Quitation(Data_Set_One_Flight.IFPLID) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.ARCID) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.ADEP) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.ADES) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.ARCTYP) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.EOBD) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.EOBT) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.AIRLINE) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.MODE_S_ADDR) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.RFL) + "," +
                             Get_With_Quitation(Data_Set_One_Flight.SPEED) +  ")";


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

        //Select statement
        public List<OneFlightDataSet> SelectGeneralData()
        {
            string query = "SELECT * FROM " + MySQLConnetionString.table_name;

            List<OneFlightDataSet> list = new List<OneFlightDataSet>();

            //Open connection
            if (MySQLconn.State == System.Data.ConnectionState.Open)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, MySQLconn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                int index = 0;
                while (dataReader.Read())
                {
                    OneFlightDataSet DataSet = new OneFlightDataSet();
                    DataSet.IFPLID = (string)dataReader["IFPLID"];
                    DataSet.ARCID = (string)dataReader["ARCID"];
                    DataSet.ADEP = (string)dataReader["ADEP"];
                    DataSet.ADES = (string)dataReader["ADES"];
                    DataSet.ARCTYP = (string)dataReader["ARCTYP"];
                    DataSet.ARCTYP = (string)dataReader["EOBD"];
                    DataSet.ARCTYP = (string)dataReader["EOBT"];
                    DataSet.ARCTYP = (string)dataReader["AIRLINE"];
                    DataSet.ARCTYP = (string)dataReader["ARCADDR"];
                    DataSet.ARCTYP = (string)dataReader["RFL"];
                    DataSet.ARCTYP = (string)dataReader["SPEED"];

                    list.Add(DataSet);
                    index++;
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
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
