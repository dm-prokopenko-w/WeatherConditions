using System.Collections.Generic;
using ItemSystem;
using UnityEngine.Events;
using VContainer;
using VContainer.Unity;
using static Game.Constants;

namespace PopupSystem
{
	public class PopupController : IStartable
    {
		[Inject] private ItemController _itemController;

		public UnityEvent<string, bool> OnActivePopup = new ();
		
		private Dictionary<string, PopupView> _popups = new ();
		private string _idCurrentPopup = "";
		
		public void Start()
		{
			_itemController.SetAction(ActivePopupID + true, ShowPopup);
			_itemController.SetAction(ActivePopupID + false, (_) => HideCurrentPopup());
		}

		public void AddPopupView(string id, PopupView popupView) => _popups.Add(id, popupView);

		public void ShowPopup(string id)
		{
			if (!_idCurrentPopup.Equals(id)) HideCurrentPopup();
			
			_idCurrentPopup = id;
			if (_popups.TryGetValue(_idCurrentPopup, out PopupView popup))
			{
				OnActivePopup?.Invoke(_idCurrentPopup, true);
				popup.GetAnimator().Play(ShowKey);
			}
		}

		private void HideCurrentPopup()
		{
			if (_popups.TryGetValue(_idCurrentPopup, out PopupView popup))
			{
				OnActivePopup?.Invoke(_idCurrentPopup, false);
				popup.GetAnimator().Play(HideKey);
			}
		}
	}
}