using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    /// <summary>
    /// extension methods for string class
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Trims all.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Trimmed String
        /// </returns>
        public static string TrimAll(this string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
        }

        /// <summary>
        /// Trims the end.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Trimmed String
        /// </returns>
        public static string TrimEnd(this string value)
        {
            string pattern = "\\s+$";
            System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(pattern);

            return string.IsNullOrEmpty(value) ? string.Empty : rgx.Replace(value, string.Empty);
        }

        /// <summary>
        /// Trims the properties.
        /// </summary>
        /// <param name="object">The object.</param>
        public static void TrimProperties(this object @object, params string[] excluded)
        {
            var props = @object.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (prop.PropertyType == typeof(string))
                {
                    var val = prop.GetValue(@object) as string;

                    var newValue = excluded.Contains(prop.Name) ? val?.TrimEnd() : val.TrimAll();

                    prop.SetValue(@object, newValue);
                }
            }
        }

        /// <summary>
        /// Trims the properties of enumerable.
        /// </summary>
        /// <param name="objects">The objs.</param>
        public static void TrimPropertiesOfEnumerable(this IEnumerable<object> objects, params string[] excluded)
        {
            foreach (var @object in objects)
            {
                @object.TrimProperties(excluded);
            }
        }

        /// <summary>
        /// ISO-1252 to Big5 (Traditional Chinese), support Chinese Display
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>
        /// string in Big5 (Traditional Chinese)
        /// </returns>
        public static string Iso1252ToBig5(this string src)
        {
            if (!string.IsNullOrEmpty(src))
            {
                Encoding iso = Encoding.GetEncoding(1252);    // windows-1252 (1252)
                Encoding big5 = Encoding.GetEncoding("big5"); // big5 (950)
                byte[] isoBytes = iso.GetBytes(src);
                return big5.GetString(isoBytes);
            }

            return string.Empty;
        }

        /// <summary>
        /// ISO-1252 to GB-18030, support Chinese Display
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>
        /// string in GB-18030
        /// </returns>
        public static string Iso1252ToGb18030(this string src)
        {
            Encoding iso = Encoding.GetEncoding(1252);  // windows-1252 (1252)
            Encoding gbc = Encoding.GetEncoding(54936); // GB18030 (54936)
            byte[] gbcBytes = iso.GetBytes(src);
            return gbc.GetString(gbcBytes);
        }

        /// <summary>
        /// Converts upper case.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Uppercase string</returns>
        public static string ToUpper(this string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : value.ToUpper();
        }

        /// <summary>
        /// Trims all and converts upper case.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Trimmed uppercase string</returns>
        public static string TrimAllUpper(this string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : value.Trim().ToUpper();
        }

        /// <summary>
        /// Removes Extra White Spaces
        /// </summary>
        /// <param name="value">string to remove spaces from</param>
        /// <returns>A string with spaces removed</returns>
        public static string CollapseSpaces(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return System.Text.RegularExpressions.Regex.Replace(value, @"\s+", " ", System.Text.RegularExpressions.RegexOptions.Multiline);
        }

        /// <summary>
        /// gets hex number for the char representaion of that number.
        /// </summary>
        /// <param name="c">The character representing hex.</param>
        /// <returns>hex number</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static byte HexCharToByte(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return (byte)(c - '0');
            }
            c = (char)(c & ~0x20);
            if (c >= 'A' && c <= 'F')
            {
                return (byte)(c - ('A' - 10));
            }
            throw new ArgumentException(string.Format("Char '{0}' is not a valid represenation of Hex ('0' - '9', 'A' - 'F')", c));
        }

        /// <summary>
        /// gets the byte array for string representation of hex
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>byte array</returns>
        /// <exception cref="System.ArgumentException">Input must have even number of characters (2 chars for each hex byte)</exception>
        public static byte[] HexStringToByteArray(this string hexString)
        {
            if ((hexString.Length & 1) != 0)
            {
                throw new ArgumentException("Input must have even number of characters (2 chars for each hex byte)");
            }
            int length = hexString.Length / 2;
            byte[] ret = new byte[length];
            for (int i = 0, j = 0; i < length; i++)
            {
                byte high = HexCharToByte(hexString[j++]);
                byte low = HexCharToByte(hexString[j++]);
                ret[i] = (byte)((high << 4) | low);
            }

            return ret;
        }

        /// <summary>
        /// Gets the string after the specified sub string.
        /// </summary>
        /// <param name="thisString">The string.</param>
        /// <param name="afterSubstring">The after substring.</param>
        /// <returns>string after the specified sub string</returns>
        public static string After(this string thisString, string afterSubstring)
        {
            int afterSubstringPos = thisString.LastIndexOf(afterSubstring);
            if (afterSubstringPos == -1)
            {
                return string.Empty;
            }
            int afterPos = afterSubstringPos + afterSubstring.Length;
            if (afterPos >= thisString.Length)
            {
                return string.Empty;
            }

            return thisString.Substring(afterPos);
        }

        /// <summary>
        /// Replaces the first.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="search">The search.</param>
        /// <param name="replace">The replace.</param>
        /// <returns>Replaced string</returns>
        public static string ReplaceFirstOccurence(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }

            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
