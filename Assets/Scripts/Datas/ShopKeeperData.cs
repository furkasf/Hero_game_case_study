using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "ShopKeeperData", menuName = "GameData/ShopKeeperData")]
    public class ShopKeeperData : ScriptableObject
    {
        [SerializeField] private GameObject shopKeeperPrefab;
        [SerializeField] private int maxKeeperCount = 5;

        public GameObject ShopKeeper => shopKeeperPrefab;
        public int MaxKeeperCount => maxKeeperCount;
    }
}