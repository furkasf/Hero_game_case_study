using Assets.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.StateMachines;

namespace Assets.Scripts.States
{
    public class ShopComplete : IState
    {
        private Customer _customer;
        private  StateMachine _stateMachine;
      
        public ShopComplete(Customer customer, ref StateMachine stateMachine)
        {
            _customer = customer;
            _stateMachine = stateMachine;
        }
        public void Tick() { }

        public void OnEnter() 
        {
            // call random spawn poin

        }

        public void OnExit() { }

        private void ReturnBackSpawnPoint()
        {
            //move to random Spawn Point
        }

        private void PutBackToPoll()
        {
            //reset the state
            //pull bask object
        }
    }
}
