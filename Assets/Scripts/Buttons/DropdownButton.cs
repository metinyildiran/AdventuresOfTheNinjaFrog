using UnityEngine;
using UnityEngine.EventSystems;

namespace Buttons
{
    public class DropdownButton : ButtonPressBase
    {
        public bool DropdownPressed { get; private set; }

        public override void OnPointerDown(PointerEventData eventData)
        {
            DropdownPressed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            DropdownPressed = false;
        }
    }
}