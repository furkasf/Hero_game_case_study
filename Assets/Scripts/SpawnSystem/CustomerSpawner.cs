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

        public override void Spawn()
        {
            
        }
    }
}
