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
            foreach (TKey aCollection in a.Keys)
            {
                if (b.ContainsKey(aCollection))
                {
                    result.Add(aCollection, a[aCollection]);
                }
            }

            return result;
        }

        public static CustomDictionary<TKey, TValue> operator |(CustomDictionary<TKey, TValue> a, CustomDictionary<TKey, TValue> b)
        {
            CustomDictionary<TKey, TValue> result = new CustomDictionary<TKey, TValue>();
            foreach (TKey aCollection in a.Keys)
            {
                result.Add(aCollection, a[aCollection]);
            }

            foreach (TKey bCollection in b.Keys)
            {
                if (!result.ContainsKey(bCollection))
                {
                    result.Add(bCollection, b[bCollection]);
                }
            }

            return result;
        }

        public static CustomDictionary<TKey, TValue> operator -(CustomDictionary<TKey, TValue> a, CustomDictionary<TKey, TValue> b)
        {
            CustomDictionary<TKey, TValue> result = new CustomDictionary<TKey, TValue>();
            foreach (TKey aCollection in a.Keys)
            {
                result.Add(aCollection, a[aCollection]);
            }

            foreach (TKey bCollection in b.Keys)
            {
                if (result.ContainsKey(bCollection))
                {
                    result.Remove(bCollection);
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