using System.Collections.Generic;
using Core;
using CoroutineSystem;
using Game;
using ItemSystem;
using NetworkSystem;
using Newtonsoft.Json;
using UISystem;
using UnityEngine;
using UnityEngine.Networking;
using VContainer;
using VContainer.Unity;
using static Game.Constants;

namespace WeatherSystem
{
    public class WeatherController : IStartable
    {
        [Inject] private CoroutineHandler _coroutineHandler;
        [Inject] private AssetLoader _assetLoader;
        [Inject] private ItemController _itemController;
        [Inject] private GameSceneUIController _uiController;

        private WebRequestController _webRequest = new();
        private ObjectPool<WeatherCard> _pool;

        private List<WeatherCard> _cities = new();
        private Transform _activeParent;

        public void Start()
        {
            var data = _assetLoader.LoadConfig(WeatherConfigPath) as WeatherConfig;

            _pool = new ObjectPool<WeatherCard>();
            _pool.InitPool(data.Prefab,
                _itemController.GetTransform(TransformViewID + TransformObject.InactiveWeatherParent));

            foreach (var city in data.CityNames)
            {
                _coroutineHandler.StartActiveCoroutine(
                    _webRequest.WebRequestGet(
                        URLWeather(city),
                        (request) => LoadRequest(
                            request,
                            data.Prefab,
                            _itemController.GetTransform(TransformViewID + TransformObject.ActiveWeatherParent))));
            }
            
            _uiController.OnResetWindow.AddListener(ResetWindow);
        }

        private void LoadRequest(UnityWebRequest request, WeatherCard prefab, Transform parent)
        {
            RootObject data = JsonConvert.DeserializeObject<RootObject>(request.downloadHandler.text);

            _coroutineHandler.StartActiveCoroutine(_webRequest.WebRequestTexture(URLImageUrl(data.weather[0].icon),
                (req) =>
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(req);

                    var item = new WeatherRequestItem
                    {
                        Name = data.name,
                        Icon = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero),
                        Temp = data.main.temp
                    };

                    var card = _pool.Spawn(prefab, parent);
                    card.Init(item, () => _pool.Despawn(card));
                    _cities.Add(card);
                }));
        }

        private void ResetWindow()
        {
            foreach (var card in _cities)
            {
                _pool.Despawn(card);
            }
            foreach (var card in _cities)
            {
                _pool.Spawn(card, _itemController.GetTransform(TransformViewID + TransformObject.ActiveWeatherParent));
            }
        }
    }
}