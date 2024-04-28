using UnityEngine;

namespace UISystem
{
    public class ScrollItemView : MonoBehaviour
    {
        [SerializeField] private Transform _scaleChild;

        private float _size = 1.2f;

        private void Start()
        {
            LoopScroll.OnScale.AddListener((tr) =>
            {
                _scaleChild.localScale = tr == _scaleChild ? new Vector3(_size, _size, _size) : Vector3.one;
            });
        }
    }
}