using Assets.States;
using DG.Tweening;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.States.ShopKeeperSTate
{
    public class GetOrder : IState
    {
        private ShopKeeper _shopKeeper;
        private Vector3 _destination;
        private Transform _transform;
        private SpriteRenderer _spriteREnderer;

        private Sequence _mySequence;
        private float _orderDuration;

        public GetOrder(ShopKeeper shopKeeper, Transform transform, SpriteRenderer sprite)
        {
            _shopKeeper = shopKeeper;
            _transform = transform;
            _spriteREnderer = sprite;
        }

        public void OnEnter()
        {

           // _shopKeeper.IsAvaible = false;
           

            _mySequence = DOTween.Sequence();

            Debug.Log("enter get order");

            _destination = _shopKeeper.ShopNode.ShopKeperWaitPOs;

            Vector3 lookDir = _destination - _transform.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            _mySequence.Append(_transform.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(_transform.DOMove(_destination, 1f));
            _mySequence.Append(_transform.DORotate(Vector3.forward, 0.1f));
            _mySequence.OnComplete(() =>
            {
                _spriteREnderer.gameObject.SetActive(true);
                _spriteREnderer.material.DOFloat(360, "_Arc1", 2f)// iceCreamd upgraden all
                .OnComplete(() => _shopKeeper.IsAriveIceCreamMachine = true); 
            });
        }

        //private void TakeOrder()
        //{
        //    _spriteREnderer.DOColor(Color.green, _orderDuration)
        //        .OnComplete(() => );
        //}

        public void OnExit()
        {
            _spriteREnderer.material.SetFloat("_Arc1", 0);
            _spriteREnderer.gameObject.SetActive(false);

        }

        public void Tick()
        {
        }
    }
}