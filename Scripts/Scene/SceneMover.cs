using _No_ise.Scripts.Effect;
using _No_ise.Scripts.Enum;
using _No_ise.Scripts.Message;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using ZeroMessenger;

namespace _No_ise.Scripts.Scene
{
    public class SceneMover : MonoBehaviour
    {
        [SerializeField] private StageClearEffect _stageClearEffect;
        [SerializeField] private RetryEffect _retryEffect;
        private IMessageSubscriber<StageClear> _stageClearSubscriber;
        private IMessageSubscriber<StageRetry> _stageRetrySubscriber;

        [Inject]
        public void Construct(
            IMessageSubscriber<StageClear> stageClearSubscriber,
            IMessageSubscriber<StageRetry> stageRetrySubscriber)
        {
            _stageClearSubscriber = stageClearSubscriber;
            _stageRetrySubscriber = stageRetrySubscriber;
        }

        private void Start()
        {
            // stageclearメッセージを受け取ったらシーン遷移
            _stageClearSubscriber.Subscribe<StageClear>(x =>
            {
                SceneMove(x.Stage);
            });

            _stageRetrySubscriber.Subscribe<StageRetry>(x =>
            {
                ReloadScene();
            });
        }

        private async UniTask SceneMove(Stage stage)
        {
            await _stageClearEffect.ShowUI();

            // シーン遷移処理
            var sceneName = stage.ToString();
            SceneManager.LoadScene(sceneName);
        }

        private async UniTask ReloadScene()
        {
            await _retryEffect.ShowUI();
            var currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
