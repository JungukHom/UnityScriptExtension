namespace developer0223.Utilities
{
    using UnityEngine;

    public static partial class Utility
    {
        private static readonly float MinValue = 0;
        private static readonly float MaxValue = 255;

        public static Color Normalize255RGB(float r, float g, float b, float a = 255)
        {
            r = Mathf.Clamp(r, MinValue, MaxValue);
            g = Mathf.Clamp(g, MinValue, MaxValue);
            b = Mathf.Clamp(b, MinValue, MaxValue);
            a = Mathf.Clamp(a, MinValue, MaxValue);
            return new Color(r / MaxValue, g / MaxValue, b / MaxValue, a / MaxValue);
        }
    }
}