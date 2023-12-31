﻿using Assets.States;
using Entitys;
using DG.Tweening;
using Events;
using UnityEngine;

namespace States.ShopKeeperSTate
{
    public class ShopKeeperWaitOrder : IState
    {
        private ShopKeeper _shopKeeper;
        private Vector3 _startPos;
        private float _timer = 0f;
        private float _checkTime = 2f;

        public ShopKeeperWaitOrder(ShopKeeper shopKeeper, Transform transform)
        {
            _shopKeeper = shopKeeper;
            _startPos = transform.position;
        }

        public void OnEnter()
        {
            if (_shopKeeper.ShopNode != null)
            {
                _shopKeeper.ShopNode.ResetNode(); ;
                _shopKeeper.ShopNode = null;
            }

            _shopKeeper.DeliveryDone = false;
            _shopKeeper.transform.DOMove(_startPos, 3f);
        }

        public void OnExit()
        {
            _timer = 0;
        }

        public void Tick()
        {
            if (_timer < _checkTime)
            {
                _timer += Time.deltaTime;

                if (_timer > _checkTime)
                {
                    ShopNode shopNode = ShopStandEvent.OnGetAvailableCustomerAtShopNode();

                    if (shopNode != null)
                    {
                        _shopKeeper.ShopNode = shopNode;
                    }
                    else
                    {
                        _timer = 0f;
                    }
                }
            }
        }
    }
}