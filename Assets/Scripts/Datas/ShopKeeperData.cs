using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Datas
{ 
    [CreateAssetMenu(fileName = "ShopKeeperData", menuName = "GameData/ShopKeeperData")]
    public class ShopKeeperData : ScriptableObject
    {
        [SerializeField] private GameObject shopKeeperPrefab;
        [SerializeField] private int maxKeeperCount = 5;
        [SerializeField] private float speed = 1f;
        
        

        public GameObject ShopKeeper => shopKeeperPrefab;
        public int MaxKeeperCount => maxKeeperCount;
        public float Speed => speed;
    }
}