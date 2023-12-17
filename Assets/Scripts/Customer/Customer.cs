using Assets.Scripts.States;
using Assets.StateMachines;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private Transform _shopKeeper;
    [SerializeField] private Transform _orderLine;
    // add Ice cream sprite

    private StateMachine _stateMachine;

    public float MoveSpeed => _moveSpeed;
    public Transform ShopKeeper => _shopKeeper;
    public Transform OrderLine => _orderLine;

    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();

        GoToIceCreamShop goToIceCreamShop = new GoToIceCreamShop(this);
        WaitOrder waitOrder = new WaitOrder(this);

        //goto stop
        //wait or idle
        // return to spawn point
        // reset state and return pool
    }
}