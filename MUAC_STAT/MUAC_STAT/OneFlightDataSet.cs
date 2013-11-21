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
            bool Result = false;
            try
            {
                XmlTextReader xtr = new XmlTextReader(Path);
                xtr.WhitespaceHandling = WhitespaceHandling.None;
                xtr.Read(); // read the XML declaration node, advance to <suite> tag

                //while (!xtr.EOF) //load loop
                //{
                //    // Parse the file
                //    if (xtr.Name == "Data")
                //    {
                //        string attribute = xtr.GetAttribute("name");
                //        xtr.Read();

                //        ARCID = xtr.ReadElementString(xtr.Name);
                //    }

                //    xtr.Read();
                //}
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
