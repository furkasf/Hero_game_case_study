using Events;
using GenericPoolSystem;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace Entitys
{
    public class CustomerSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> wayPoints;

        private int _listCount;

        private void Awake()
        {
            _listCount = wayPoints.Count;
        }

        [Button]
        public void Spawn()
        {
            Transform spawnPoint = GetRandomWayPoint();

            GameObject customer = PoolSignals.onGetObjectFormPool("Customer");
            customer.transform.position = spawnPoint.position;

            Customer _customer = customer.GetComponent<Customer>();
            _customer.SpawnPoint = spawnPoint;
            _customer.ReStartStateMachine();
        }

        private Transform GetRandomWayPoint() => wayPoints[UnityEngine.Random.Range(0, _listCount)];

        private void OnEnable()
        {
            SpawnEvent.OnSpawn += Spawn;
        }

        private void OnDisable()
        {
            SpawnEvent.OnSpawn -= Spawn;
        }
    }
}