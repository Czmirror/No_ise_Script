using UnityEngine;

namespace _No_ise.Scripts.Gimmick
{
    public class BatteryCoverHandler: MonoBehaviour
    {
        [SerializeField] private GameObject coverObject;
        [SerializeField] private AudioSource removeCoverSE;
        [SerializeField] private AudioClip removeCoverClip;

        private bool isCoverRemoved = false;

        private void OnMouseDown()
        {
            if(!isCoverRemoved)
            {
                // カバーを外す
                coverObject.SetActive(false);
                isCoverRemoved = true;

                if(removeCoverSE) removeCoverSE.Play();

                // Debug.Log("電池カバーを取り外しました。");
            }
        }

    }
}
