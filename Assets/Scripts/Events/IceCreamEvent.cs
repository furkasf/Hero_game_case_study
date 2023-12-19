using System;
using Upgrades;

namespace Events
{
    public static class IceCreamEvent
    {
        public static Func<IceCreamType, int> OnGetUpGradeCost;
        public static Action<IceCreamType> OnIncreaseUpgradeCost;
        public static Func<IceCreamType, bool> OnCanUpGrade;
        public static Func<IceCreamType, float> OnGetManifactureTime;
        public static Func<IceCreamType, int> OnGetSellPrice;

        public static Action OnUpGradeIceCream;
        public static Action OnSellIceCream;
    }
}