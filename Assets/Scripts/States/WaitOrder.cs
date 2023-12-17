using Assets.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //enter idle animation
           //open ice CreamSprite
        }

        public void OnExit(){}

        public void Tick(){}
    }
}
