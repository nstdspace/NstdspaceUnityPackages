using UnityEngine;

namespace Nstdspace.Commons
{
    public static class RectTransformUtils
    {
        public static void ScaleTo(RectTransform rectTransform, Vector2 totalSize)
        {
            Vector2 initialSize = rectTransform.rect.size;
            Vector2 scaleFactor = totalSize / initialSize;
            rectTransform.localScale = new Vector3(scaleFactor.x, scaleFactor.y, 1);
        }
    }
}