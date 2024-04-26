using ItemSystem;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using static Game.Constants;

namespace UISystem
{
    public class SliderView : MonoBehaviour
    {
        [Inject] private ItemController _itemController;

        [SerializeField] private SliderObject _type;
        [SerializeField] private Slider _slider;

        [Inject]
        public void Construct()
        {
            _itemController.AddItemUI(SliderViewID + _type, new Item(_slider));
        }
    }
}