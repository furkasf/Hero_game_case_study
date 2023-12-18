using Assets.Scripts.Signals;
using Assets.Scripts.States.ShopKeeperSTate;
using NaughtyAttributes;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Assets.Scripts.shoping
{

    public class ShopStand : MonoBehaviour
    {
        [SerializeField] private List<ShopNode> _nodes;

        [ShowNonSerializedField] private List<Customer> _activeCustomers = new List<Customer>();
        [ShowNonSerializedField] private List<ShopKeeper> _activeShopKeepers = new List<ShopKeeper>();


        private void OnEnable()
        {
            ShopStandEvent.OnAddNewCustomer += AddNewCustumer;
            ShopStandEvent.OnRemoveCustomer += RemoveCustomer;
            ShopStandEvent.OnAddNewShopKeeper += AddNewShopKeeper;
            ShopStandEvent.OnRemoveShopKeeper += RemoveShopKeeper;
        }

        private void OnDisable()
        {
            ShopStandEvent.OnAddNewCustomer -= AddNewCustumer;
            ShopStandEvent.OnRemoveCustomer -= RemoveCustomer;
            ShopStandEvent.OnAddNewShopKeeper -= AddNewShopKeeper;
            ShopStandEvent.OnRemoveShopKeeper -= RemoveShopKeeper;
        }

        private void AddNewCustumer(Customer customer)
        {
            if(!_activeCustomers.Contains(customer))
            {
                Debug.Log("customer listeye eklendi");
                _activeCustomers.Add(customer);
            }
            return;
        }

        private void RemoveCustomer(Customer customer)
        {
            if (_activeCustomers.Contains(customer))
            {
                Debug.Log("customer listed cikarildi");
                _activeCustomers.Remove(customer);
                _activeCustomers.TrimExcess();
            }
            return;
        }

        private void AddNewShopKeeper(ShopKeeper shopKeeper)
        {
            if (!_activeShopKeepers.Contains(shopKeeper))
            {
                Debug.Log("shop keeper listeye eklendi");
                _activeShopKeepers.Add(shopKeeper);
            }
            return;
        }

        private void RemoveShopKeeper(ShopKeeper shopKeeper)
        {
            Debug.Log("shop keeper listeden cikarildi");
            if(_activeShopKeepers.Contains(shopKeeper))
            {
                _activeShopKeepers.Remove(shopKeeper);
                _activeShopKeepers.TrimExcess();
            }
        }

        private void MatchKeeperAndCustomer()
        {
            if (_activeCustomers.Count < 0)
            {
                Debug.Log("there Is not Enouph Cutomer");
                return;
            }

            foreach (var node in _nodes)
            {
                if (!node.CheakNodeIsFull())
                {
                    node._shopKeeperNode = _activeShopKeepers[0].transform;
                }
            }
        }
    }
}