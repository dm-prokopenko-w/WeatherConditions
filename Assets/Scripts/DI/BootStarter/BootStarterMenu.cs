using SceneSystem;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class BootStarterMenu : BootStarter
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<SceneLoader>(Lifetime.Scoped)
                .As<SceneLoader, IStartable>();
        }
    }
}