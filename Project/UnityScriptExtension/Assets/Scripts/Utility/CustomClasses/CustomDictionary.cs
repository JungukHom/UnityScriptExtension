namespace developer0223.Utility.CustomClasses
{
    // C#
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

        public static CustomDictionary<TKey, TValue> operator +(CustomDictionary<TKey, TValue> a, CustomDictionary<TKey, TValue> b)
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
    }
}