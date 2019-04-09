namespace developer0223
{
    // Unity
    using UnityEngine;

    // Utility
    using developer0223.Utility.Extensions;

    public class Test : MonoBehaviour
    {
        private void Start()
        {
            string str = "12345";
            Debug.Log(str.Reverse());
        }
    }
}