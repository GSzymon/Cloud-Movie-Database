using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Utills.Methods
{
    public static class DateHelpers
    {
        public static string GetDateAsString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-DD-dd");
        }
    }
}
