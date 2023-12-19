using Assets.Scripts.shoping;
using Assets.Scripts.Signals;
using Assets.States;
using DG.Tweening;

using UnityEngine;

namespace Assets.Scripts.States
{
    public class GoToIceCreamShop : IState
    {
        private Customer _customer;
        private Sequence _mySequence;

        public GoToIceCreamShop(Customer customer)
        {
            _customer = customer;
        }

        public void OnEnter()
        {
            ShopNode shopnode = ShopStandEvent.OnGetEmptyCustomerNode();

            _customer.IsMovedOut = false;

            if (shopnode != null)
            {
                _customer.ShopNode = shopnode;
            }

            Debug.Log("enter goto ice cream shop state");

            Transform customerTrans = _customer.transform;

            Vector3 lookDir = _customer.ShopNode.CustomerWaitPos - customerTrans.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            _mySequence = DOTween.Sequence();
            _mySequence.Append(customerTrans.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(customerTrans.DOMove(_customer.ShopNode.CustomerWaitPos, 1f));
            _mySequence.Append(customerTrans.DORotate(new Vector3(0, 180, 0), 0.1f));

            _mySequence.OnComplete(() =>
            {
                _customer.IsKeeperCome = true;
                ShopStandEvent.OnAddcustomer(shopnode, _customer);
            });
        }

        public void OnExit()
        {}

        public void Tick()
        { }
    }
}