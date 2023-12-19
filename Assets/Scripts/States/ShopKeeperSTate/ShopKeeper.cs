using Assets.Scripts.shoping;
using Assets.StateMachines;
using Assets.States;
using NaughtyAttributes;
using System;
using UnityEngine;

namespace Assets.Scripts.States.ShopKeeperSTate
{
    public class ShopKeeper : MonoBehaviour
    {
        [SerializeField] private Transform _myTransform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _iceCreamMachine;


        public ShopNode ShopNode { get; set; }

        private StateMachine _stateMachine;

        public float OrderDuration { get; set; }//TODO ScriptableaÇEK
        public float IceCReammakeDur { get; set; }//TODO ScriptableaÇEK
        public Vector3 CustomerWaypoint { get; set; }
        public Vector3 StandPos { get; set; }
        public bool OrderTaken { get; set; }
        public bool IsAriveIceCreamMachine { get; set; }
        public bool IceCreameDone { get; set; }
        public bool DeliveryDone { get; set; }
        public bool IsAvaible { get; set; }
        public Customer Customer { get; set; }
        public Transform MyTransform => _myTransform;
        public Transform IceCreamMachine => _iceCreamMachine;

        private void Start()
        {
            _stateMachine = new StateMachine();

            ShopKeeperWaitOrder waitOrder = new ShopKeeperWaitOrder(this, _myTransform);
            GetOrder getOrder = new GetOrder(this, _myTransform, _spriteRenderer);
            MakeIceCream makeIceCream = new MakeIceCream(this, _myTransform, _spriteRenderer);
            Deliver deliver = new Deliver(this, _myTransform);

            At(waitOrder, getOrder, IsTakeOrder());
            At(getOrder, makeIceCream, IsReachIceCreamMachine());
            At(makeIceCream, deliver, IsIceCreamDone());
            At(deliver, waitOrder, IsDeliveryDone());

            _stateMachine.SetState(waitOrder);

            void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

            Func<bool> IsTakeOrder() => () => ShopNode != null;
            Func<bool> IsReachIceCreamMachine() => () => IsAriveIceCreamMachine;
            Func<bool> IsIceCreamDone() => () => IceCreameDone;
            Func<bool> IsDeliveryDone() => () => DeliveryDone && ShopNode == null;
        }

        private void Update() => _stateMachine.Tick();

        [Button]
        public void LearnHavenode()
        { 

            Debug.Log("shop not exist :" + ShopNode != null);
            Debug.Log("custumer exist :" + ShopNode.Customer == null);
            Debug.Log("shopkeeper exist :" + ShopNode.ShopKeeper != null);
        }
    }
}