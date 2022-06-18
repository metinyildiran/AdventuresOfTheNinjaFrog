using UnityEngine.EventSystems;

namespace Buttons
{
    public class JumpButton : ButtonPressBase
    {
        public bool JumpPressed { get; private set; }

        public override void OnPointerDown(PointerEventData eventData)
        {
            JumpPressed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            JumpPressed = false;
        }
    }
}