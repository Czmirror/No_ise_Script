using System;
using UnityEngine;

namespace _No_ise.Scripts.Gimmick
{
    public class WaterSplash : MonoBehaviour
    {
        private float _lifeTime = 1.0f;
        private void Start()
        {
            // 一定時間後削除
            Destroy(gameObject, _lifeTime);
        }
    }
}
