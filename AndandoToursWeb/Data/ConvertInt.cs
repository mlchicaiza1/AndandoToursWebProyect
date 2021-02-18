using System;
using System.Data.SqlClient;

namespace AndandoToursWeb.Data
{
    internal static class ConvertInt
    {
        public static int SafeGetInt(this SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetInt32(colIndex);
            }
            else
            {
                return 0;
            }
        }
        public static int ValidateGetInt(string colName)
        {
            if (colName != null )
            {
                return Int32.Parse(colName);
            }
            else
            {
                return 0;
            }
        }
        public static decimal ValidateGetDecimal(string colName)
        {
            if (colName != null)
            {
                return decimal.Parse(colName);
            }
            else
            {
                return 0;
            }
        }
        public static string ValidatString(string colName)
        {
            if (colName != null)
            {
                return colName;
            }else
            {
                return "Sin Comentarios";
            }
        }
        public static string SafeGetString(this SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetString(colIndex);
            }
            else
            {
                return null;
            }
        }
        public static bool SafeGetBoolean(this SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetBoolean(colIndex);
            }
            else
            {
                return false;
            }
        }
    }
}