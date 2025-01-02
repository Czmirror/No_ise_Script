using UnityEngine;

namespace _No_ise.Scripts.Mouse
{
    public class SpannerDraggable : MonoBehaviour, IDraggable
    {
        private bool isDragging = false;
        private Vector3 offset;

        private void Update()
        {
            if (isDragging)
            {
                // マウス位置をワールド座標に変換してスパナを移動
                Vector3 mousePos = Input.mousePosition;
                // 2Dの場合
                mousePos.z = 10f; // カメラからの距離(適宜変更)
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                transform.position = worldPos + offset;
            }
        }
        public void OnBeginDrag()
        {
            // マウスワールド位置 - スパナ位置の差を覚える
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            offset = transform.position - worldPos;
            isDragging = true;
        }

        public void OnDrag()
        {
            throw new System.NotImplementedException();
        }

        public void OnEndDrag()
        {
            isDragging = false;
        }

        private void OnMouseDown()
        {
            OnBeginDrag();
        }
        private void OnMouseUp()
        {
            OnEndDrag();
        }
    }
}
