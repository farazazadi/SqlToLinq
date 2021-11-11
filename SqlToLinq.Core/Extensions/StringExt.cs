using System.Linq;
using System.Text.RegularExpressions;

namespace SqlToLinq.Core.Extensions
{
    public static class StringExt
    {
        public static string SplitCamelCase(this string input, string delimiter = " ")
        {
            return input.Any(char.IsUpper) ?
                string.Join(delimiter, Regex.Split(input, @"(?<!^)(?=[A-Z])|(\d+)")) : input;
        }
    }
}
