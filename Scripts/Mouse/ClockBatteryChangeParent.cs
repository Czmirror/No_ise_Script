using _No_ise.Scripts.Gimmick;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _No_ise.Scripts.Mouse
{
    public class ClockBatteryChangeParent : MonoBehaviour
    {
        [SerializeField] private Transform newParent;
        [SerializeField] private ClockDisplay clockDisplay;

        private async UniTask OnMouseDown()
        {
            clockDisplay.SetBatteryStatus(false);
            transform.SetParent(newParent);

            await UniTask.Delay(1000);

            // z軸を0にする(時計から電池を外した後、時計の上に載せた時に動かなくなってしまうので、z軸を0にしてすこし前面に出す)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
