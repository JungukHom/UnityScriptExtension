namespace developer0223.Utility
{
    /// <summary>
    /// C# structs extension class
    /// 
    /// Developer Information
    /// GitHub : https://github.com/jungukhom
    /// Blog : https://developer0223.tistory.com/
    /// </summary>

    public static class CSharpStructExtensions
    {
        #region string (System.String)
        public static bool IsNullOrEmpty(this string @string)
        {
            return @string == string.Empty || @string == null;
        }

        public static bool IsNumber(this string @string)
        {

        }
        #endregion
    }
}