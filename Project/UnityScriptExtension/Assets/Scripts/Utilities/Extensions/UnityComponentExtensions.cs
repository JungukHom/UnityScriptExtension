namespace developer0223.Utilities.Extensions
{
    /// <summary>
    /// Unity component's extension class.
    /// 
    /// Developer Information
    /// GitHub : https://github.com/jungukhom
    /// Blog : https://developer0223.tistory.com/
    /// </summary>

    // Unity
    using UnityEngine;

    public static class UnityComponentExtensions
    {
        #region T
        /// <summary>
        /// Check T class is null.
        /// </summary>
        public static bool IsNull<T>(this T @class)
        {
            return @class == null;
        }
        #endregion

        #region Component (UnityEngine.Component)
        /// <summary>
        /// Get root transform component.
        /// </summary>
        public static Transform RootTransform(this Component gameObject)
        {
            return gameObject.transform.root;
        }

        /// <summary>
        /// Get root gameObject.
        /// </summary>
        public static GameObject RootGameObject(this Component gameObject)
        {
            return gameObject.transform.root.gameObject;
        }

        /// <summary>
        /// Destroy root gameObject.
        /// </summary>
        public static void DestroyRootObject(this Component component)
        {
            UnityEngine.Object.Destroy(component.RootGameObject());
        }
        #endregion

        #region GameObject (UnityEngine.GameObject)
        /// <summary>
        /// Check input gameobject is null.
        /// </summary>
        public static bool IsNull(this GameObject gameObject)
        {
            return gameObject == null;
        }

        /// <summary>
        /// Get child object's component at index.
        /// </summary>
        /// <param name="index">Child index.</param>
        public static T GetChildComponentAt<T>(this GameObject gameObject, int index)
        {
            return gameObject.transform.GetChild(index).GetComponent<T>();
        }

        /// <summary>
        /// Destroy all children gameObject.
        /// </summary>
        public static void DestroyAllChildren(this GameObject gameObject)
        {
            if (!gameObject.IsNull())
            {
                Transform transform = gameObject.GetComponent<Transform>();
                for (int i = transform.childCount - 1; i >= 0; i--)
                    Object.Destroy(gameObject.transform.GetChild(i).gameObject);
            }
        }
        #endregion

        #region Transform (UnityEngine.Transform)
        /// <summary>
        /// Get child object's component at index.
        /// </summary>
        /// <param name="index">Child index.</param>
        public static T GetChildComponentAt<T>(this Transform transform, int index)
        {
            return transform.GetChild(index).GetComponent<T>();
        }
        #endregion
    }
}