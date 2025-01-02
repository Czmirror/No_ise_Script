using _No_ise.Scripts.Enum;
using _No_ise.Scripts.Message;
using _No_ise.Scripts.Spawner;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using ZeroMessenger;

namespace _No_ise.Scripts.Umpire
{
    public class Stage1Umpire : MonoBehaviour
    {
        [SerializeField] private WaterDropletSpawner dropletSpawner;

        [SerializeField] private Collider2D faucetCollider;
        [SerializeField] private Collider2D spannerCollider;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip stageClearAudio;

        private bool stageCleared = false;

        private IMessagePublisher<StageClear> _stageClearPublisher;

        private int _delay = 1000;

        [Inject]
        public void Construct(IMessagePublisher<StageClear> stageClearPublisher)
        {
            _stageClearPublisher = stageClearPublisher;
        }

        void Update()
        {
            if (!stageCleared)
            {
                // スパナがドラッグで動いている間、蛇口( faucetCollider ) と当たったらステージクリア
                if (spannerCollider.bounds.Intersects(faucetCollider.bounds))
                {
                    StageClear();
                }
            }
        }

        private async UniTask StageClear()
        {
            stageCleared = true;

            // ボルトを締める音を再生
            audioSource.clip = stageClearAudio;
            audioSource.Play();

            // 水滴の生成を止める
            if (dropletSpawner != null)
            {
                dropletSpawner.StopDroplets();
            }

            await UniTask.Delay(_delay);

            _stageClearPublisher.Publish(new StageClear(Stage.Stage2));
        }
    }
}
