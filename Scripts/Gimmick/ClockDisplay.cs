using System;
using R3;
using TMPro;
using UnityEngine;

namespace _No_ise.Scripts.Gimmick
{
    public class ClockDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text hourMinutesText;
        [SerializeField] private TMP_Text secondsText;

        // テキスト表示（UGUI）想定 or TMP_Text
        private bool isBatteryInserted = true;
        private float timeElapsed = 0f; // 秒数カウント
        ReactiveProperty<bool> isRunning = new ReactiveProperty<bool>(true);
        public ReadOnlyReactiveProperty<bool> IsRunning => isRunning;

        void Update()
        {
            if (isRunning.Value && isBatteryInserted)
            {
                timeElapsed += Time.deltaTime;
                UpdateClockText(timeElapsed);
            }
            else
            {
                hourMinutesText.text = String.Empty;
                secondsText.text = String.Empty;
            }
        }

        private void UpdateClockText(float totalSeconds)
        {
            // 秒→時分秒計算
            int seconds = (int)totalSeconds;
            int hrs = seconds / 3600;
            int mins = (seconds % 3600) / 60;
            int secs = seconds % 60;

            // hrs 25以上の場合は24時間表記にする
            if (hrs >= 25)
            {
                hrs = hrs % 24;
            }

            hourMinutesText.text = $"{hrs:00}:{mins:00}";
            secondsText.text = $"{secs:00}";
        }

        public void SetBatteryStatus(bool inserted)
        {
            // 電池の有無を切り替え
            isBatteryInserted = inserted;
            if (!inserted)
            {
                // 電池が抜かれたら時間を止める
                isRunning.Value = false; // or keep it running but not incrementing
            }
        }

        public void ResetClock()
        {
            timeElapsed = 0f;
            UpdateClockText(0f);
            isRunning.Value = true;
        }
    }
}
