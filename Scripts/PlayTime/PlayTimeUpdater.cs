using UnityEngine;
using VContainer.Unity;

namespace _No_ise.Scripts.PlayTime
{
    public class PlayTimeUpdater : ITickable
    {
        private readonly PlayTimeData _playTimeData;

        public PlayTimeUpdater(PlayTimeData playTimeData)
        {
            _playTimeData = playTimeData;
        }

        // 毎フレーム呼ばれる
        public void Tick()
        {
            _playTimeData.AddTime(UnityEngine.Time.deltaTime);
        }
    }
}
