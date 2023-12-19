using Events;
using Assets.States;
using TMPro;
using UnityEngine;
using Entitys;

namespace States.CustomerState
{
    public class CustomerWaitOrder : IState
    {
        private Customer _customer;

        public CustomerWaitOrder(Customer customer)
        {
            _customer = customer;
        }

        public void OnEnter()
        {
            _customer.IceCreamSprite.SetActive(true);   
        }

        public void OnExit()
        {
            _customer.IceCreamSprite.SetActive(false);
        }

        public void Tick()
        {
        }
      
    }
}