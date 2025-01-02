using UnityEngine;
using VContainer;

namespace _No_ise.Scripts.Audio
{
    /// <summary>
    /// 音量の同期（他のDIしているAudioSourceのvolumeを同期用クラス）
    /// </summary>
    public class AudioSourceSynchronization : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        [Inject]
        private VolumeData volumeData;

        private void Start()
        {
            audioSource.volume = volumeData.GetVolume();
        }
    }
}
