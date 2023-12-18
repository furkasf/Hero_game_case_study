using Assets.States;
using DG.Tweening;

using UnityEngine;

namespace Assets.Scripts.States
{
    public class GoToIceCreamShop : IState
    {
        private Customer _customer;
        private Transform _orderLine;
        private Sequence _mySequence;

        public GoToIceCreamShop(Customer customer)
        {
            _customer = customer;
        }

        public void OnEnter()
        {
            Debug.Log("enter goto ice cream shop state");

            _orderLine = _customer.OrderLine; //get this position from shop manager
            var customerTrans = _customer.transform;

            Vector3 lookDir = _orderLine.position - customerTrans.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            _mySequence = DOTween.Sequence();
            _mySequence.Append(customerTrans.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(customerTrans.DOMove(_orderLine.position, 1f));
            _mySequence.Append(customerTrans.DORotate(new Vector3(0, 180, 0), 0.1f));

            _mySequence.OnComplete(() =>
            {
                _customer.IsKeeperCome = true;
                Debug.Log(_customer.IsKeeperCome);
                });// change transition to wait oder
        }

        public void OnExit()
        {
            Debug.Log("exit goto ice cream shop state");

            _orderLine = null;
        }

        public void Tick()
        { }
    }
}