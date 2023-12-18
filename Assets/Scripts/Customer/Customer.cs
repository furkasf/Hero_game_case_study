using Assets.Scripts.States;
using Assets.StateMachines;
using Assets.States;
using System;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private Transform _shopKeeperLine;
    [SerializeField] private Transform _orderLine;
    // add Ice cream sprite

    private StateMachine _stateMachine;

    public Transform SpawnPoint;
    public bool _isGetOrder;
    public float MoveSpeed => _moveSpeed;
    public Transform ShopKeeperLine => _shopKeeperLine;
    public Transform OrderLine => _orderLine;

    public Transform ShopKeeper;

    //test booleand
    public bool IsKeeperCome;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        GoToIceCreamShop goToIceCreamShop = new GoToIceCreamShop(this);
        WaitOrder waitOrder = new WaitOrder(this);
        ShopComplete shopComplete = new ShopComplete(this, ref _stateMachine);

        At(goToIceCreamShop, waitOrder, IsReachShop());
        At(waitOrder, shopComplete, IsOrderTaken());

        _stateMachine.SetState(goToIceCreamShop);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> IsReachShop () => () => IsKeeperCome;
        Func<bool> IsOrderTaken() => () => _isGetOrder;
    }

    private void Update()
    {
        _stateMachine?.Tick();
    }

    // write funtions which change customer behavior conditions and attach to signals if needed

    public void SetOrder(bool isOrder) => _isGetOrder = isOrder;
}