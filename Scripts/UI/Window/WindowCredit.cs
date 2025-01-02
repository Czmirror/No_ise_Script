using System;
using _No_ise.Scripts.UI.Fade;
using _No_ise.Scripts.UI.Title;
using _No_ise.Scripts.UI.Tween;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _No_ise.Scripts.UI.Window
{
    public class WindowCredit : MonoBehaviour, IWindowUI
    {
        [Header("Fades & Tweens")]
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button creditButton;
        [SerializeField] private MenuButtons menuButtons;

        [Header("Credit Scroll Settings")]
        /// <summary>
        ///マスク用（RectMask2Dが付いている想定）
        /// </summary>
        [SerializeField] private RectTransform creditMaskRect;
        /// <summary>
        /// TextMeshProUGUIがアタッチされたGameObjectのRectTransform
        /// </summary>
        [SerializeField] private RectTransform creditTextRect;

        private UISizeTweener _uiSizeTweener;
        private float speed = 0.1f;
        private float duration = 0.1f;

        // スクロールアニメ関連
        /// <summary>
        /// 何秒かけて上まで流すか
        /// </summary>
        [SerializeField] private float scrollDuration = 5f;

        /// <summary>
        /// 下端スタート位置
        /// </summary>
        private Vector2 startPos;

        /// <summary>
        /// 上端終了位置
        /// </summary>
        private Vector2 endPos;

        private TextMeshProUGUI creditText;

        [Inject]
        public void Construct(UISizeTweener uiSizeTweener)
        {
            _uiSizeTweener = uiSizeTweener;
        }

        private void Awake()
        {
            creditText = creditTextRect.GetComponent<TextMeshProUGUI>();
            UpdateTextHeight();
            Initialize();

            closeButton.onClick.AddListener(() => PushButton().Forget());
        }

        private async UniTask PushButton()
        {
            await HideUI(duration);
        }

        /// <summary>
        /// スクロール開始位置(startPos)と終了位置(endPos)を計算
        /// </summary>
        private void SetupScrollPositions()
        {
            // 例えば maskの高さ, textの高さをもとに start/end を決める
            // 下端スタート: textのanchoredPosition.y = - (textHeight) くらい
            float maskHeight = creditMaskRect.rect.height;
            float textHeight = creditTextRect.rect.height;

            startPos = new Vector2(
                creditTextRect.anchoredPosition.x,
                maskHeight * -1
            );

            endPos = new Vector2(
                creditTextRect.anchoredPosition.x,
                maskHeight * 0.5f + textHeight
            );
        }

        /// <summary>
        /// テキストを下から上へ流す
        /// </summary>
        private void ScrollStaffRoll()
        {
            // anchoredPositionのY値を startPos.y -> endPos.y へ scrollDuration秒で補間
            LMotion.Create(startPos.y, endPos.y, scrollDuration)
                .BindToAnchoredPositionY(creditTextRect)
                .AddTo(creditTextRect.gameObject);
        }

        /// <summary>
        /// テキスト量に応じてRectTransformの高さを自動調整
        /// </summary>
        private void UpdateTextHeight()
        {
            // ForceMeshUpdate でテキストのレイアウトを再計算させる（必要に応じて）
            creditText.ForceMeshUpdate();

            // preferredHeight を取得
            float textPreferredHeight = creditText.preferredHeight;

            // すでに何らかのwidthを設定済みだとして、heightだけ書き換えたい場合
            float currentWidth = creditTextRect.sizeDelta.x;

            // TextMeshProが計算した「必要な高さ」をRectTransformに反映
            creditTextRect.sizeDelta = new Vector2(currentWidth, textPreferredHeight);
        }

        public UniTask Initialize()
        {
            _uiSizeTweener.Initialize(rectTransform);
            gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
            SetupScrollPositions();
            return UniTask.CompletedTask;
        }

        public async UniTask ShowUI(float duration)
        {
            menuButtons.SetInteractable(false);

            gameObject.SetActive(true);

            await _uiSizeTweener.RestoreSize(rectTransform, duration);
            closeButton.gameObject.SetActive(true);

            // テキストを初期位置へ
            creditTextRect.anchoredPosition = startPos;

            ScrollStaffRoll();
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
