using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class LoopScroll : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scroll;
        [SerializeField] private HorizontalLayoutGroup _horizontal;
        [SerializeField] private RectTransform[] _items;

        private void Start()
        {
            int numItemsToAdd =
                Mathf.CeilToInt(_scroll.viewport.rect.width / (_items[0].rect.width + _horizontal.spacing));

            for (int i = 0; i < numItemsToAdd; i++)
            {
                RectTransform rt = Instantiate(_items[i % _items.Length], _scroll.content);
                rt.SetAsLastSibling();
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
            }

            _scroll.horizontalNormalizedPosition = 0.5f;

            _scroll.onValueChanged.AddListener((value) =>
            {
                if (_scroll.content.localPosition.x > 0)
                {
                    _scroll.content.localPosition -=
                        new Vector3(_items.Length * (_items[0].rect.width + _horizontal.spacing), 0f, 0f);
                }

                if (_scroll.content.localPosition.x < -(_items.Length * (_items[0].rect.width + _horizontal.spacing)))
                {
                    _scroll.content.localPosition +=
                        new Vector3(_items.Length * (_items[0].rect.width + _horizontal.spacing), 0f, 0f);
                }
            });
        }
        
        private IEnumerator EndMove()
        {
            /*
            do
            {
                yield return new WaitForSeconds(0.1f);
                var value = Random.Range(0, 0.1f);
                img.fillAmount += value;
            } while (img.fillAmount != 1);
*/
            yield return new WaitForSeconds(0.5f);
            
        }

    }
}