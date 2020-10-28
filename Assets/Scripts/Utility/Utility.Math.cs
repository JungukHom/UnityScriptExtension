namespace developer0223.Utilities
{
    // C#
    using System;

    // Unity
    using UnityEngine;

    public partial class Utility // .Math
    {
        public static Vector2 InterpolateToGridPosition(Vector2 touchPosition)
        {
            float preX = touchPosition.x;
            float preY = touchPosition.y;

            int aftX = Mathf.RoundToInt(preX);
            int aftY = Mathf.RoundToInt(preY);

            return new Vector2(aftX, aftY);
        }
    }
}