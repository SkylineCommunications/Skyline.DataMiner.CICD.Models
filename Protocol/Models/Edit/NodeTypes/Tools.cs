using System;
using System.Globalization;

namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public static class Tools
    {
        public static string GetValueToWrite(object value)
        {
            if (value == null)
            {
                return "";
            }

            switch (value)
            {
                case DateTime dt:
                    if (dt.Date == dt)
                    {
                        // only date part
                        return dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        return dt.ToString("yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture);
                    }
                case bool b:
                    {
                        return b ? "true" : "false";
                    }
                default:
                    {
                        return Convert.ToString(value, CultureInfo.InvariantCulture);
                    }
            }
        }

    }
}
