using Events;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Upgrades;

namespace UI
{
    public enum PanelType
    {
        StartPanel, InGamePanel, UpGradePanel
    }

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> panels;
        [SerializeField] private TextMeshProUGUI playerMoney;
        [SerializeField] private TextMeshProUGUI sellPriceText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI upGradeCostText;

        private UIChangePanelCommand _panelCommand;
        private int _money;

        private void Awake()
        {
            _panelCommand = new UIChangePanelCommand(ref panels);
        }

        private void OnEnable()
        {
            IceCreamEvent.OnUpGradeIceCream += UpgradeIceCream;
            IceCreamEvent.OnSellIceCream += SellIceCream;
        }

        private void OnDisable()
        {
            IceCreamEvent.OnUpGradeIceCream -= UpgradeIceCream;
            IceCreamEvent.OnSellIceCream -= SellIceCream;
        }

        public void OpenStartPanel()
        {
            _panelCommand.Execute(PanelType.StartPanel);
        }

        public void OpenInGamePanel()
        {
            _panelCommand.Execute(PanelType.InGamePanel);
            SpawnEvent.OnSpawn();
        }

        public void OpenUpGradePanel()
        {
            _panelCommand.Execute(PanelType.UpGradePanel);

            sellPriceText.text = "Price : " + IceCreamEvent.OnGetSellPrice(IceCreamType.Chokelate);
            timeText.text = "Time : " + IceCreamEvent.OnGetManifactureTime(IceCreamType.Chokelate);
            upGradeCostText.text = "Cost : " + IceCreamEvent.OnGetUpGradeCost(IceCreamType.Chokelate);
        }

        public void SellIceCream()
        {
            _money += IceCreamEvent.OnGetSellPrice(IceCreamType.Chokelate);
            playerMoney.text = "Money : " + _money;
        }

        public void UpgradeIceCream()
        {
            int upgradeCost = IceCreamEvent.OnGetUpGradeCost(IceCreamType.Chokelate);

            if (_money < upgradeCost) return;

            _money -= upgradeCost;

            IceCreamEvent.OnIncreaseUpgradeCost(IceCreamType.Chokelate);

            playerMoney.text = "Money : " + _money;
        }
    }
}