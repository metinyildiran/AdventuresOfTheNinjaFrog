using UnityEngine.EventSystems;

namespace Buttons
{
    public class LeftButton : ButtonPressBase
    {
        public bool LeftPressed { get; private set; }
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            LeftPressed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            LeftPressed = false;
        }
    }
}