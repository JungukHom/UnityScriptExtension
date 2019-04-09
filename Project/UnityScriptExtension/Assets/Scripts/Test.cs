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
            CustomDictionary<int, string> dic_01 = new CustomDictionary<int, string>();
            dic_01.Add(0, "zero");
            dic_01.Add(1, "one");
            dic_01.Add(2, "two");
            dic_01.Add(3, "three");

            CustomDictionary<int, string> dic_02 = new CustomDictionary<int, string>();
            dic_02.Add(2, "two");
            dic_02.Add(3, "three");
            dic_02.Add(4, "four");

            CustomDictionary<int, string> plus = (dic_01 + dic_02) - (dic_01 & dic_02);
            foreach(int key in plus.Keys)
            {
                Debug.Log($"{key} : {plus[key]}");
            }
        }
    }
}