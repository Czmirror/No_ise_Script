using _No_ise.Scripts.Message;
using VContainer;
using VContainer.Unity;
using ZeroMessenger.VContainer;

namespace _No_ise.Scripts.LifeScopes
{
    public class MessageLifeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.AddZeroMessenger();
        }
    }
}
