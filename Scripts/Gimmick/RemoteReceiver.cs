using System;
using UnityEngine;
using _No_ise.Scripts.Enum;
using _No_ise.Scripts.Message;
using _No_ise.Scripts.Mouse;
using VContainer;
using ZeroMessenger;

namespace _No_ise.Scripts.Gimmick
{
    public class RemoteReceiver : MonoBehaviour
    {
        [SerializeField] private AudioSource insertBatterySE; // 電池を挿入した効果音のAudioSource
        [SerializeField] private AudioClip insertBatteryClip; // 電池を挿入した効果音
        private int correctBatteryCount = 0;                  // 正解の電池が何本入ったか
        private bool isRemoteActive = false;                  // リモコン有効フラグ
        [SerializeField] private int remoteBatteryCount = 2;                   // リモコンに必要な電池の数
        [SerializeField] private RemoteControlDraggales remoteControlDraggales; // リモコンのドラッグ処理

        private IMessagePublisher<TVPowerOff> _tvPowerOffPublisher;

        [Inject]
        public void Construct(IMessagePublisher<TVPowerOff> tvPowerOffPublisher)
        {
            _tvPowerOffPublisher = tvPowerOffPublisher;
        }

        // 電池をリモコンにドラッグして重なったら呼ばれる
        private void OnTriggerEnter2D(Collider2D other)
        {
            // リモコンがドラッグ中の場合は何もしない
            if(remoteControlDraggales?.IsDragging == true) return;

            var battery = other.GetComponent<BatteryDraggable>();
            if(battery != null)
            {
                if (correctBatteryCount >= remoteBatteryCount)
                {
                    // リモコンが有効になっていれば何もしない
                    return;
                }

                // 電池をドラッグしていない場合は何もしない
                if (battery.IsDragging == false) return;

                // Debug.Log("電池がリモコンに重なりました。");

                // BatteryTypeをチェック
                if(battery.GetBatteryType() == BatteryType.Slim)
                {
                    // 正解電池の場合
                    correctBatteryCount++;
                    insertBatterySE?.PlayOneShot(insertBatteryClip);

                    // 電池オブジェクトを消す
                    Destroy(battery.gameObject);

                    // 2本そろったらリモコンが有効に
                    if(correctBatteryCount >= remoteBatteryCount)
                    {
                        isRemoteActive = true;
                        // Debug.Log("リモコンが有効になりました。");
                    }
                }
                else
                {
                    // 何も起こらない
                    // Debug.Log("不正解の電池です。リモコンには使えない。");
                }
            }
        }

        private void OnMouseDown()
        {
            // Debug.Log("リモコンをクリックしました。");

            // リモコンが有効になっていればテレビのノイズを消す (TVPowerOffをPublish)
            if(isRemoteActive)
            {
                // Debug.Log("リモコンをクリック → テレビのノイズ停止");
                _tvPowerOffPublisher.Publish(new TVPowerOff());
            }
        }

    }
}
