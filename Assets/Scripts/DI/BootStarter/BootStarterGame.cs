using System;
using AudioSystem;
using LevelsSystem;
using GameplaySystem;
using PlayerSystem;
using ItemSystem;
using VContainer.Unity;
using VContainer;
using BattleSystem;
using EnemySystem;
using PopupSystem;
using VFXSystem;

namespace Game
{
    public class BootStarterGame : BootStarter
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<SaveController>(Lifetime.Scoped);

            builder.Register<PopupController>(Lifetime.Scoped)
                .As<PopupController, IStartable>();
            builder.Register<AudioController>(Lifetime.Scoped)
                .As<AudioController, IStartable>();

/*
            builder.Register<BattleController>(Lifetime.Scoped);
            builder.Register<GameplayController>(Lifetime.Scoped)
                .As<GameplayController, IStartable>();
            builder.Register<VFXController>(Lifetime.Scoped)
                .As<VFXController, IStartable>();
            builder.Register<LevelsController>(Lifetime.Scoped)
                .As<LevelsController, IStartable, IDisposable, ITickable>();
            builder.Register<EnemyController>(Lifetime.Scoped)
                .As<EnemyController, IStartable, IDisposable, ITickable>();
            builder.Register<PlayerController>(Lifetime.Scoped)
                .As<PlayerController, IStartable, IDisposable, ITickable>();
            */

            builder.RegisterComponentInHierarchy<AssetLoader>();
        }
    }
}