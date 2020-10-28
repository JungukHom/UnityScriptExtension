namespace developer0223.Utilities.CustomClasses
{
    /// <summary>
    /// Custom Dictionary class.
    /// 
    /// Developer Information
    /// GitHub : https://github.com/jungukhom
    /// Blog : https://developer0223.tistory.com/
    /// </summary>
    /// 
    // C#
    using System.Text;
    using System.Collections.Generic;

    public class CustomDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public static CustomDictionary<TKey, TValue> operator &(CustomDictionary<TKey, TValue> a, CustomDictionary<TKey, TValue> b)
        {
            CustomDictionary<TKey, TValue> result = new CustomDictionary<TKey, TValue>();
            foreach (TKey aElement in a.Keys)
            {
                if (b.ContainsKey(aElement))
                {
                    result.Add(aElement, a[aElement]);
                }
            }

            return result;
        }

        public static CustomDictionary<TKey, TValue> operator |(CustomDictionary<TKey, TValue> a, CustomDictionary<TKey, TValue> b)
        {
            CustomDictionary<TKey, TValue> result = new CustomDictionary<TKey, TValue>();
            foreach (TKey aElement in a.Keys)
            {
                result.Add(aElement, a[aElement]);
            }

            foreach (TKey bElement in b.Keys)
            {
                if (!result.ContainsKey(bElement))
                {
                    result.Add(bElement, b[bElement]);
                }
            }

            return result;
        }

        public static CustomDictionary<TKey, TValue> operator -(CustomDictionary<TKey, TValue> a, CustomDictionary<TKey, TValue> b)
        {
            CustomDictionary<TKey, TValue> result = new CustomDictionary<TKey, TValue>();
            foreach (TKey aElement in a.Keys)
            {
                result.Add(aElement, a[aElement]);
            }

            foreach (TKey bElement in b.Keys)
            {
                if (result.ContainsKey(bElement))
                {
                    result.Remove(bElement);
                }
            }

            return result;
        }

        public static CustomDictionary<TKey, TValue> operator +(CustomDictionary<TKey, TValue> a, CustomDictionary<TKey, TValue> b)
        {
            CustomDictionary<TKey, TValue> result = new CustomDictionary<TKey, TValue>();
            foreach (TKey aElement in a.Keys)
            {
                result.Add(aElement, a[aElement]);
            }

            foreach (TKey bElement in b.Keys)
            {
                if (!result.ContainsKey(bElement))
                {
                    result.Add(bElement, b[bElement]);
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach(TKey key in Keys)
            {
                builder.Append($"{{{key}, {this[key]}}} ");
            }

            return builder.ToString();
        }
    }
}