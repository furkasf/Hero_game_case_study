using Assets.Scripts.States.ShopKeeperSTate;
using UnityEngine;

namespace Assets.Scripts.shoping
{
    public class ShopNode
    {
        private Customer _customer;
        private ShopKeeper _shopKeeper;

        private Vector3 _customerWaitpos;
        private Vector3 _shopKeperWaitPos;

        public Vector3 CustomerWaitPos => _customerWaitpos;
        public Vector3 ShopKeperWaitPOs => _shopKeperWaitPos;

        public Customer Customer => _customer;
        public ShopKeeper ShopKeeper => _shopKeeper;

        public ShopNode(Vector3 cusWaitPos, Vector3 shopKepWaitPos)
        {
            _customerWaitpos = cusWaitPos;
            _shopKeperWaitPos = shopKepWaitPos;
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null) return;
            _customer = customer;
        }

        public void AddShopKeeper(ShopKeeper shopKeeper)
        {
            if (shopKeeper == null) return;
            _shopKeeper = shopKeeper;
        }

        public bool IsNodeAvailable() => _customer == null;

        public void DeliveryCompleted(ShopNode shopNode)
        {
            if(this != shopNode) return;
            ResetNode();
        }

        public bool IsCustomerWaiting() {

            Debug.Log("*******************");
            Debug.Log(_customer != null);
            Debug.Log(_shopKeeper == null);
            Debug.Log(_customer != null && _shopKeeper == null);
            Debug.Log("*******************");

           return _customer != null && _shopKeeper == null; 
        }

        public void ResetNode()
        {
            _customer = null;
            _shopKeeper = null;
        }
    }
}