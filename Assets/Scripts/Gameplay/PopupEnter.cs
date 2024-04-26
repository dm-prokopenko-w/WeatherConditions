using ItemSystem;
using UnityEngine;
using VContainer;
using static Game.Constants;

namespace PopupSystem
{
    public class PopupEnter : MonoBehaviour
    {
        [Inject] private ItemController _itemController;
        [Inject] private PopupController _popupController;

        [Inject]
        public void Construct()
        {
            _popupController.ShowPopup(PopupsID.Enter.ToString());
        }

        private void Start()
        {
            _itemController.SetAction(ButtonViewID + ButtonObject.Linkedin, () =>
            {
                Application.OpenURL(LinkedinURL);
            });
        }
    }
}
