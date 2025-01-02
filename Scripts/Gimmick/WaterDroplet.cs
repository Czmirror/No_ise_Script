using _No_ise.Scripts.Spawner;
using UnityEngine;

namespace _No_ise.Scripts.Gimmick
{
    public class WaterDroplet: MonoBehaviour
    {
        private float speed;
        private WaterDropletSpawner _spawner;
        private bool isFalling = true;
        private float endPosY = -5f;

        public void Init(float dropSpeed, WaterDropletSpawner mgr)
        {
            speed = dropSpeed;
            _spawner = mgr;
        }

        void Update()
        {
            if(isFalling)
            {
                // 重力の代わりに単純に下方向へ移動
                transform.position += Vector3.down * speed * Time.deltaTime;
            }

            // Y座標が一定以下なら地面に衝突とみなす
            if(transform.position.y < endPosY)
            {
                HitGround();
            }
        }

        private void HitGround()
        {
            if(_spawner != null)
            {
                _spawner.OnDropletHitGround(transform.position);
            }
            Destroy(gameObject);
        }

    }
}
