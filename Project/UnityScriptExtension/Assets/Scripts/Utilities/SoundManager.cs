namespace developer0223.Utilities
{
    /// <summary>
    /// Unity Color extension class.
    /// 
    /// Developer Information
    /// GitHub : https://github.com/jungukhom
    /// Blog : https://developer0223.tistory.com/
    /// </summary>

    // Unity
    using UnityEngine;

    public class SoundManager : MonoBehaviour
    {
        public AudioSource bgmSource;                      // 배경음악 출력용 오디오소스
        public AudioSource effectSource;                   // 효과음 출력용 오디오소스

        private float bgmVolume = 0.5f;                    // 배경음악 볼륨
        public float BGMVolume                             // 배경음악 볼륨
        {
            get { return bgmVolume; }
            set
            {
                bgmVolume = value;
                bgmSource.volume = value;
            }
        }

        private float effectVolume = 0.5f;                 // 효과음 볼륨
        public float EffectVolume                          // 효과음 볼륨
        {
            get { return effectVolume; }
            set
            {
                effectVolume = value;
                effectSource.volume = value;
            }
        }

        /// <summary>
        /// 씬에 존재하는 SoundManager 반환. 없을 시 새로 생성
        /// </summary>
        /// <returns></returns>
        public static SoundManager GetOrCreate()
        {
            SoundManager soundManager = FindObjectOfType<SoundManager>();
            if (!soundManager)
            {
                GameObject _soundManager = new GameObject(typeof(SoundManager).Name);
                soundManager = _soundManager.AddComponent<SoundManager>();

                GameObject _bgmSource = new GameObject("BGMSource");
                GameObject _effectSource = new GameObject("EffectSource");

                AudioSource _bgmSourceComponent = _bgmSource.AddComponent<AudioSource>();
                AudioSource _effectSourceComponent = _effectSource.AddComponent<AudioSource>();

                _bgmSourceComponent.playOnAwake = false;
                _effectSourceComponent.playOnAwake = false;


                _bgmSource.transform.SetParent(_soundManager.transform);
                _effectSource.transform.SetParent(_soundManager.transform);

                soundManager.bgmSource = _bgmSourceComponent;
                soundManager.effectSource = _effectSourceComponent;
            }

            return soundManager;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            Initialize();
        }

        /// <summary>
        ///  초기설정
        /// </summary>
        private void Initialize()
        {
            bgmSource.volume = BGMVolume;
            effectSource.volume = EffectVolume;
        }

        /// <summary>
        /// 배경음악 볼륨 조절
        /// </summary>
        /// <param name="volume"></param>
        public void SetBGMVolume(float volume)
        {
            BGMVolume = volume;
        }

        /// <summary>
        /// 효과음 볼륨 조절
        /// </summary>
        /// <param name="volume"></param>
        public void SetEffectVolume(float volume)
        {
            EffectVolume = volume;
        }

        /// <summary>
        /// 배경음악 재생
        /// </summary>
        /// <param name="clip">배경음악</param>
        /// <param name="repeat">반복 여부</param>
        public void PlayBGM(AudioClip clip, bool repeat = true)
        {
            bgmSource.clip = clip;
            bgmSource.loop = repeat;
            bgmSource.Play();
        }

        /// <summary>
        /// 배경음악 재생
        /// </summary>
        /// <param name="clip">배경음악</param>
        /// <param name="volume">볼륨</param>
        /// <param name="repeat">반복 여부</param>
        public void PlayBGM(AudioClip clip, float volume, bool repeat = true)
        {
            BGMVolume = volume;

            bgmSource.clip = clip;
            bgmSource.loop = repeat;
            bgmSource.Play();
        }

        /// <summary>
        /// BGM 일시정지
        /// </summary>
        public void PauseBGM()
        {
            bgmSource.Pause();
        }

        /// <summary>
        /// BGM 일시정지 해제
        /// </summary>
        public void ResumeBGM()
        {
            bgmSource.UnPause();
        }

        /// <summary>
        /// BGM 정지
        /// </summary>
        public void StopBGM()
        {
            bgmSource.Stop();
        }

        /// <summary>
        /// 효과음 재생
        /// </summary>
        /// <param name="clip">효과음</param>
        public void PlayEffectSound(AudioClip clip)
        {
            effectSource.PlayOneShot(clip, EffectVolume);
        }

        /// <summary>
        /// 효과음 재생
        /// </summary>
        /// <param name="clip">효과음</param>
        /// <param name="volume">볼륨</param>
        public void PlayEffectSound(AudioClip clip, float volume)
        {
            effectSource.PlayOneShot(clip, volume);
        }
    }
}