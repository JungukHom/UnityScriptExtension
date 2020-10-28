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

    public class RootCanvasBehaviour : ExtendedMonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void CacheComponents()
        {
            base.CacheComponents();
        }

        private void OnCreated()
        {
            // TODO : 화면 크기를 가져와 해상도 조절
        }
    }
}