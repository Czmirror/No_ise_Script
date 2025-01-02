using UnityEngine;

namespace _No_ise.Scripts.Gimmick
{
    public class ClockFlipHandler: MonoBehaviour
    {
        [SerializeField] private GameObject frontSide;
        // 表面オブジェクト (時計表示パネル)
        [SerializeField] private GameObject backSide;
        // 裏面オブジェクト (電池カバーや電池が見える)

        private bool isFront = true;

        private void Start()
        {
            ShowFrontSide(true);
        }

        private void OnMouseDown()
        {
            // 時計全体をクリックすると裏返す/表に戻す
            ToggleSide();
        }

        private void ToggleSide()
        {
            isFront = !isFront;
            ShowFrontSide(isFront);
        }

        private void ShowFrontSide(bool showFront)
        {
            frontSide.SetActive(showFront);
            backSide.SetActive(!showFront);
        }

    }
}
