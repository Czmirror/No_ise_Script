using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

namespace _No_ise.Scripts.UI.Fade
{
    public class FadeUI
    {
        private float initialAlpha;
        private float zeroAlpha = 0;
        private Ease _ease;
        public async UniTask Intialize(CanvasGroup canvasGroup, Ease ease = Ease.Linear)
        {
            _ease = ease;
            initialAlpha = canvasGroup.alpha;
        }

        public void SetAlphaZero(CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 0;
        }
        public async UniTask FadeIn(CanvasGroup canvasGroup, float duration)
        {
            await Alpha(canvasGroup, zeroAlpha, initialAlpha, duration);
        }

        public async UniTask FadeOut(CanvasGroup canvasGroup, float duration)
        {
            await Alpha(canvasGroup, initialAlpha, zeroAlpha, duration);
        }

        private async UniTask Alpha(CanvasGroup canvasGroup, float startValue, float endValue, float duration)
        {
            await LMotion.Create(startValue, endValue, duration)
                .BindToAlpha(canvasGroup)
                .AddTo(canvasGroup.gameObject);
        }
    }
}
