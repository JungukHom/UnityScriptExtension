namespace developer0223.Utilities.Behaviours
{
    /// <summary>
    /// UnityEngine.MonoBehaviour extend class for Unity Engine.
    /// 
    /// Developer Information
    /// GitHub : https://github.com/jungukhom
    /// Blog : https://developer0223.tistory.com/
    /// </summary>

    // C#
    using System.Linq;
    using System.Diagnostics;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // Utility
    using Extensions;
    using Exceptions;

    public abstract class ExtendedMonoBehaviour : MonoBehaviour
    {
        // Cached Components
        [HideInInspector]
        new public Transform transform = null;

        protected virtual void Awake()
        {
            CacheComponents();
        }

        /// <summary>
        /// Cach Components
        /// </summary>
        protected virtual void CacheComponents()
        {
            transform = GetComponent<Transform>();
        }

        /// <summary>
        /// Do Nothing
        /// </summary>
        protected static void DoNothing() { }

        /// <summary>
        /// Find Component with Gameobject nmae.
        /// </summary>
        /// <typeparam name="T">New component.</typeparam>
        /// <param name="sceneObjectName">Scene object name.</param>
        /// <param name="createGameObject">Create new scene object if object doesn't exist.</param>
        /// <param name="addComponent">Add new component if object doesn't have component.</param>
        protected T GetComponentAt<T>(string sceneObjectName, bool createGameObject = false, bool addComponent = false) where T : Component
        {
            GameObject sceneObject = GameObject.Find(sceneObjectName);
            if (sceneObject.IsNull())
            {
                if (createGameObject == true)
                {
                    sceneObject = new GameObject(sceneObjectName);
                }
                else
                {
                    throw new CannotFindException($"Object doesn't exist.\nsceneObjectName : {sceneObjectName}");
                }
            }

            T component;
            component = sceneObject.GetComponent<T>();
            if (component.IsNull())
            {
                if (addComponent)
                {
                    sceneObject.AddComponent<T>();
                }
                else
                {
                    throw new CannotFindException($"Component doesn't exist.\ncomponentName : {component.GetType().ToString()}");
                }
            }

            return component;
        }

        /// <summary>
        /// Find Component in GameObject.
        /// </summary>
        /// <typeparam name="T">New component.</typeparam>
        /// <param name="sceneObject">Scene object.</param>
        /// <param name="newObjectName">Create new scene object if object doesn't exist.</param>
        /// <param name="createGameObject">Create Gameobject if object does'nt exist.</param>
        /// <param name="addComponent">Add new component if object doesn't have component.</param>
        protected T GetComponentAt<T>(GameObject sceneObject, string newObjectName = "GameObject",
                bool createGameObject = false, bool addComponent = false) where T : Component
        {
            if (sceneObject.IsNull())
            {
                if (createGameObject == true)
                {
                    sceneObject = new GameObject(newObjectName);
                }
                else
                {
                    throw new CannotFindException($"Object doesn't exist.\nsceneObjectName : {sceneObject}");
                }
            }

            T component;
            component = sceneObject.GetComponent<T>();
            if (component.IsNull())
            {
                if (addComponent)
                {
                    sceneObject.AddComponent<T>();
                }
                else
                {
                    throw new CannotFindException($"Component doesn't exist.\ncomponentName : {component.GetType().ToString()}");
                }
            }

            return component;
        }

        /// <summary>
        /// Find Components with Gameobject nmae.
        /// </summary>
        /// <param name="sceneObjectName">Scene object name.</param>
        /// <param name="createGameObject">Create new scene object if object doesn't exist.</param>
        /// <param name="addComponent">Add new component if object doesn't have component.</param>
        protected List<T> GetComponentsAt<T>(string sceneObjectName) where T : Component
        {
            GameObject sceneObject = GameObject.Find(sceneObjectName);
            if (sceneObject.IsNull())
            {
                throw new CannotFindException($"Object doesn't exist.\nsceneObjectName : {sceneObjectName}");
            }

            List<T> components;
            components = sceneObject.GetComponentsInChildren<T>().ToList();
            if (components.IsNull())
            {
                throw new CannotFindException($"Component doesn't exist.\ncomponentName : {components.GetType().ToString()}");
            }

            return components;
        }

        /// <summary>
        /// Find Components in GameObject.
        /// </summary>
        /// <param name="sceneObject">Scene object.</param>
        protected List<T> GetComponentsAt<T>(GameObject sceneObject) where T : Component
        {
            if (sceneObject.IsNull())
            {
                throw new CannotFindException($"Object doesn't exist.\nsceneObjectName : {sceneObject}");
            }

            List<T> components;
            components = sceneObject.GetComponentsInChildren<T>().ToList();
            if (components.IsNull())
            {
                throw new CannotFindException($"Component doesn't exist.\ncomponentName : {components.GetType().ToString()}");
            }

            return components;
        }

        /// <summary>
        /// Log Caller's Method Name
        /// </summary>
        protected void PrintCurrentMethod(string message = "")
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            string className = stackFrame.GetMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
            UnityEngine.Debug.Log($"{className}.{methodName}() : {message}");
        }
    }
}
