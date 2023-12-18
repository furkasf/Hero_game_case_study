using Assets.Scripts.States.ShopKeeperSTate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Signals
{
    public static class ShopStandEvent
    {

        public static Action<Customer> OnAddNewCustomer;
        public static Action<Customer> OnRemoveCustomer;
        public static Action<ShopKeeper> OnAddNewShopKeeper;
        public static Action<ShopKeeper> OnRemoveShopKeeper;
    }
}
