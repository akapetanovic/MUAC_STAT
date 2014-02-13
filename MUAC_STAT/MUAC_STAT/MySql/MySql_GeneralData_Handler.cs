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
            //OID, ARCID, IFPLID, ADEP, ADES, EOBD, EOBT, ARCTYPE, REG, ARCADDR, F15, FLAG, TSTARTTIME, TENDTIME, TPOINTS, FLTSOURCE, FLTSTATE, LASTUPD, STATUS, CBSFLTSTATE

            string query = "INSERT INTO " + MySQLConnetionString.table_name +
                " (OID, ARCID, IFPLID, ADEP, ADES, EOBD, EOBT, ARCTYPE, REG, ARCADDR, F15, FLAG, TSTARTTIME, TENDTIME, TPOINTS, FLTSOURCE, FLTSTATE, LASTUPD, STATUS, CBSFLTSTATE) " +
                " VALUES (" + Get_With_Quitation(Data_Set_One_Flight.OID) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.ARCID) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.IFPLID) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.ADEP) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.ADES) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.EOBD) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.EOBT) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.ARCTYPE) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.REG) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.ARCADDR) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.F15) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.FLAG) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.TSTARTTIME) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.TENDTIME) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.TPOINTS) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.FLTSOURCE) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.FLTSTATE) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.LASTUPD) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.STATUS) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.CBSFLTSTATE) + ")";


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

                    DataSet.OID = dataReader["OID"].ToString();
                    DataSet.ARCID = (string)dataReader["ARCID"];
                    DataSet.IFPLID = (string)dataReader["IFPLID"];
                    DataSet.ADEP = (string)dataReader["ADEP"];
                    DataSet.ADES = (string)dataReader["ADES"];
                    DataSet.EOBD = (string)dataReader["EOBD"];
                    DataSet.EOBT = (string)dataReader["EOBT"];
                    DataSet.ARCTYPE = (string)dataReader["ARCTYPE"];
                    DataSet.REG = (string)dataReader["REG"];
                    DataSet.ARCADDR = (string)dataReader["ARCADDR"];
                    DataSet.F15 = (string)dataReader["F15"];
                    DataSet.FLAG = (string)dataReader["FLAG"];
                    DataSet.TSTARTTIME = dataReader["TSTARTTIME"].ToString();
                    DataSet.TENDTIME = dataReader["TENDTIME"].ToString();
                    DataSet.TPOINTS = (string)dataReader["TPOINTS"];
                    DataSet.FLTSOURCE = (string)dataReader["FLTSOURCE"];
                    DataSet.FLTSTATE = (string)dataReader["FLTSTATE"];
                    DataSet.LASTUPD = dataReader["LASTUPD"].ToString();
                    DataSet.STATUS = (string)dataReader["STATUS"];
                    DataSet.CBSFLTSTATE = dataReader["CBSFLTSTATE"].ToString();

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

        public void ClearDatabase()
        {

            string query = "DELETE FROM " + MySQLConnetionString.table_name;


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
