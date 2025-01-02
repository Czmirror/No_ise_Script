using System;
using _No_ise.Scripts.Enum;
using _No_ise.Scripts.UI.Fade;
using _No_ise.Scripts.UI.Title;
using _No_ise.Scripts.UI.Tween;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace _No_ise.Scripts.UI.Window
{
    public class ScreenGameStart : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private MenuButtons menuButtons;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioClip;

        private UISizeTweener _uiSizeTweener;
        private float duration = 0.2f;
        private float delay = 2f;

        [Inject]
        public void Construct(UISizeTweener uiSizeTweener)
        {
            _uiSizeTweener = uiSizeTweener;
        }

        private void Awake()
        {
            Initialize();
        }

        public UniTask Initialize()
        {
            _uiSizeTweener.Initialize(rectTransform);

            gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }

        public async UniTask ShowUI()
        {
            audioSource.PlayOneShot(audioClip);

            menuButtons.SetInteractable(false);

            canvasGroup.alpha = 1;
            gameObject.SetActive(true);
            await _uiSizeTweener.RestoreSize(rectTransform, duration);

            await UniTask.Delay(TimeSpan.FromSeconds(delay));

            // シーン遷移
            var sceneName = Stage.Stage1.ToString();
            SceneManager.LoadScene(sceneName);
        }
    }
}
