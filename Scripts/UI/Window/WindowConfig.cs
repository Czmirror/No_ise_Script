using _No_ise.Scripts.UI.Title;
using _No_ise.Scripts.UI.Tween;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _No_ise.Scripts.UI.Window
{
    public class WindowConfig : MonoBehaviour, IWindowUI
    {
        [Header("Fades & Tweens")]
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Button closeButton;
        [SerializeField] private MenuButtons menuButtons;

        private UISizeTweener _uiSizeTweener;
        private float speed = 0.1f;
        private float duration = 0.1f;

        [Inject]
        public void Construct(UISizeTweener uiSizeTweener)
        {
            _uiSizeTweener = uiSizeTweener;
        }

        private void Awake()
        {
            Initialize();
            closeButton.onClick.AddListener(() => PushButton().Forget());
        }

        private async UniTask PushButton()
        {
            await HideUI(duration);
        }
        public UniTask Initialize()
        {
            _uiSizeTweener.Initialize(rectTransform);
            gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }

        public async UniTask ShowUI(float duration)
        {
            menuButtons.SetInteractable(false);

            gameObject.SetActive(true);
            await _uiSizeTweener.RestoreSize(rectTransform, duration);
            closeButton.gameObject.SetActive(true);
        }

        public async UniTask HideUI(float duration)
        {
            closeButton.gameObject.SetActive(false);
            await _uiSizeTweener.ReductionSize(rectTransform, duration);
            gameObject.SetActive(false);

            menuButtons.SetInteractable(true);
        }
    }
}
