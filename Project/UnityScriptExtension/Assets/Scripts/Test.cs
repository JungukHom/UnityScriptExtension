namespace developer0223
{
    // Unity
    using UnityEngine;

    // Utility
    using developer0223.Utility.Extensions;
    using developer0223.Utility.CustomClasses;

    public class Test : MonoBehaviour
    {
        private void Start()
        {
            CustomDictionary<int, string> dic_01 = new CustomDictionary<int, string>
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" }
            };

            CustomDictionary<int, string> dic_02 = new CustomDictionary<int, string>
            {
                { 2, "two" },
                { 3, "three" },
                { 4, "four" }
            };

            CustomDictionary<int, string> plus = (dic_01 + dic_02) - (dic_01 & dic_02);
            foreach(int key in plus.Keys)
            {
                Debug.Log($"{key} : {plus[key]}");
            }

            Debug.Log(plus.ToString());
        }
    }
}