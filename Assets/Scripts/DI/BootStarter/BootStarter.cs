using ItemSystem;
using VContainer.Unity;
using VContainer;
using CoroutineSystem;

namespace Game
{
    public class BootStarter : LifetimeScope
    {
		protected override void Configure(IContainerBuilder builder)
        {            
            builder.Register<ItemController>(Lifetime.Scoped);
            
            builder.RegisterComponentInHierarchy<CoroutineHandler>();
		}       
    }
}