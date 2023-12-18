using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public enum IceCreamType
    {
        Vanila,
        Chokelate
    }

    public class IceCreamUpgradeHandler : MonoBehaviour
    {
        private const string VanilaPath = "Resources/IceCreamDatas/Vanilla";
        private const string ChokolatePath = "Resources/IceCreamDatas/Chokolate";

        private IceCreamDAta vanilaData;
        private IceCreamDAta chokalete;

        private void Awake()
        {
            vanilaData = Resources.Load<IceCreamDAta>(VanilaPath);
            chokalete = Resources.Load<IceCreamDAta>(ChokolatePath);
        }

        public IceCreamDAta GetIceCreamData(IceCreamType iceCreamType)
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