namespace developer0223.Utilities.Extensions
{
    /// <summary>
    /// C# struct extension class.
    /// 
    /// Developer Information
    /// GitHub : https://github.com/jungukhom
    /// Blog : https://developer0223.tistory.com/
    /// </summary>

    // C#
    using System;
    using System.Linq;
    using System.Text;

    public static class CSharpStructExtensions
    {
        #region string (System.String)
        /// <summary>
        /// Check string is null or empty. returns true when null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string @string)
        {
            return @string.IsNull() || @string.IsEmpty();
        }

        /// <summary>
        /// Check the value is null.
        /// </summary>
        public static bool IsNull(this string @string)
        {
            return @string == null;
        }

        /// <summary>
        /// Check the value is empty.
        /// </summary>
        public static bool IsEmpty(this string @string)
        {
            return @string == string.Empty;
        }

        /// <summary>
        /// Check the string is number.
        /// </summary>
        public static bool IsNumber(this string @string)
        {
            return decimal.TryParse(@string, out decimal parsedNumber);
        }

        /// <summary>
        /// Check input string contains Korean.
        /// </summary>
        public static bool ContainsKorean(this string @string)
        {
            foreach (char c in @string)
            {
                if (c.IsKorean())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check input string contains English.
        /// </summary>
        public static bool ContainsEnglish(this string @string)
        {
            foreach (char c in @string)
            {
                if (c.IsEnglish())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check input string contains Number.
        /// </summary>
        public static bool ContainsNumber(this string @string)
        {
            foreach (char c in @string)
            {
                if (c.IsNumeric())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Make string reverse.
        /// </summary>
        public static string Reverse(this string @string)
        {
            StringBuilder builder = new StringBuilder();
            char[] array = @string.ToArray();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                builder.Append(array[i]);
            }

            return builder.ToString();
        }
        #endregion

        #region char (System.Char)
        /// <summary>
        /// Check input char is Number.
        /// </summary>
        public static bool IsKorean(this char @char)
        {
            return (0xAC00 <= @char && @char <= 0xD7A3) || (0x3131 <= @char && @char <= 0x318E);
        }

        /// <summary>
        /// Check input char is Number.
        /// </summary>
        public static bool IsEnglish(this char @char)
        {
            return (0x61 <= @char && @char <= 0x7A) || (0x41 <= @char && @char <= 0x5A);
        }

        /// <summary>
        /// Check input char is Number.
        /// </summary>
        public static bool IsNumeric(this char @char)
        {
            return 0x30 <= @char && @char <= 0x39;
        }
        #endregion

        #region int (System.Int32)
        #endregion

        #region long (System.Int64)
        #endregion

        #region float (System.Single)
        /// <summary>
        /// Make float to round int value.
        /// </summary>
        public static int ToRoundInteger(this float @float)
        {
            return (int)Math.Round(@float);
        }
        #endregion

        #region double (System.Double)
        /// <summary>
        /// Make double to round int value.
        /// </summary>
        public static int ToRoundInteger(this double @double)
        {
            return (int)Math.Round(@double);
        }
        #endregion

        #region bool (System.Boolean)
        /// <summary>
        /// Returns opposite value.
        /// </summary>
        public static bool Reverse(this bool @bool)
        {
            return !@bool;
        }
        #endregion
    }
}