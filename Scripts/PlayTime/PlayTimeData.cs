namespace _No_ise.Scripts.PlayTime
{
    public class PlayTimeData
    {
        private float _totalTime = 0f;

        public float GetTotalTime() => _totalTime;

        /// <summary>
        /// プレイ時間を加算する
        /// </summary>
        /// <param name="deltaTime"></param>
        public void AddTime(float deltaTime)
        {
            _totalTime += deltaTime;
        }

        /// <summary>
        /// プレイ時間をリセットする
        /// </summary>
        public void ResetTime()
        {
            _totalTime = 0f;
        }
    }
}
