﻿namespace developer0223.Tools
{
    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class FpsDisplayer : MonoBehaviour
    {
        // private static readonly variables
        private static readonly string Path = "FPSDisplayer";

        // public variables to edit at editor
        public Color fpsTextColor = Color.green;

        // Cached Components
        public Text fpsText;

        // private variables
        private int fontSize = 30;
        private DisplayPosition displayPosition = DisplayPosition.UpperLeft;

        // private enums
        private enum ChildIndex
        {
            FpsText
        };

        public static FpsDisplayer Create(int fontSize = 30, DisplayPosition position = DisplayPosition.UpperLeft)
        {
            FpsDisplayer script = FindObjectOfType<FpsDisplayer>();
            if (script != null)
            {
                return script;
            }

            GameObject prefab = Resources.Load(Path) as GameObject;
            if (prefab == null)
            {
                Debug.LogWarning("Cannot create FPSDisplayer. Check all files are valid.");
                return null;
            }

            prefab = Instantiate(prefab);
            script = prefab.GetComponent<FpsDisplayer>();
            if (script == null)
            {
                Debug.LogWarning("FpsDisplayer component doesn't exist. Add FpsDisplayer component at prefab object.");
                script = prefab.AddComponent<FpsDisplayer>();
            }

            script.fontSize = fontSize;
            script.displayPosition = position;

            return script;
        }

        private void Start()
        {
            InitializeWithData();
        }

        private void Update()
        {
            fpsText.text = $"{GetFramePerSecond()} FPS";
        }

        public void SetFontSize(int fontSize)
        {
            fpsText.fontSize = fontSize;
        }

        public void SetTextColor(Color color)
        {
            fpsText.color = color;
        }

        public void SetDisplayPosition(DisplayPosition displayPosition)
        {
            fpsText.alignment = (TextAnchor)displayPosition;

            RectTransform rectTransform = fpsText.GetComponent<RectTransform>();
            rectTransform.anchorMin = GetVector2WithDisplayPosition(displayPosition);
            rectTransform.anchorMax = GetVector2WithDisplayPosition(displayPosition);
            rectTransform.pivot = GetVector2WithDisplayPosition(displayPosition);
        }

        private void InitializeWithData()
        {
            fpsText = transform.GetChild((int)ChildIndex.FpsText).GetComponent<Text>();

            SetFontSize(fontSize);
            SetTextColor(fpsTextColor);
            SetDisplayPosition(displayPosition);
        }

        private int GetFramePerSecond()
        {
            return (int)(1 / Time.deltaTime);
        }

        private Vector2 GetVector2WithDisplayPosition(DisplayPosition position)
        {
            Vector2 result = Vector2.zero;

            switch (position)
            {
                case DisplayPosition.UpperLeft:
                    result = new Vector2(0, 1);
                    break;

                case DisplayPosition.UpperCenter:
                    result = new Vector2(0.5f, 1);
                    break;

                case DisplayPosition.UpperRight:
                    result = new Vector2(1, 1);
                    break;

                case DisplayPosition.MiddleLeft:
                    result = new Vector2(0, 0.5f);
                    break;

                case DisplayPosition.MiddleCenter:
                    result = new Vector2(0.5f, 0.5f);
                    break;             

                case DisplayPosition.MiddleRight:
                    result = new Vector2(1, 0.5f);
                    break;

                case DisplayPosition.LowerLeft:
                    result = new Vector2(0, 0);
                    break;

                case DisplayPosition.LowerCenter:
                    result = new Vector2(0.5f, 0);
                    break;

                case DisplayPosition.LowerRight:
                    result = new Vector2(1, 0);
                    break;
            }

            return result;
        }
    }
}