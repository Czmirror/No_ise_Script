using _No_ise.Scripts.UI.Window;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace _No_ise.Scripts.UI.Title
{
    public class ButtonConfig : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private WindowConfig _windowUI;
        private float _duration = 0.1f;

        private void Reset()
        {
            button = GetComponent<Button>();
        }

        private void Awake()
        {
            button.onClick.AddListener(() => PushButton().Forget());
        }

        private async UniTask PushButton()
        {
            await _windowUI.ShowUI(_duration);
        }
    }
}
