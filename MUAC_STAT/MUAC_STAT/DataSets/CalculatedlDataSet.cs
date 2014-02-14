using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace MUAC_STAT
{
    public class CalculatedDataSet
    {
        public string OID = "NULL";
        public string ARCID_IFPLID = "NULL";
        public string AORENTRYTIME = "NULL";
        public string AOREXITTIME = "NULL";
        public string AORENTRYPOINT = "NULL";
        public string AOREXITPOINT = "NULL";
        public string MULTYAOR = "NULL";
        public string FPL_Time = "NULL";

        public bool Populate_Calculated_Data(string Path)
        {
            bool Result = true;
            return Result;
        }
    }
}
