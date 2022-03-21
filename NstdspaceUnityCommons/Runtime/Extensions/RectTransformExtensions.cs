using UnityEngine;

namespace Nstdspace.Commons.Extensions
{
    public static class RectTransformExtensions
    {
        public static void SetAnchoredX(this RectTransform transform, float x)
        {
            transform.anchoredPosition = new Vector2(x, transform.anchoredPosition.y);
        }

        public static void SetAnchoredY(this RectTransform transform, float y)
        {
            transform.anchoredPosition = new Vector2(transform.anchoredPosition.x, y);
        }

        public static void Activate(this RectTransform rectTransform)
        {
            rectTransform.gameObject.Activate();
        }

        public static void Deactive(this RectTransform rectTransform)
        {
            rectTransform.gameObject.Deactivate();
        }
    }
}