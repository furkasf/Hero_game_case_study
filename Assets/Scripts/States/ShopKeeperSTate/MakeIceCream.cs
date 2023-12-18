using Assets.States;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.States.ShopKeeperSTate
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

        public void OnExit()
        {
            _spriteRenderer.material.SetFloat("_Arc1", 0);
            _spriteRenderer.gameObject.SetActive(false);
        }

        public void OnEnter()
        {
            _spriteRenderer.gameObject.SetActive(true);

            _destination = _shopKeeper.StandPos;

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
            _mySequence.Append(_transform.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.OnComplete(() =>
            {
                _spriteRenderer.material.DOFloat(360, "_Arc1", 5f)
                .OnComplete(() =>
                {
                    _spriteRenderer.material.SetFloat("_Arc1", 0);
                    _shopKeeper.IceCreameDone = true;
                });
            });
        }

        public void Tick()
        {
        }
    }
}