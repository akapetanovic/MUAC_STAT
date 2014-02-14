﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUAC_STAT
{
    class KML_Common
    {

        // 2013-02-20T00:05:20Z
        public static string Get_KML_Time_Stamp()
        {
            DateTime T_Now = DateTime.UtcNow;
            string TimeStamp = T_Now.Year.ToString("0000") + '-' + T_Now.Month.ToString("00") + '-' + T_Now.Day.ToString("00") + 'T' +
                T_Now.Hour.ToString("00") + ':' + T_Now.Minute.ToString("00") + ':' + T_Now.Second.ToString("00") + 'Z';

            return TimeStamp;
        }
    }
}
