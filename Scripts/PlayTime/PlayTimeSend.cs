using UnityEngine;
using unityroom.Api;
using VContainer;

namespace _No_ise.Scripts.PlayTime
{
    public class PlayTimeSend : MonoBehaviour
    {
        [Inject] private PlayTimeData _playTimeData;

        private void Start()
        {
            var playTime = _playTimeData.GetTotalTime();
            UnityroomApiClient.Instance.SendScore(1, playTime, ScoreboardWriteMode.HighScoreAsc);
        }
    }
}
