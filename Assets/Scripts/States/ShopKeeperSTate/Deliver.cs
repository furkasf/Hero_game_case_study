using Assets.States;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.States.ShopKeeperSTate
{
    public class Deliver : IState
    {
        private ShopKeeper _shopKeeper;
        private Vector3 _destination;
        private Transform _transform;

        private Sequence _mySequence;

        public Deliver(ShopKeeper shopKeeper, Transform transform)
        {
            _shopKeeper = shopKeeper;
            _transform = transform;
        }

        public void OnEnter()
        {

            _mySequence = DOTween.Sequence();

            _destination = _shopKeeper.CustomerWaypoint;

            Vector3 lookDir = _destination - _transform.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            _mySequence.Append(_transform.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(_transform.DOMove(_destination, 1f));
            _mySequence.Append(_transform.DORotate(Vector3.forward, 0.1f));

            _mySequence.OnComplete(() => _shopKeeper.DeliveryDone = true);
        }

        public void OnExit()
        {
            _shopKeeper.OrderTaken = false;
            _shopKeeper.DeliveryDone = false;
            _shopKeeper.IceCreameDone = false;
            _shopKeeper.IsAriveIceCreamMachine = false;
        }

        public void Tick()
        {
        }
    }
}