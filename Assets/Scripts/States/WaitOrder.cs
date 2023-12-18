using Assets.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class WaitOrder : IState
    {
        private Customer _customer;

        public WaitOrder(Customer customer)
        {
            _customer = customer;
        }
        public void OnEnter()
        {
            Debug.Log("enter wait order state");
            //enter idle animation
            //open ice CreamSprite
        }

        public void OnExit()
        {
            Debug.Log("exit wait order state");

        }

        public void Tick()
        {
            
        }
    }
}
