using System;

namespace DevExpressReportingExtensions.Reports
{
    public static partial class DataExtensions
    {
        public static string JoinDataMembers(string masterDataMember, string dataMember)
        {
            if (string.IsNullOrWhiteSpace(dataMember))
            {
                throw new ArgumentNullException(nameof(dataMember));
            }

            if (!string.IsNullOrWhiteSpace(masterDataMember))
            {
                return $"{masterDataMember}.{dataMember}";
            }
            else
            {
                return dataMember;
            }
        }
        
    }
}