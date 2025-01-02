using _No_ise.Scripts.UI.Tween;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace _No_ise.Scripts.Effect
{
    public class StageClearEffect : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip audioClip;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private UISizeTweener _uiSizeTweener;
        private float duration = 0.75f;
        private int delay = 1000;

        [Inject]
        public void Construct(UISizeTweener uiSizeTweener)
        {
            _uiSizeTweener = uiSizeTweener;
        }

        private void Awake()
        {
            rectTransform　= GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            Initialize();
        }

        public void Initialize()
        {
            _uiSizeTweener.Initialize(rectTransform);
            canvasGroup.alpha = 0;
            gameObject.SetActive(false);
        }

        public async UniTask ShowUI()
        {
            audioSource.PlayOneShot(audioClip);

            canvasGroup.alpha = 1;
            gameObject.SetActive(true);
            await _uiSizeTweener.RestoreSize(rectTransform, duration);

            await UniTask.Delay(delay);
        }
    }
}
