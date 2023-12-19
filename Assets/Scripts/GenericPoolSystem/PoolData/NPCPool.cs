using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GenericPoolSystem.PoolData
{
    [CreateAssetMenu(fileName = "NPCPool", menuName = "Pool/NPCPool", order = 0)]
    public class NPCPool : AbstractPool<string>
    {
        private NPCPool() 
        {
            Key = "NPCPool";
            InitialSize = 15;
            IsExtensible = true;
        }
    }
}
