using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Client.Common.Extensions
{
    public static class StringExtensions
    {
        public static string TruncateWithEllipsis(this string input, int length)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            if (input.Length > length)
                input = input.Substring(0, length-3) + "...";

            input = input.PadLeft(length);
            return input;
        }
    }
}
