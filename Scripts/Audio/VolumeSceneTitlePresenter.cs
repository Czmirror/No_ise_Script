using VContainer.Unity;

namespace _No_ise.Scripts.Audio
{
    public class VolumeSceneTitlePresenter : IStartable
    {
        readonly VolumeService volumeService;
        readonly VolumeSlider volumeSlider;

        public VolumeSceneTitlePresenter(VolumeService volumeService, VolumeSlider volumeSlider)
        {
            this.volumeService = volumeService;
            this.volumeSlider = volumeSlider;
        }

        void IStartable.Start()
        {
            // スライダーの値をVolumeServiceに渡す
            volumeSlider.slider.onValueChanged.AddListener(volumeService.SetVolume);
        }
    }
}
