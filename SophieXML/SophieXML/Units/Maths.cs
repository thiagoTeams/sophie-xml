using System;

namespace SophieXML.Units
{
    public static class Maths
    {
        public static int Round(this int value, int precision)
        {
            var coef = Math.Pow(10, Math.Abs(precision));
            var x = (int)Math.Round(value / coef, 0);
            return x * (int)coef;
        }

        public static double Round(this double value, int precision)
        {
            var coef = Math.Pow(10, Math.Abs(precision));
            var x = (double) Math.Round(value / coef, 0);
            return x * (double)coef;
        }
    }

    public static class Long
    {
        public static string ToVND(this long value)
        {
            return String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", value);
        }

        public static DateTime ToDateTime(this long value)
        {
            try
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(value).UtcDateTime;//Thời gian gọi notifyUrl (tính theo millisecond) Múi giờ: GMT +7
            }
            catch(Exception ex)
            {
                Logs.debug($"Exception: \n{ex.StackTrace}");
                return DateTimes.Now();
            }
        }
    }
}
