using UnityEngine;
using VContainer;

namespace _No_ise.Scripts.Audio
{
    public class VolumeService
    {
        private VolumeData _volumeData;
        private AudioSource _audioSource;

        [Inject]
        public void Construct(
            VolumeData volumeData,
            AudioSource audioSource
        )
        {
            _volumeData = volumeData;
            _audioSource = audioSource;
        }

        public float GetVolume()
        {
            return _volumeData.GetVolume();
        }

        public void SetVolume(float volume)
        {
            _volumeData.SetVolume(volume);
            _audioSource.volume = volume;
        }
    }
}
