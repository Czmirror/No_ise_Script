using _No_ise.Scripts.Enum;
using _No_ise.Scripts.Message;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using ZeroMessenger;

namespace _No_ise.Scripts.Umpire
{
    public class Stage2Umpire : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip stageClearAudio;
        [SerializeField] private SpriteRenderer tvSpriteRenderer;
        [SerializeField] private Sprite tvOffSprite;

        private bool stageCleared = false;

        private IMessagePublisher<StageClear> _stageClearPublisher;
        private IMessageSubscriber<TVPowerOff> _tvPowerOffSubscriber;

        // 遅延時間
        private int _delay = 1000;

        [Inject]
        public void Construct(
            IMessagePublisher<StageClear> stageClearPublisher,
            IMessageSubscriber<TVPowerOff> tvPowerOffSubscriber
        )
        {
            _stageClearPublisher = stageClearPublisher;
            _tvPowerOffSubscriber = tvPowerOffSubscriber;
        }

        private void Start()
        {
            _tvPowerOffSubscriber.Subscribe<TVPowerOff>(OnTVPowerOff);
        }

        private async void OnTVPowerOff(TVPowerOff msg)
        {
            if(!stageCleared)
            {
                await StageClear();
            }
        }

        private async UniTask StageClear()
        {
            stageCleared = true;

            audioSource.clip = stageClearAudio;
            audioSource.Play();
            tvSpriteRenderer.sprite = tvOffSprite;
            await UniTask.Delay(_delay);

            audioSource.Stop();
            await UniTask.Delay(_delay);

            _stageClearPublisher.Publish(new StageClear(Stage.Stage3));
        }

    }
}
