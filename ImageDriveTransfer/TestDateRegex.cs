using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImageDriveTransfer
{
    public class TestDateRegex
    {
        // Date Formatter
        public static string FormatDate(string unformattedDate, string regexExpression)
        {
            // First try to get common date format from string (ex: JAN202010)
            string firstCommonDatePatern = @"(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(\d{1})(\d{1})?(\d{4})"; //JAN202010
            string unformattedDate_noSpace = unformattedDate.Replace(" ", "");
            var matchFirstCommonDate = Regex.Match(unformattedDate_noSpace, firstCommonDatePatern, RegexOptions.IgnoreCase);
            if (matchFirstCommonDate.Success)
            {
                // Extract date components
                string month = matchFirstCommonDate.Groups[1].Value;
                string firstDigit_day = matchFirstCommonDate.Groups[2].Value;
                string secondDigit_day = matchFirstCommonDate.Groups[3].Success ? matchFirstCommonDate.Groups[3].Value : "";
                string year = matchFirstCommonDate.Groups[4].Value;

                string date = $"{month} {firstDigit_day}{secondDigit_day} {year}";

                DateTime parseDate;
                if (DateTime.TryParse(date, out parseDate))
                {
                    // Format the parsed date into the specific format you desire
                    string formattedDate = parseDate.ToString("yyyy-MM-dd"); // Chnage the format as needed
                    return formattedDate;
                }
                else
                {
                    return ""; // Handle the case where the input string is not a valid date
                }
            }

            // Second try to get rare common date format from string (ex: 10th NOV 2009)
            string lessCommonDatePatern = @"(\d{1,2})(?:st|nd|rd|th)\s?(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)\.?\s?(\d{2,4})"; // @"\b(\d{1,2})(?:st|nd|rd|th)\s?(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)\.?\s?(\d{4})\b"
            var lessCommonDate = Regex.Match(unformattedDate, lessCommonDatePatern, RegexOptions.IgnoreCase);
            if (lessCommonDate.Success)
            {
                // Extract date components
                string day = lessCommonDate.Groups[1].Value;
                string month = lessCommonDate.Groups[2].Value;
                string year = lessCommonDate.Groups[3].Value;

                string date = $"{month} {day} {year}";

                DateTime parseDate;
                if (DateTime.TryParse(date, out parseDate))
                {
                    // Format the parsed date into the specific format you desire
                    string formattedDate = parseDate.ToString("yyyy-MM-dd"); // Chnage the format as needed
                    return formattedDate;
                }
                else
                {
                    return ""; // Handle the case where the input string is not a valid date
                }
            }

            // Try date pattern provided
            var matchDateFormat = Regex.Match(unformattedDate, regexExpression, RegexOptions.IgnoreCase);

            if (matchDateFormat.Success)
            {
                DateTime parseDate;
                if (DateTime.TryParse(matchDateFormat.Value, out parseDate))
                {
                    // Format the parsed date into the specific format you desire
                    string formattedDate = parseDate.ToString("yyyy-MM-dd"); // Chnage the format as needed
                    return formattedDate;
                }
                else
                {
                    return ""; // Handle the case where the input string is not a valid date
                }
            }
            else
            {
                return ""; // Empty string represent no match
            }
        }
    }
}
