using Cysharp.Threading.Tasks;
using UnityEngine;
using LitMotion;
using LitMotion.Extensions;

namespace _No_ise.Scripts.UI.Tween
{
    public class UISizeTweener
    {
        private Vector2 _initialSize;
        private Vector2 _zeroSize = new Vector2(0, 0);
        private Vector2 _horizontalSize = new Vector2(0, 1);
        private Vector2 _verticalSize = new Vector2(1, 0);
        private float _duration;
        private Ease _ease;

        public void Initialize(RectTransform rectTransform, Ease ease = Ease.Linear)
        {
            _initialSize = rectTransform.sizeDelta;
        }

        public void SetZeroSizeUI(RectTransform rectTransform)
        {
            rectTransform.sizeDelta = _zeroSize;
        }

        public async UniTask RestoreSize(RectTransform rectTransform, float duration)
        {
            await SizeDelta(rectTransform, _zeroSize, _initialSize, duration);
        }

        public async UniTask ReductionSize(RectTransform rectTransform, float duration)
        {
            await SizeDelta(rectTransform, _initialSize, _zeroSize, duration);
        }

        private async UniTask SizeDelta(RectTransform rectTransform, Vector2 startValue, Vector2 endValue, float duration)
        {
            await LMotion.Create(startValue, endValue, duration)
                .WithEase(_ease)
                .BindToSizeDelta(rectTransform)
                .AddTo(rectTransform.gameObject);
        }
    }
}
