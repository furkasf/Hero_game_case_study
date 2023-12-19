using Events;
using System.Collections.Generic;
using UnityEngine;

namespace Entitys
{
    public class ShopStand : MonoBehaviour
    {
        //[SerializeField] private List<ShopNode> _nodes;

        private List<ShopNode> _shopNodes = new List<ShopNode>();

        [SerializeField] private Transform[] _customerWaitPos = new Transform[3];
        [SerializeField] private Transform[] _shopKeeperWaitPos = new Transform[3];

        private void OnEnable()
        {
            ShopStandEvent.OnGetAvailableCustomerAtShopNode += GetAvailableCustomerAtShopNode;
            ShopStandEvent.OnGetEmptyCustomerNode += GetEmptyCustomerNode;
            ShopStandEvent.OnAddcustomer += AddCustomer;
        }

        private void OnDisable()
        {
            ShopStandEvent.OnGetAvailableCustomerAtShopNode -= GetAvailableCustomerAtShopNode;
            ShopStandEvent.OnGetEmptyCustomerNode -= GetEmptyCustomerNode;
            ShopStandEvent.OnAddcustomer -= AddCustomer;
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

        private ShopNode GetAvailableCustomerAtShopNode() //herhangi bir nodda customer var mı bekliyor mu
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