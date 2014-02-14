using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace MUAC_STAT
{
    public class GeneralDataSet
    {
        public string OID = "NULL";
        public string ARCID = "NULL";
        public string IFPLID = "NULL";
        public string ADEP = "NULL";
        public string ADES = "NULL";
        public string EOBD = "NULL";
        public string EOBT = "NULL";
        public string ARCTYPE = "NULL";
        public string REG = "NULL";
        public string ARCADDR = "NULL";
        public string F15 = "NULL";
        public string FLAG = "NULL";
        public string TSTARTTIME = "NULL";
        public string TENDTIME = "NULL";
        public string TPOINTS = "NULL";
        public string FLTSOURCE = "NULL";
        public string FLTSTATE = "NULL";
        public string LASTUPD = "NULL";
        public string STATUS = "NULL";
        public string CBSFLTSTATE = "NULL";

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
                    if (xtr.Name == "OID")
                        OID = xtr.ReadString();
                    else if (xtr.Name == "ARCID")
                        ARCID = xtr.ReadString();
                    else if (xtr.Name == "IFPLID")
                        IFPLID = xtr.ReadString();
                    else if (xtr.Name == "ADEP")
                        ADEP = xtr.ReadString();
                    else if (xtr.Name == "ADES")
                        ADES = xtr.ReadString();
                    else if (xtr.Name == "EOBD")
                        EOBD = xtr.ReadString();
                    else if (xtr.Name == "EOBT")
                        EOBT = xtr.ReadString();
                    else if (xtr.Name == "ARCTYPE")
                        ARCTYPE = xtr.ReadString();
                    else if (xtr.Name == "REG")
                        REG = xtr.ReadString();
                    else if (xtr.Name == "ARCADDR")
                        ARCADDR = xtr.ReadString();
                    else if (xtr.Name == "F15")
                        F15 = xtr.ReadString();
                    else if (xtr.Name == "FLAG")
                        FLAG = xtr.ReadString();
                    else if (xtr.Name == "TSTARTTIME")
                        TSTARTTIME = xtr.ReadString();
                    else if (xtr.Name == "TENDTIME")
                        TENDTIME = xtr.ReadString();
                    else if (xtr.Name == "TPOINTS")
                        TPOINTS = xtr.ReadString();
                    else if (xtr.Name == "FLTSOURCE")
                        FLTSOURCE = xtr.ReadString();
                    else if (xtr.Name == "FLTSTATE")
                        FLTSTATE = xtr.ReadString();
                    else if (xtr.Name == "LASTUPD")
                        LASTUPD = xtr.ReadString();
                    else if (xtr.Name == "STATUS")
                        STATUS = xtr.ReadString();
                    else if (xtr.Name == "CBSFLTSTATE")
                        CBSFLTSTATE = xtr.ReadString();
                }
            }
            catch
            {
                // string Message = e.Source + ": " + e.Message;
                // MessageBox.Show(Message);
                // Result = false;
            }
            return Result;
        }
    }
}
