using System.Collections.Generic;
using Game;
using UnityEngine;

namespace WeatherSystem
{
    [CreateAssetMenu(fileName = "WeatherConfig", menuName = "Configs/WeatherConfig", order = 0)]
    public class WeatherConfig : Config
    {
        public WeatherCard Prefab;
        public List<string> CityNames = new()
        {
            "Kyiv",
            "Kharkiv",
            "Lviv ",
            "Dnipro",
            "Sumy",
            "Zhytomyr",
            "Vinnytsia",
            "Chernihiv",
            "Rivne"
        };

    }
}