using System;

namespace SophieXML.Units
{
    public static class Logs
    {
        public static void debug(string value)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
            {
                Console.WriteLine("==>" + value);
            }
        }

        public static void information(string value)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
            {
                Console.WriteLine("==>" + value);
            }
        }

        public static void warning(string value)
        {
            Console.WriteLine("==>" + value);
        }

        public static void error(string value)
        {
            Console.WriteLine("==>" + value);
        }
    }
}
