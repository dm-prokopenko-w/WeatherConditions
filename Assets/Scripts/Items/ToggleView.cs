using ItemSystem;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using static Game.Constants;

namespace UISystem
{
    public class ToggleView : MonoBehaviour
    {
        [Inject] private ItemController _itemController;

        [SerializeField] private ToggleObject _type;
        [SerializeField] private Toggle _toggle;

        [Inject]
        public void Construct()
        {
            _itemController.AddItemUI(ToggleViewID + _type, new Item(_toggle));
        }
    }
}