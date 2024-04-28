using System.Collections.Generic;
using AudioSystem;
using Core;
using CoroutineSystem;
using Game;
using ItemSystem;
using NetworkSystem;
using Newtonsoft.Json;
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

        private WebRequestController _webRequest = new();
        private ObjectPool<WeatherBtn> _pool;

        private List<WeatherBtn> _cities = new();
        private Transform _activeParent;
        
        public void Start()
        {
            var data = _assetLoader.LoadConfig(WeatherConfigPath) as WeatherConfig;
            
            _pool = new ObjectPool<WeatherBtn>();
            _pool.InitPool(data.Prefab, _itemController.GetTransform(TransformViewID + TransformObject.InactiveWeatherParent));
            
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
        }

        private void LoadRequest(UnityWebRequest  request, WeatherBtn prefab, Transform parent)
        {
            RootObject data = JsonConvert.DeserializeObject<RootObject>(request.downloadHandler.text);

            _coroutineHandler.StartActiveCoroutine(_webRequest.WebRequestTexture(URLImageUrl(data.weather[0].icon), (req) =>
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(req);

                var item = new WeatherRequestItem
                {
                    Name = data.name,
                    Icon = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero),
                    Temp = data.main.temp
                };

                var weatherBtn = _pool.Spawn(prefab, parent);
                weatherBtn.Init(item, () => _pool.Despawn(weatherBtn));
                _cities.Add(weatherBtn);
            }));
        }
    }

    public class WeatherRequestItem
    {
        public string Name;
        public Sprite Icon;
        public float Temp;
    }
    
    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
    }

    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class RootObject
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}

