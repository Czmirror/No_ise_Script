using _No_ise.Scripts.Audio;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _No_ise.Scripts.LifeScopes
{
    public sealed class VolumeSceneGameLifetimeScope : LifetimeScope
    {
        [SerializeField] private AudioSource audioSource;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<VolumeService>(Lifetime.Singleton);
            builder.Register<VolumeSceneGameSetter>(Lifetime.Singleton);
            builder.RegisterEntryPoint<VolumeSceneGameSetter>();
            builder.RegisterInstance(audioSource);
        }
    }
}
