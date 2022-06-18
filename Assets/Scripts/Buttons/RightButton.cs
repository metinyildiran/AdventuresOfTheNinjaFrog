using UnityEngine.EventSystems;

namespace Buttons
{
    public class RightButton : ButtonPressBase
    {
        public bool RightPressed { get; private set; }

        public override void OnPointerDown(PointerEventData eventData)
        {
            RightPressed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            RightPressed = false;
        }
    }
}