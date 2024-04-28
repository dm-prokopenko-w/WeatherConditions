using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UISystem
{
    public class LoopScroll : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scroll;
        [SerializeField] private HorizontalLayoutGroup _horizontal;
        [SerializeField] private RectTransform[] _items;

        private bool _isUpdate;
        private bool _isDown;

        private Vector2 _oldVelocity = Vector2.zero;

        private List<Transform> _itemTrs = new();

        public static UnityEvent<Transform> OnScale = new();

        private void Start()
        {
            foreach (var tr in _items)
            {
                _itemTrs.Add(tr.GetChild(0));
            }

            int numItemsToAdd =
                Mathf.CeilToInt(_scroll.viewport.rect.width / (_items[0].rect.width + _horizontal.spacing));

            for (int i = 0; i < numItemsToAdd; i++)
            {
                RectTransform rt = Instantiate(_items[i % _items.Length], _scroll.content);
                rt.SetAsLastSibling();
                _itemTrs.Add(rt.GetChild(0));
            }

            for (int i = 0; i < numItemsToAdd; i++)
            {
                int num = _items.Length - i - 1;

                while (num < 0)
                {
                    num += _items.Length;
                }

                RectTransform rt = Instantiate(_items[num], _scroll.content);
                rt.SetAsFirstSibling();
                _itemTrs.Add(rt.GetChild(0));
            }

            _scroll.horizontalNormalizedPosition = 0.5f;
        }

        private void Update()
        {
            MoveContent();

            if (CheckClickDevice())
            {
                MoveToNearest();
            }
        }

        private void MoveContent()
        {
            if (_isUpdate)
            {
                _isUpdate = false;
                _scroll.velocity = _oldVelocity;
            }

            if (_scroll.content.localPosition.x > 0)
            {
                _oldVelocity = _scroll.velocity;
                _scroll.content.localPosition -=
                    new Vector3(_items.Length * (_items[0].rect.width + _horizontal.spacing), 0f, 0f);
                _isUpdate = true;

                OnScale?.Invoke(GetTransformMinDist());
            }

            if (_scroll.content.localPosition.x < -(_items.Length * (_items[0].rect.width + _horizontal.spacing)))
            {
                _oldVelocity = _scroll.velocity;
                _scroll.content.localPosition +=
                    new Vector3(_items.Length * (_items[0].rect.width + _horizontal.spacing), 0f, 0f);
                _isUpdate = true;
                OnScale?.Invoke(GetTransformMinDist());
            }
        }
        
        private bool CheckClickDevice()
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                if (_isUpdate || Input.touchCount > 0) return false;
            }
            else
            {
                if (_isUpdate) return false;

                if (Input.GetMouseButtonDown(0))
                {
                    _isDown = true;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    _isDown = false;
                }

                if (_isDown) return false;
            }

            return true;
        }

        private void MoveToNearest()
        {
            if (Mathf.Abs(GetTransformMinDist().position.x) > 0.05f)
            {
                OnScale?.Invoke(GetTransformMinDist());

                if (GetTransformMinDist().position.x > 0)
                {
                    _scroll.content.localPosition -=
                        new Vector3(1f, 0f, 0f);
                }

                if (GetTransformMinDist().position.x < 0)
                {
                    _scroll.content.localPosition +=
                        new Vector3(1f, 0f, 0f);
                }
            }
        }

        private Transform GetTransformMinDist()
        {
            Transform min = _itemTrs[0];

            for (int i = 1; i < _itemTrs.Count; i++)
            {
                if (Mathf.Abs(_itemTrs[i].position.x) < Mathf.Abs(min.transform.position.x))
                {
                    min = _itemTrs[i];
                }
            }

            return min;
        }
    }
}