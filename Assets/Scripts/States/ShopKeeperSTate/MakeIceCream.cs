using Assets.States;
using DG.Tweening;
using Entitys;
using Events;
using UnityEngine;
using Upgrades;

namespace States.ShopKeeperSTate
{
    public class MakeIceCream : IState
    {
        private ShopKeeper _shopKeeper;
        private Vector3 _destination;
        private Transform _transform;
        private SpriteRenderer _spriteRenderer;
        private Sequence _mySequence;

        public MakeIceCream(ShopKeeper shopKeeper, Transform transform, SpriteRenderer spriteRenderer)
        {
            _shopKeeper = shopKeeper;
            _transform = transform;
            _spriteRenderer = spriteRenderer;
        }

        public void OnEnter()
        {
            _destination = _shopKeeper.IceCreamMachine.position;
            _shopKeeper.IsAriveIceCreamMachine = false;
            _spriteRenderer.gameObject.SetActive(true);

            float upgradeTime = IceCreamEvent.OnGetManifactureTime(IceCreamType.Chokelate);

            _mySequence = DOTween.Sequence();

            Vector3 lookDir = _destination - _transform.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);
            Vector3 standLookDir;

            _mySequence.Append(_transform.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(_transform.DOMove(_destination, 1f));
            _mySequence.AppendCallback(delegate
            {
                standLookDir = _destination - _transform.position;
                lookRot = Quaternion.LookRotation(standLookDir);
            });
            _mySequence.Append(_transform.DORotate(new Vector3(0 , 180, 0), 0.1f));
            _mySequence.OnComplete(() =>
            {
                _spriteRenderer.material.DOFloat(360, "_Arc1", upgradeTime)
                .OnComplete(() =>
                {
                    _spriteRenderer.gameObject.SetActive(true);
                    _shopKeeper.IceCreameDone = true;
                });
            });
        }

        public void OnExit()
        {
            _spriteRenderer.material.SetFloat("_Arc1", 0);
            _spriteRenderer.gameObject.SetActive(false);
        }

        public void Tick()
        {
        }
    }
}