using Assets.States;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class GoToIceCreamShop : IState
    {
        private Customer _customer;
        private Transform _orderLine;
        public GoToIceCreamShop(Customer customer)
        {
            _customer = customer;
            
        }
        public void OnEnter()
        {
            _orderLine = _customer.OrderLine; //get this position from shop manager
            _customer.transform.DOMove(_orderLine.position, _customer.MoveSpeed);
        }

        public void OnExit()
        {
            _orderLine = null; 
        }

        public void Tick() { }
        
    }
}
