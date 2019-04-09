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
            float test = 1.5f;
            Debug.Log(test.ToRoundInteger());
        }
    }
}