using Assets.Scripts.Datas;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem
{
    public class ShopKeeperSpawner : Spawner
    {
        [SerializeField] private ShopKeeperData data;
        [SerializeField] private List<Transform> spawnPoint;

        private int keeperCount;

        private void Start()
        {
            Spawn();
        }

        [Button]
        public override void Spawn()
        {
            if (keeperCount >= data.MaxKeeperCount) return;
            
            Instantiate(data.ShopKeeper);
            keeperCount++;
        }
    }
}