using ItemSystem;
using PopupSystem;
using UnityEngine;
using UnityEngine.Events;
using VContainer;
using VContainer.Unity;
using static Game.Constants;

namespace UISystem
{
    public class GameSceneUIController : IStartable
    {
        [Inject] private ItemController _itemController;
        [Inject] private PopupController _popupController;

        public UnityEvent OnResetWindow = new();
        
        [Inject]
        public void Construct()
        {
            _popupController.ShowPopup(PopupsID.Enter.ToString());
        }

        public void Start()
        {
            _itemController.SetAction(ButtonViewID + ButtonObject.Linkedin, () =>
            {
                Application.OpenURL(LinkedinURL);
            });
            _itemController.SetAction(ButtonViewID + ButtonObject.Quit, () =>
            {
                Application.Quit();
            });
            _itemController.SetAction(ButtonViewID + ButtonObject.ResetWindow, () =>
            {
                OnResetWindow?.Invoke();
            });
        }
    }
}
