namespace developer0223.Utilities
{
    /// <summary>
    /// Unity Color extension class.
    /// 
    /// Developer Information
    /// GitHub : https://github.com/jungukhom
    /// Blog : https://developer0223.tistory.com/
    /// </summary>

    // C#
    using System;

    // Unity
    using UnityEngine;

    public class IntentHolder : MonoBehaviour
    {
        private static readonly string INTENT_BGM_VOLUME_NAME = "Volume_BGM";
        private static readonly string INTENT_EFFECT_VOLUME_NAME = "Volume_Effect";

        private void Awake()
        { 
            GetDataFromMainApplicationIntent();
        }

        // 메인앱에서 실행되었을 때, 설정된 BGM, Effect 볼륨 크기를 가져옴
        private void GetDataFromMainApplicationIntent()
        {
            try
            {
                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");

                float bgmVolume = intent.Call<float>("getFloatExtra", INTENT_BGM_VOLUME_NAME, 0.5f);
                float effectVolume = intent.Call<float>("getFloatExtra", INTENT_EFFECT_VOLUME_NAME, 0.5f);

                ApplyVolumeData(bgmVolume, effectVolume);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        // SoundManager에 볼륨 세팅
        private void ApplyVolumeData(float bgmVolume, float effectVolume)
        {
            SoundManager soundManager = SoundManager.GetOrCreate();
            soundManager.SetBGMVolume(bgmVolume);
            soundManager.SetEffectVolume(effectVolume);
        }
    }
}
