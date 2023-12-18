using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    [CreateAssetMenu(fileName = "IceCreamData", menuName = "GameData/IceCream")]
    public class IceCreamDAta : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int[] _sellValue;
        [SerializeField] private int[] _upgradeCost;
        [SerializeField] private float[] _manifactureTime;

        public Sprite Sprite => _sprite;

        public int GetUpgradeCost(int upgradeAmount)
        {
            if(upgradeAmount + 1 < _upgradeCost.Length)
            {
                return _upgradeCost[upgradeAmount + 1];
            }
            return 0;
        }

        public int GetSellPrice(int upgradeAmount) => _sellValue[upgradeAmount];
        public float GetManufactureTime(int upgradeAmount) => _manifactureTime[upgradeAmount];
        public bool CanUpgrade(int upgradeAmount) => upgradeAmount <= _upgradeCost.Length;
    }
}