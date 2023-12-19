using Assets.Scripts.Signals;
using Assets.States;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.States
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
            Debug.Log("enter wait order state");
            _customer.IceCreamSprite.SetActive(true);   
        }

        public void OnExit()
        {
            _customer.IceCreamSprite.SetActive(false);
            Debug.Log("exit wait order state");
        }

        public void Tick()
        {
        }
      
    }
}