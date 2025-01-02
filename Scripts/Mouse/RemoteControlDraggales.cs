using UnityEngine;

namespace _No_ise.Scripts.Mouse
{
    public class RemoteControlDraggales : MonoBehaviour, IDraggable
    {
        private bool isDragging = false;
        public bool IsDragging => isDragging;
        private Vector3 offset;

        private void Update()
        {
            if (isDragging)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10f;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                transform.position = worldPos + offset;
            }
        }

        public void OnBeginDrag()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            offset = transform.position - worldPos;
            isDragging = true;
        }

        public void OnDrag()
        {
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
