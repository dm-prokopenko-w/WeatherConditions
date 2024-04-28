using ItemSystem;
using UnityEngine;
using VContainer;
using static Game.Constants;

namespace LevelsSystem
{
    public class TransformView : MonoBehaviour
    {
        [Inject] private ItemController _itemController;
        
        [SerializeField] private TransformObject _type;
        [SerializeField] private Transform _tr;

        [Inject]
        public void Construct()
        {
            if (_tr == null) _tr = transform;
            _itemController.AddItemUI(TransformViewID + _type, new Item(_tr));
        }
    } 
}
