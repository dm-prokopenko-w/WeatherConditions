using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ItemSystem
{
	public class ItemController
	{
		private Dictionary<string, List<Item>> _items = new ();

		public void AddItemUI(string id, Item item)
		{
			if (_items.TryGetValue(id, out List<Item> items))
			{
				items.Add(item);
			}
			else
			{
				List<Item> newItems = new List<Item> { item };
				_items.Add(id, newItems);
			}
		}
		
		public Transform GetTransform(string id)
		{
			if (_items.TryGetValue(id, out List<Item> items))
			{
				foreach (var item in items)
				{
					if (item.Tr == null) continue;

					return item.Tr;
				}
				return null;
			}

			return null;
		}
		
		public Image GetImage(string id)
		{
			if (_items.TryGetValue(id, out List<Item> items))
			{
				foreach (var item in items)
				{
					if (item.Img == null) continue;

					return item.Img;
				}
				return null;
			}

			return null;
		}
		
		public Slider GetSlider(string id)
		{
			if (_items.TryGetValue(id, out List<Item> items))
			{
				foreach (var item in items)
				{
					if (item.Sld == null) continue;

					return item.Sld;
				}
				return null;
			}

			return null;
		}
		
		public Toggle GetToggle(string id)
		{
			if (_items.TryGetValue(id, out List<Item> items))
			{
				foreach (var item in items)
				{
					if (item.Tgl == null) continue;

					return item.Tgl;
				}
				return null;
			}

			return null;
		}
		
		public void SetAction(string id, UnityAction func)
		{
			if (_items.TryGetValue(id, out List<Item> items))
			{
				foreach (var item in items)
				{
					if (item.Btn == null) continue;
					item.Btn.onClick.AddListener(func);
				}
			}
		}
		
		public void SetActiveBtn(string id, bool value)
		{
			if (_items.TryGetValue(id, out List<Item> items))
			{
				foreach (var item in items)
				{
					if (item.Btn == null) continue;
					item.Btn.gameObject.SetActive(value);
				}
			}
		}
		
		public void SetAction(string id, UnityAction<string> func)
		{
			if (_items.TryGetValue(id, out List<Item> items))
			{
				foreach (var item in items)
				{
					if (item.Btn == null) continue;
					item.Btn.onClick.AddListener(() => func(item.Parm));
				}
			}
		}
	}

	public class Item
	{
		public Button Btn;
		public Transform Tr;
		public TMP_Text TextTMP;
		public string Parm;
		public Animator Anim;
		public Image Img;
		public Slider Sld;
		public Toggle Tgl;

		public Item(Button btn)
		{
			Btn = btn;
		}

		public Item(Image img)
		{
			Img = img;
		}

		public Item(Slider sld)
		{
			Sld = sld;
		}

		public Item(Toggle tgl)
		{
			Tgl = tgl;
		}

		public Item(TMP_Text text)
		{
			TextTMP = text;
		}

		public Item(Transform tr)
		{
			Tr = tr;
		}
		
		public Item(Animator anim)
		{
			Anim = anim;
		}
		
		public Item(Button btn, string parm)
		{
			Btn = btn;
			Parm = parm;
		}
	}
}
