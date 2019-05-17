namespace developer0223.Utilities.Extensions
{
    /// <summary>
    /// Unity UI component extension class.
    /// 
    /// Developer Information
    /// GitHub : https://github.com/jungukhom
    /// Blog : https://developer0223.tistory.com/
    /// </summary>

    // C#
    using System.Linq;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public static class UnityUIComponentExtensions
    {
        #region Canvas (UnityEngine.Canvas)
        /// <summary>
        /// Set canvas's sorting order higher than others.
        /// </summary>
        public static void ViewOnTop(this Canvas canvas)
        {
            Canvas[] canvasArray = GameObject.FindObjectsOfType<Canvas>();
            if (canvasArray.Length >= 1)
            {
                int highestOrder = canvasArray.OrderByDescending(x => x.sortingOrder).ToArray()[0].sortingOrder;
                canvas.sortingOrder = highestOrder + 1;
            }
            else
            {
                canvas.sortingOrder = 0;
            }
        }
        #endregion

        #region CanvasScaler (UnityEngine.UI.CanvasScaler)
        // static readonly variables
        private static readonly int DefaultReferencePixelsPerUnit = 100;

        /// <summary>
        /// Set UI Canvas's scaleMode.
        /// </summary>
        /// <param name="width">Screen X</param>
        /// <param name="height">Screnn Y</param>
        public static void SetDefaultUIScaleMode(this CanvasScaler canvasScaler, int width, int height)
        {
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            canvasScaler.referenceResolution = new Vector2(width, height);
            canvasScaler.referencePixelsPerUnit = DefaultReferencePixelsPerUnit;
        }
        #endregion

        #region Button (UnityEngine.UI.Button)
        /// <summary>
        /// Set Button's text.
        /// </summary>
        /// <param name="text">Text to set in button.</param>
        public static void SetText(this Button button, string text)
        {
            Text _text = button.GetComponentInChildren<Text>();
            if (_text != null)
            {
                _text.text = text;
            }
            else
            {
                Debug.Log($"Cannot rewrite button's text. There is no \"Text\" component in button \"{button.name}\".");
            }
        }
        #endregion

        #region InputField (UnityEngine.UI.InputField)
        /// <summary>
        /// Clear Inputfield
        /// </summary>
        public static void Clear(this InputField inputField)
        {
            inputField.Select();
            inputField.text = string.Empty;
        }
        #endregion
    }
}
