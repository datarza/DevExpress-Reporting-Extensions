using System;

using DevExpress.XtraReports.Parameters;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class ParameterExtensions
    {
        public static T GetValue<T>(this Parameter parameter, T defaultValue = default(T))
        {
            if (parameter.Value is T)
            {
                return (T)parameter.Value;
            }
            else
            {
                try
                {
                    return (T)Convert.ChangeType(parameter.Value, typeof(T));
                }
                catch
                {
                    return defaultValue;
                }
            }
        }

        public static DateTime? GetDateTimeValue(this Parameter parameter, DateTime? defaultValue = null)
        {
            if (parameter.Value is string)
            {
                DateTime result;
                if (DateTime.TryParse((string)parameter.Value, out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else if (parameter.Value is DateTime)
            {
                return (DateTime)parameter.Value;
            }
            else if (parameter.Value is DateTime?)
            {
                return (DateTime?)parameter.Value;
            }
            else
            {
                try
                {
                    return (DateTime?)Convert.ChangeType(parameter.Value, typeof(DateTime?));
                }
                catch
                {
                    return defaultValue;
                }
            }
        }

    }
}