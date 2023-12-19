using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Datas
{
    [CreateAssetMenu(fileName = "CustomerData", menuName = "GameData/CustomerData")]
    public class CustomerData : ScriptableObject
    {
        public GameObject Customer;
        public float SpawnRate = 5f;
        public float Timer;
    }
}