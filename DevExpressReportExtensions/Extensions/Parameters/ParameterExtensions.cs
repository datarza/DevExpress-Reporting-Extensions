using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;

using System;
using System.Collections.Generic;
using System.Linq;

namespace myClippit.DevExpress.Report.Extensions
{
    public static partial class ParameterExtensions
    {
        public static Parameter CreateParameter(this XtraReport report,
           string caption,
           Type type = null,
           object value = null)
        {
            if (string.IsNullOrWhiteSpace(caption))
            {
                throw new ArgumentNullException(nameof(caption));
            }

            var parameter = new Parameter
            {
                Name = caption/*.Replace(" ", string.Empty).Trim()*/,
                Description = caption
            };

            if (type != null)
                parameter.Type = type;

            if (value != null)
                parameter.Value = value;

            report.Parameters.Add(parameter);
            return parameter;
        }

        public static Parameter SetType(this Parameter parameter,
            Type type,
            object value = null)
        {
            parameter.Type = type ?? throw new ArgumentNullException(nameof(type));
            if (value != null)
                parameter.Value = value;
            return parameter;
        }

        public static Parameter SetValue(this Parameter parameter,
            object value)
        {
            parameter.Value = value ?? throw new ArgumentNullException(nameof(value));
            return parameter;
        }

        public static Parameter SetCalendarWithTime(this Parameter parameter,
            DateTime? value = null)
        {
            parameter.SetType(typeof(DateTime), value);
            return parameter;
        }

        public static Parameter SetYesNoComboBox(this Parameter parameter,
            bool value = default)
        {
            parameter.SetType(typeof(bool), value);
            return parameter;
        }

        public static Parameter SetComboBox<TKey>(this Parameter parameter,
            IReadOnlyDictionary<TKey, string> lookUpValues,
            TKey? value = null) where TKey : struct
        {
            if (lookUpValues == null)
            {
                throw new ArgumentNullException(nameof(lookUpValues));
            }

            parameter.SetType(typeof(TKey?), value);
            parameter.MultiValue = false;

            var settings = new StaticListLookUpSettings();
            settings.LookUpValues.AddRange(lookUpValues.Select(c => new LookUpValue(c.Key, c.Value)));
            parameter.LookUpSettings = settings;

            return parameter;
        }
        
        public static Parameter SetDrowDown<TKey>(this Parameter parameter,
            IReadOnlyDictionary<TKey, string> lookUpValues,
            TKey[] value = null) 
        {
            if (lookUpValues == null)
            {
                throw new ArgumentNullException(nameof(lookUpValues));
            }

            parameter.SetType(typeof(TKey), value);
            parameter.MultiValue = true;

            var settings = new StaticListLookUpSettings();
            settings.LookUpValues.AddRange(lookUpValues.Select(c => new LookUpValue(c.Key, c.Value)));
            parameter.LookUpSettings = settings;            

            return parameter;
        }

        public static Parameter AddDefaultValue<TKey>(this Parameter parameter,
            TKey value,
            string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            var settings = parameter.LookUpSettings as StaticListLookUpSettings;
            if (settings == null)
            {
                settings.LookUpValues.Insert(0, new LookUpValue(value, description));
                parameter.SetValue(value);
            }

            return parameter;
        }

    }
}