using _No_ise.Scripts.Message;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using ZeroMessenger;

namespace _No_ise.Scripts.UI.Title
{
    public class RetryButton : MonoBehaviour
    {
        [SerializeField] private Button retryBtn;

        private IMessagePublisher<StageRetry> _stageRetryPublisher;
        private IMessageSubscriber<StageClear> _stageClearSubscriber;

        [Inject]
        public void Construct(
            IMessagePublisher<StageRetry> stageRetryPublisher,
            IMessageSubscriber<StageClear> stageClearSubscriber
            )
        {
            _stageRetryPublisher = stageRetryPublisher;
            _stageClearSubscriber = stageClearSubscriber;
        }

        private void Awake()
        {
            retryBtn.onClick.AddListener(OnClickRetry);
            _stageClearSubscriber.Subscribe<StageClear>(OnStageClear);
        }

        private void OnStageClear(StageClear msg)
        {
            retryBtn.interactable = false;
        }

        private void OnClickRetry()
        {
            retryBtn.interactable = false;
            _stageRetryPublisher.Publish(new StageRetry());
        }
    }
}
