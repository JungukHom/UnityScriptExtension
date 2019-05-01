namespace developer0223
{
    // Unity
    using UnityEngine;

    // Utility
    using developer0223.Utilities;
    using developer0223.Utilities.Extensions;
    using developer0223.Utilities.CustomClasses;

    public class Test : MonoBehaviour
    {
        private void Start()
        {
            Utility.Add(new int[11, 22, 33]);
        }
    }
}