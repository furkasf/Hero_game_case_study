using Assets.Scripts.SpawnSystem;
using Assets.StateMachines;
using Assets.States;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class ShopComplete : IState
    {
        private Customer _customer;
        private StateMachine _stateMachine;
        private Transform _spawnPoint;
        private Sequence _mySequence;
        public ShopComplete(Customer customer, ref StateMachine stateMachine)
        {
            _customer = customer;
            _stateMachine = stateMachine;
        }

        public void Tick()
        { }

        public void OnEnter()
        {
            Debug.Log("enter shop Complate state");

            _spawnPoint = _customer.SpawnPoint; //get this position from shop manager
            var customerTrans = _customer.transform;

            Vector3 lookDir = _spawnPoint.position - customerTrans.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            _mySequence = DOTween.Sequence();
            _mySequence.Append(customerTrans.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(customerTrans.DOMove(_spawnPoint.position, 1f));
            _mySequence.Append(customerTrans.DORotate(Vector3.forward, 0.1f));

            _mySequence.OnComplete(() => { ReturnBackSpawnPoint(); });// change transition to wait oder
        }

        public void OnExit()
        { }

        private void ReturnBackSpawnPoint()
        {
            _customer.transform.DOMove(_customer.SpawnPoint.position, _customer.MoveSpeed)
                .OnComplete(() => 
                {
                   // _customer.ShopNode.ResetNode();
                    //_customer.ShopNode = null;
                    _customer.gameObject.SetActive(false);
                }
                );
        }

     
    }
}