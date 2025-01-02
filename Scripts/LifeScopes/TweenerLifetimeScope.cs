using _No_ise.Scripts.UI.Tween;
using VContainer;
using VContainer.Unity;

namespace _No_ise.Scripts.LifeScopes
{
    public class TweenerLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<UISizeTweener>(Lifetime.Singleton);
        }
    }
}
