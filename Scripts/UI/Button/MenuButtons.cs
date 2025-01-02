using UnityEngine;
using UnityEngine.UI;

namespace _No_ise.Scripts.UI.Title
{
    public class MenuButtons : MonoBehaviour
    {
        [SerializeField] private Button buttonStart;
        [SerializeField] private Button buttonConfig;
        [SerializeField] private Button buttonCredit;

        public void SetInteractable(bool interactable)
        {
            buttonStart.interactable = interactable;
            buttonConfig.interactable = interactable;
            buttonCredit.interactable = interactable;
        }
    }
}
