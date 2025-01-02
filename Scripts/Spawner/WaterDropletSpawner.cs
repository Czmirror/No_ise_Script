using _No_ise.Scripts.Gimmick;
using UnityEngine;

namespace _No_ise.Scripts.Spawner
{
    public class WaterDropletSpawner: MonoBehaviour
    {
        [SerializeField] private WaterDroplet dropletPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnInterval = 1.0f;
        [SerializeField] private float dropSpeed = 2.0f;
        [SerializeField] private AudioClip splashSE;
        [SerializeField] private GameObject splashEffectPrefab;
        [SerializeField] private AudioSource audioSource;

        private bool isSpawning = true;

        private void Start()
        {
            // 一定間隔で水滴を生成する例（コルーチン or UniTask）
            StartCoroutine(SpawnDropletRoutine());
        }

        private System.Collections.IEnumerator SpawnDropletRoutine()
        {
            while (true)
            {
                if(isSpawning)
                {
                    CreateDroplet();
                }
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void CreateDroplet()
        {
            // Dropletを生成し、落下させる
            GameObject dropletObj = Instantiate(dropletPrefab.gameObject, spawnPoint.position, Quaternion.identity);
            WaterDroplet droplet = dropletObj.GetComponent<WaterDroplet>();
            if(droplet != null)
            {
                droplet.Init(dropSpeed, this); // SpeedとかManager参照など
            }
        }

        /// <summary>
        /// 水滴生成を止める(蛇口が閉まった)
        /// </summary>
        public void StopDroplets()
        {
            isSpawning = false;
        }

        /// <summary>
        /// 地面に落ちた時に呼ばれるコールバックなど
        /// </summary>
        public void OnDropletHitGround(Vector3 pos)
        {
            // 効果音再生
            audioSource.Play();
            // audioSource.PlayClipAtPoint(splashSE, pos);
            // 水しぶきエフェクト
            if(splashEffectPrefab)
            {
                Instantiate(splashEffectPrefab, pos, Quaternion.identity);
            }
        }

    }
}
