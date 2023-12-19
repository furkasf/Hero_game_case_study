using Assets.Scripts.shoping;
using Assets.Scripts.States;
using Assets.StateMachines;
using Assets.States;
using NaughtyAttributes;
using System;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private GameObject _iceCreamSprite;

    private StateMachine _stateMachine;

    private GoToIceCreamShop _goToIceCreamShop;
    private CustomerWaitOrder _waitOrder;
    private ShopComplete _shopComplete;



    public Transform SpawnPoint; // Sa
    //Take the prop
    public bool IsKeeperCome;
    public float MoveSpeed => _moveSpeed;
    public bool _isGetOrder;
    public bool IsMovedOut { get; set; }
    public ShopNode ShopNode{ get; set; }
    public GameObject IceCreamSprite => _iceCreamSprite;

    private void Start()
    {
        _stateMachine = new StateMachine();

        _goToIceCreamShop = new GoToIceCreamShop(this);
        _waitOrder = new CustomerWaitOrder(this);
        _shopComplete = new ShopComplete(this, ref _stateMachine);


        At(_goToIceCreamShop, _waitOrder, IsReachShop());
        At(_waitOrder, _shopComplete, IsOrderTaken());

        _stateMachine.SetState(_goToIceCreamShop);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> IsReachShop () => () => IsKeeperCome;
        Func<bool> IsOrderTaken() => () => _isGetOrder;
    }

    
    private void Update()
    {
        _stateMachine?.Tick();
    }


    // write funtions which change customer behavior conditions and attach to signals if needed

    [Button]
    public void ReStartStateMachine()
    {
        ShopNode = null;
        IsKeeperCome = false;
        _isGetOrder = false;
        IsMovedOut = false;
        _stateMachine.SetState(_goToIceCreamShop);
    }
    public void DeliveryTaken()
    {
        _isGetOrder = true;
        IsKeeperCome = false;

        ShopNode= null;
    }// bunu shop keeperda manupule et
}