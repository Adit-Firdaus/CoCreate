using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CoCreate
{
    public class SmoothScrollRect : ScrollRect, IScrollHandler
    {
        public override void OnScroll(PointerEventData data)
        {
            var scrollDelta = -data.scrollDelta;

            if (horizontal && !vertical)
                scrollDelta.x = -scrollDelta.y;

            velocity += scrollDelta * scrollSensitivity;
        }
    }
}