using _No_ise.Scripts.Enum;
using _No_ise.Scripts.Gimmick;
using _No_ise.Scripts.Message;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using VContainer;
using ZeroMessenger;

namespace _No_ise.Scripts.Umpire
{
    public class Stage3Umpire: MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private ClockDisplay clockDisplay;

        private IMessagePublisher<StageClear> _stageClearPublisher;

        private int _delay = 5000;

        [Inject]
        public void Construct(IMessagePublisher<StageClear> stageClearPublisher)
        {
            _stageClearPublisher = stageClearPublisher;
        }

        private void Start()
        {
            // 時計が止まったらクリア(clockDisplayのIsRunningがfalseになったら、R3のSubscribeメソッドが呼ばれる)
            clockDisplay.IsRunning.Where(x => !x).Subscribe(_ => StageClear());
            // clockDisplay.OnClockStopped += Subscribe;
        }

        private async UniTask StageClear()
        {
            // audioSource.clip = stageClearAudio;
            // audioSource.Play();
            // await UniTask.Delay(_delay);

            audioSource.Stop();
            await UniTask.Delay(_delay);

            _stageClearPublisher.Publish(new StageClear(Stage.Stage4));
        }
    }
}
