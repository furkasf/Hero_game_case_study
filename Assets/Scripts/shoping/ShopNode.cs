using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.shoping
{
    public class ShopNode
    {

        public Transform _customerNode;
        public Transform _shopKeeperNode;


        public bool CheakNodeIsFull()
        {
            if(_shopKeeperNode == null && _customerNode == null)
            {
                return false;
            }
            return true;
        }

        public void FillNodes(Transform customer, Transform shopKeeper)
        {
            _customerNode = customer;
            _shopKeeperNode = shopKeeper;
        }
    }
}
