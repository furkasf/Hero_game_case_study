using Assets.Scripts.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem
{
    public class CustomerSpawner : Spawner
    {
        [SerializeField] private CustomerData data;
        [SerializeField] private List<Transform> wayPoints;

        private int _listCount;
        private void Awake()
        {
            _listCount = wayPoints.Count;
        }
        public override void Spawn()
        {
            
        }

        private Transform GetRandomWayPoint() => wayPoints[UnityEngine.Random.Range(0, _listCount)];
        private void OnEnable()
        {
            SpawnSignals.OnGetSpawnPoint += GetRandomWayPoint;
        }

        private void OnDisable()
        {
            SpawnSignals.OnGetSpawnPoint -= GetRandomWayPoint;
        }
    }
}
