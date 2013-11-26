using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace MUAC_STAT
{
    public class OneFlightDataSet
    {
        public string ARCID = "NULL";
        public string IFPLID = "NULL";
        public string ADEP = "NULL";
        public string ADES = "NULL";
        public string EOBD = "NULL";
        public string EOBT = "NULL";

        public string AIRLINE = "NULL";
        public string ARCTYP = "NULL";
        public string MODE_S_ADDR = "NULL";
        public string RFL = "NULL";
        public string SPEED = "NULL";
        public string DATE = "NULL";


        public bool Populate_General_Data(string Path)
        {
            bool Result = true;
            try
            {
                XmlTextReader xtr = new XmlTextReader(Path);
                xtr.WhitespaceHandling = WhitespaceHandling.None;
                xtr.Read();

                while (xtr.Read()) //load loop
                {
                    // Parse the file
                    if (xtr.Name == "ARCID")
                    {
                        ARCID = xtr.ReadString();
                    }
                    else if (xtr.Name == "IFPLD")
                    {
                        IFPLID = xtr.ReadString();
                    }
                }
            }
            catch (Exception e)
            {
                string Message = e.Source + ": " + e.Message;
                MessageBox.Show(Message);
                Result = false;
            }
            return Result;
        }
    }
}
