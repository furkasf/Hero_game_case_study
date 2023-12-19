using Assets.States;
using DG.Tweening;
using Entitys;
using Events;
using GenericPoolSystem;
using UnityEngine;

namespace States.CustomerState
{
    public class ShopComplete : IState
    {
        private Customer _customer;
        private Transform _spawnPoint;
        private Sequence _mySequence;

        public ShopComplete(Customer customer)
        {
            _customer = customer;
        }

        public void OnEnter()
        {
            _spawnPoint = _customer.SpawnPoint;
            Transform customerTrans = _customer.transform;

            IceCreamEvent.OnSellIceCream?.Invoke();

            Vector3 lookDir = _spawnPoint.position - customerTrans.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            _mySequence = DOTween.Sequence();
            _mySequence.Append(customerTrans.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(customerTrans.DOMove(_spawnPoint.position, _customer.MoveSpeed));
            _mySequence.Append(customerTrans.DORotate(new Vector3(0, 180, 0), 0.1f));

            _mySequence.OnComplete(() => ReturnBackSpawnPoint());
        }

        public void OnExit()
        { }

        public void Tick()
        { }

        private void ReturnBackSpawnPoint()
        {
            _customer.transform.DOMove(_customer.SpawnPoint.position, _customer.MoveSpeed)
                .OnComplete(() =>
                {
                    PoolSignals.onPutObjectBackToPool(_customer.gameObject, "Customer");
                    if (!ShopStandEvent.OnIsAllNodesFull())
                    {
                        SpawnEvent.OnSpawn();
                    }
                }
                );
        }
    }
}