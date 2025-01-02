using R3;
using UnityEngine;

namespace _No_ise.Scripts.Gimmick
{
    public class ClockAudioSource : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private ClockDisplay clockDisplay;

        private void Start()
        {
            clockDisplay.IsRunning.Where(x => !x).Subscribe(_ => StopSound());
        }

        private void StopSound()
        {
            audioSource.Stop();
        }
    }
}
