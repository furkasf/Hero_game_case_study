using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GenericPoolSystem.PoolData
{
    [CreateAssetMenu(fileName = "CustomerPool", menuName = "Pool/CustomerPool")]
    public class CustomerPool : AbstractPool<string>
    {
        private CustomerPool()
        {
            Key = "Customer";
            InitialSize = 10;
            IsExtensible = true;
        }
    }
}
