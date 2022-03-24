using UnityEngine;
using UnityEngine.EventSystems;

namespace Buttons
{
    public abstract class ButtonPressBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public abstract void OnPointerDown(PointerEventData eventData);

        public abstract void OnPointerUp(PointerEventData eventData);
    }
}