using Assets.States;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.States.ShopKeeperSTate
{
    public class WaitOrder : IState
    {
        private ShopKeeper _shopKeeper;
        private Vector3 _startPos;

        public WaitOrder(ShopKeeper shopKeeper, Transform transform)
        {
            _shopKeeper = shopKeeper;
            _startPos = transform.position;
        }

        public void OnEnter()
        {
            _shopKeeper.transform.DOMove(_startPos, 3f);
            _shopKeeper.CustomerWaypoint = new Vector3(2, 1, 4);
            //animations
            //shop manager shoperkeepera musteri atayinca state degiscek
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }
    }
}