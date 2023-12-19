using Entitys;
using System;

namespace Events
{
    public static class ShopStandEvent
    {
        public static Func<ShopNode> OnGetAvailableCustomerAtShopNode;
        public static Func<ShopNode> OnGetEmptyCustomerNode;
        public static Action<ShopNode, Customer> OnAddcustomer;
    }
}