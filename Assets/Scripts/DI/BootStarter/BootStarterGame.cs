using AudioSystem;
using VContainer.Unity;
using VContainer;
using PopupSystem;
using WeatherSystem;

namespace Game
{
    public class BootStarterGame : BootStarter
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<AudioController>(Lifetime.Scoped)
                .As<AudioController, IStartable>();

            base.Configure(builder);
            
            builder.Register<SaveController>(Lifetime.Scoped);

            builder.Register<WeatherController>(Lifetime.Scoped)
                .As<WeatherController, IStartable>();
            builder.Register<PopupController>(Lifetime.Scoped)
                .As<PopupController, IStartable>();

            builder.RegisterComponentInHierarchy<AssetLoader>();
        }
    }
}