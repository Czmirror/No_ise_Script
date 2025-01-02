using _No_ise.Scripts.PlayTime;
using _No_ise.Scripts.UI.Window;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _No_ise.Scripts.UI.Title
{
    public class ButtonStart: MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ScreenGameStart screenGameStart;

        [Inject] private PlayTimeData _playTimeData;

        private void Reset()
        {
            button = GetComponent<Button>();
        }

        private void Awake()
        {
            button.onClick.AddListener(() => PushButton());
        }

        private async UniTask PushButton()
        {
            _playTimeData.ResetTime();
            await screenGameStart.ShowUI();
        }
    }
}
