using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace AdminPanel
{
    public static class PersianCalender
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(dateTime) + "" + pc.GetMonth(dateTime).ToString("00") + "" + pc.GetDayOfMonth(dateTime).ToString("00");

        }
    }
}