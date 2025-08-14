using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Core
{
    public abstract class PopupViewBase : MonoBehaviour, IShowableView
    {
        public event Action CloseRequest;

        [SerializeField] private CanvasGroup _mainGroup;
        [SerializeField] private Image _aniclicker;
        [SerializeField] private Transform _body;

        private Tween _currentAnimation;

        private void Awake()
        {
            _mainGroup.alpha = 0;
        }

        public void OnCloseButtonClicked() => CloseRequest?.Invoke();

        public Tween Show()
        {
            KillCurrentAnimation();

            OnPreShow();

            _mainGroup.alpha = 1;

            Sequence animation = DOTween.Sequence();

            animation
                .Append(_aniclicker.material
                    .DOFade(0.75f, 0.2f)
                    .From(0))
                .Join(_body
                    .DOScale(1, 0.5f)
                    .From(0)
                    .SetEase(Ease.OutBack));

            animation.OnComplete(OnPostShow);

            return _currentAnimation = animation;
            // return _currentAnimation;
        }

        public Tween Hide()
        {
            KillCurrentAnimation();

            OnPreHide();

            _mainGroup.alpha = 0;

            OnPostHide();

            return _currentAnimation;
        }

        protected virtual void OnPostShow() { }

        protected virtual void OnPreShow() { }

        protected virtual void OnPostHide() { }

        protected virtual void OnPreHide() { }

        private void OnDestroy() => KillCurrentAnimation();

        private void KillCurrentAnimation()
        {
            if (_currentAnimation != null)
                _currentAnimation.Kill();
        }
    }
}
