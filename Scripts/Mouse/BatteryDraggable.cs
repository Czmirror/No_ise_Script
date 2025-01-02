using UnityEngine;
using _No_ise.Scripts.Enum;

namespace _No_ise.Scripts.Mouse
{
    public class BatteryDraggable: MonoBehaviour, IDraggable
    {
        [SerializeField] private BatteryType batteryType; // インスペクタで指定

        private bool isDragging = false;
        public bool IsDragging => isDragging;
        private Vector3 offset;

        public BatteryType GetBatteryType()
        {
            return batteryType;
        }

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
            // 今回は未使用
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
            // Debug.Log("battery_OnMouseUp");
            OnEndDrag();
        }
    }
}
