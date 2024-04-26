using ItemSystem;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using static Game.Constants;

namespace UISystem
{
    public class ImageView : MonoBehaviour
    {
        [Inject] private ItemController _itemController;

        [SerializeField] private ImageObject _type;
        [SerializeField] private Image _image;

        [Inject]
        public void Construct()
        {
            _itemController.AddItemUI(ImageViewID + _type, new Item(_image));
        }
    }
}
