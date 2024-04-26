using CoroutineSystem;
using ItemSystem;
using VContainer;
using VContainer.Unity;

namespace SceneSystem
{
    public class SceneLoader : IStartable
    {
        [Inject] private ItemController _itemController;
        [Inject] private CoroutineHandler _coroutineHandler;

        public void Start()
        {
            new LoadGameScene(_itemController, _coroutineHandler);
        }
    }
}