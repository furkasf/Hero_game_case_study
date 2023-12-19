using Assets.StateMachines;
using Assets.States;
using States.CustomerState;
using System;
using UnityEngine;

namespace Entitys
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private GameObject _iceCreamSprite;

        private StateMachine _stateMachine;

        private GoToIceCreamShop _goToIceCreamShop;
        private CustomerWaitOrder _waitOrder;
        private ShopComplete _shopComplete;

        public Transform SpawnPoint;
        public bool IsKeeperCome;
        public bool IsGetOrder;
        public bool IsMovedOut { get; set; }
        public ShopNode ShopNode { get; set; }
        public float MoveSpeed => _moveSpeed;
        public GameObject IceCreamSprite => _iceCreamSprite;

        private void Awake()
        {
            _stateMachine = new StateMachine();

            _goToIceCreamShop = new GoToIceCreamShop(this);
            _waitOrder = new CustomerWaitOrder(this);
            _shopComplete = new ShopComplete(this);

            At(_goToIceCreamShop, _waitOrder, IsReachShop());
            At(_waitOrder, _shopComplete, IsOrderTaken());

            void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

            Func<bool> IsReachShop() => () => IsKeeperCome;
            Func<bool> IsOrderTaken() => () => IsGetOrder;
        }

        private void Update()
        {
            _stateMachine?.Tick();
        }

        public void ReStartStateMachine()
        {
            ShopNode = null;
            IsKeeperCome = false;
            IsGetOrder = false;
            IsMovedOut = false;
            _stateMachine.SetState(_goToIceCreamShop);
        }

        public void DeliveryTaken()
        {
            IsGetOrder = true;
            IsKeeperCome = false;

            ShopNode = null;
        }
    }
}