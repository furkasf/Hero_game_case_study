using Events;
using Datas;
using UnityEngine;

namespace Upgrades
{
    public enum IceCreamType
    {
        Vanila,
        Chokelate
    }

    public class IceCreamUpgradeHandler : MonoBehaviour
    {
        [SerializeField] private IceCreamData vanilaData;
        [SerializeField] private IceCreamData chokalete;

        private void Awake()
        {
            vanilaData.ResetUpgrade();
            chokalete.ResetUpgrade();
        }
        private void OnEnable()
        {
            IceCreamEvent.OnGetUpGradeCost += GetUpgradeCost;
            IceCreamEvent.OnGetSellPrice += GetSellPrice;
            IceCreamEvent.OnGetManifactureTime += GetManifactureTime;
            IceCreamEvent.OnCanUpGrade += CanUpgrade;
            IceCreamEvent.OnIncreaseUpgradeCost += IncreaseUpgradeCost;
        }

        private void OnDisable()
        {
            IceCreamEvent.OnGetUpGradeCost -= GetUpgradeCost;
            IceCreamEvent.OnGetSellPrice -= GetSellPrice;
            IceCreamEvent.OnGetManifactureTime -= GetManifactureTime;
            IceCreamEvent.OnCanUpGrade -= CanUpgrade;
            IceCreamEvent.OnIncreaseUpgradeCost -= IncreaseUpgradeCost;
        }

        private int GetUpgradeCost(IceCreamType iceCreamType)
        {
            IceCreamData iceCream = GetIceCreamData(iceCreamType);

            return iceCream.GetUpgradeCost();
        }

        private int GetSellPrice(IceCreamType iceCreamType)
        {
            IceCreamData iceCream = GetIceCreamData(iceCreamType);

            return iceCream.GetSellPrice();
        }

        private float GetManifactureTime(IceCreamType iceCreamType)
        {
            IceCreamData iceCream = GetIceCreamData(iceCreamType);

            return iceCream.GetManufactureTime();
        }

        private bool CanUpgrade(IceCreamType iceCreamType)
        {
            IceCreamData iceCream = GetIceCreamData(iceCreamType);

            return iceCream.CanUpgrade();
        }

        private void IncreaseUpgradeCost(IceCreamType iceCreamType)
        {
            IceCreamData iceCream = GetIceCreamData(iceCreamType);

            iceCream.IncreaseUpGradeCost();
        }

        public IceCreamData GetIceCreamData(IceCreamType iceCreamType)
        {
            switch (iceCreamType)
            {
                case IceCreamType.Vanila:
                    return vanilaData;

                case IceCreamType.Chokelate:
                    return chokalete;

                default: return null;
            }
        }
    }
}