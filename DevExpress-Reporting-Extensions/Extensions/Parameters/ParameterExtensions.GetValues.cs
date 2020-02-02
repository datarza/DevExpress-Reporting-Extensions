using System;

using DevExpress.XtraReports.Parameters;

namespace DevExpressReportingExtensions.Parameters
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
        
    }
}