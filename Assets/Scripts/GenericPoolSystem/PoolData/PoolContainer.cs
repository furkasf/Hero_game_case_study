using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericPoolSystem.PoolData
{
    [CreateAssetMenu(fileName = "PoolContainer", menuName = "Pool/PoolContainer", order = 0)]
    public class PoolContainer : ScriptableObject
    {
        public List<AbstractPool<string>> Pools;
    }
}