using _No_ise.Scripts.Audio;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _No_ise.Scripts.LifeScopes
{
    public class VolumeSceneTitleLifetimeScope : LifetimeScope
    {
        [SerializeField] private VolumeSlider _volumeSlider;
        [SerializeField] private AudioSource audioSource;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<VolumeService>(Lifetime.Singleton);
            builder.Register<VolumeSceneTitlePresenter>(Lifetime.Singleton);
            builder.RegisterEntryPoint<VolumeSceneTitlePresenter>();
            builder.RegisterComponent(_volumeSlider);
            builder.RegisterInstance(audioSource);
        }
    }
}
