using _No_ise.Scripts.Audio;
using _No_ise.Scripts.PlayTime;
using VContainer;
using VContainer.Unity;

namespace _No_ise.Scripts.LifeScopes
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            // 子のLifetimeScopeに同じDataを引き渡す
            builder.Register<VolumeData>(Lifetime.Singleton);
            builder.Register<PlayTimeData>(Lifetime.Singleton);
        }
    }
}
