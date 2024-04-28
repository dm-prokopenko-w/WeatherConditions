using AudioSystem;
using VContainer.Unity;
using VContainer;
using PopupSystem;
using UISystem;
using WeatherSystem;

namespace Game
{
    public class BootStarterGame : BootStarter
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<AssetLoader>();

            builder.Register<AudioController>(Lifetime.Scoped)
                .As<AudioController, IStartable>();
            builder.Register<WeatherController>(Lifetime.Scoped)
                .As<WeatherController, IStartable>();
            builder.Register<PopupController>(Lifetime.Scoped)
                .As<PopupController, IStartable>();
            builder.Register<GameSceneUIController>(Lifetime.Scoped)
                .As<GameSceneUIController, IStartable>();

            builder.Register<SaveController>(Lifetime.Scoped);

            base.Configure(builder);
        }
    }
}