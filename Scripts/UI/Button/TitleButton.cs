using _No_ise.Scripts.Enum;
using _No_ise.Scripts.Message;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using ZeroMessenger;

namespace _No_ise.Scripts.UI.Title
{
    public class TitleButton : MonoBehaviour
    {
        [SerializeField] private Button startBtn;
        private IMessagePublisher<StageClear> _stageClearPublisher;

        [Inject]
        public void Construct(IMessagePublisher<StageClear> stageClearPublisher)
        {
            _stageClearPublisher = stageClearPublisher;
        }

        private void Awake()
        {
            startBtn.onClick.AddListener(OnClickStart);
        }

        private void OnClickStart()
        {
            startBtn.interactable = false;
            gameObject.SetActive(false);
            _stageClearPublisher.Publish(new StageClear(Stage.Title));
        }
    }
}
