using System;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WeatherSystem
{
    public class WeatherCard : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _temp;
        [SerializeField] private Button _button;

        public void Init(WeatherRequestItem item, Action onClick)
        {
            _name.text = item.Name;
            _icon.sprite = item.Icon;
           _temp.text = Constants.Temperature(item.Temp);
            
           _button.onClick.AddListener(() => onClick?.Invoke());
        }
    }
}