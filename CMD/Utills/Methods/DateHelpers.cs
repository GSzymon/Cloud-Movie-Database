using System;

namespace WebAPI.Utills.Methods
{
    public static class DateHelpers
    {
        public static string GetDateAsString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-DD-dd");
        }

        public static string GetProperDateFormat(string date)
        {
            try
            {
                var dateTime = DateTime.ParseExact(date, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                return dateTime.ToString("yyyy-MM-dd");
            }
            catch (Exception exception)
            {
                return date;
            }
            
        }
    }
}
