using Assets.Scripts.shoping;
using Assets.Scripts.States.ShopKeeperSTate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public static class ShopStandEvent
    {
        public static Func<ShopNode> OnGetAvailableCustomerAtShopNode;
        public static Func<ShopNode> OnGetEmptyCustomerNode;
        public static Action<ShopNode, Customer> OnAddcustomer;
        
    }
}
