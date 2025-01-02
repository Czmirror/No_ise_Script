using _No_ise.Scripts.Enum;

namespace _No_ise.Scripts.Message
{
    /// <summary>
    /// ステージクリアメッセージ
    /// </summary>
    public class StageClear
    {
        // stage enum
        public Stage Stage { get; private set; }

        public StageClear(Stage stage)
        {
            Stage = stage;
        }
    }
}
