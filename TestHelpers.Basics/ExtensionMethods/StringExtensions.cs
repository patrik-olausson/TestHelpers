using System.Text.RegularExpressions;

namespace TestHelpers.Basics
{
    public static class StringExtensions
    {
        /// <summary>
        /// Helper mehtod that searches a (JSON) text for all guids that contains dashes and replaces them 
        /// with the specified replacement value in order to make it usable together with ApprovalTests.
        /// </summary>
        public static string ReplaceGuids(this string value, string replacementValue = "ReplacedGuid")
        {
            return ReplaceExactMatch(value, "........-....-....-....-............", replacementValue);
        }

        /// <summary>
        /// Helper method that searches a (JSON) text for all dates and 
        /// replaces them with the specified replacement value in order to make it usable together with ApprovalTests.
        /// </summary>
        public static string ReplaceJsonFormatedDateTime(this string value, string replacementValue = "ReplacedDateTime")
        {
            return ReplaceExactMatch(value, @"""....-..-...*""", replacementValue);
        }

        /// <summary>
        /// Helper method that searches a text for a specified value (pattern) and replaces 
        /// all matches with the specified replacement value to make it usable together with ApprovalTests.
        /// </summary>
        public static string ReplaceExactMatch(this string value, string valueToReplace, string replacementValue = "ReplacedValue")
        {
            return new Regex(valueToReplace).Replace(value, replacementValue);
        }
    }
}