using Events;
using System.Collections.Generic;
using UnityEngine;

namespace Entitys
{
    public class ShopStand : MonoBehaviour
    {

        private List<ShopNode> _shopNodes = new List<ShopNode>();

        [SerializeField] private Transform[] _customerWaitPos = new Transform[3];
        [SerializeField] private Transform[] _shopKeeperWaitPos = new Transform[3];

        private void OnEnable()
        {
            ShopStandEvent.OnGetAvailableCustomerAtShopNode += GetAvailableCustomerAtShopNode;
            ShopStandEvent.OnGetEmptyCustomerNode += GetEmptyCustomerNode;
            ShopStandEvent.OnAddcustomer += AddCustomer;
            ShopStandEvent.OnIsAllNodesFull += IsAllNodesFull;
        }

        private void OnDisable()
        {
            ShopStandEvent.OnGetAvailableCustomerAtShopNode -= GetAvailableCustomerAtShopNode;
            ShopStandEvent.OnGetEmptyCustomerNode -= GetEmptyCustomerNode;
            ShopStandEvent.OnAddcustomer -= AddCustomer;
            ShopStandEvent.OnIsAllNodesFull -= IsAllNodesFull;
        }

        private void Awake()
        {
            for (int i = 0; i < 3; i++)
            {
                ShopNode node = new ShopNode(_customerWaitPos[i].position, _shopKeeperWaitPos[i].position);
                _shopNodes.Add(node);
            }
        }

        private void AddCustomer(ShopNode shopNode, Customer customer)
        {
            shopNode.AddCustomer(customer);
        }

        private ShopNode GetEmptyCustomerNode()
        {
            ShopNode sNode = null;

            foreach (ShopNode node in _shopNodes)
            {
                if (node.IsNodeAvailable())
                {
                    sNode = node;
                }
            }
            return sNode;
        }

        private bool IsAllNodesFull()
        {
            bool isFull = true;

            foreach(ShopNode node in _shopNodes)
            {
                if(node.IsNodeAvailable())
                {
                    isFull = false;
                    break;
                }
            }
            return isFull;
        }

        private ShopNode GetAvailableCustomerAtShopNode() 
        {
            ShopNode sNode = null;

            foreach (ShopNode node in _shopNodes)
            {
                if (node.IsCustomerWaiting())
                {
                    sNode = node;
                    return sNode;
                }
            }

            return sNode;
        }
    }
}