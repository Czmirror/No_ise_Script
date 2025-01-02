namespace _No_ise.Scripts.Audio
{
    public class VolumeData
    {
        private float Volume { get; set; } = 1f;

        public float GetVolume()
        {
            return Volume;
        }

        public void SetVolume(float volume)
        {
            Volume = volume;
        }
    }
}
