using _No_ise.Scripts.PlayTime;
using VContainer;
using VContainer.Unity;

namespace _No_ise.Scripts.LifeScopes
{
    public class PlayTimeLifeScope: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<PlayTimeUpdater>(Lifetime.Singleton);
            builder.RegisterEntryPoint<PlayTimeUpdater>();
        }
    }
}
