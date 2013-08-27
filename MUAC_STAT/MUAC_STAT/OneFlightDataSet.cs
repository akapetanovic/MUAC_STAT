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
        public string ARCID = "ARCID";
        public string IFPLID = "IFPLID";
        public string ADEP = "ADEP";
        public string ADES = "ADES";
        public string EOBD = "EOBD";
        public string EOBT = "EOBT";

        public string AIRLINE = "AIRLINE";
        public string ARCTYP = "ARCTYP";
        public string MODE_S_ADDR = "MODE_S_ADD";
        public string RFL = "RFL";
        public string SPEED = "SPEED";
        public string DATE = "DATE";


        public void Populate_General_Data(string Path)
        {

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
            }
        }
    }
}
