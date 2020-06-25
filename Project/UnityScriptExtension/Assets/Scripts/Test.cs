namespace developer0223
{
    // Unity
    using UnityEngine;

    // Utility
    using developer0223.Utilities;
    using developer0223.Utilities.Behaviours;
    using developer0223.Utilities.Extensions;
    using developer0223.Utilities.CustomClasses;

    public class Test : ExtendedMonoBehaviour
    {
        private void Start()
        {
            PrintCurrentMethod("start");

            MethodA();
            MethodB();
        }

        private void MethodA()
        {
            PrintCurrentMethod("method a");
        }

        private void MethodB()
        {
            PrintCurrentMethod("method b");
        }
    }
}