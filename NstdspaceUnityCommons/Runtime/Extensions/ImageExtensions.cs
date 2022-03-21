using UnityEngine;
using UnityEngine.UI;

namespace Nstdspace.Commons.Extensions
{
    public static class ImageExtensions
    {
        public static void SetAlpha(this Image image, float alpha)
        {
            Color imageColor = image.color;
            imageColor.a = alpha;
            image.color = imageColor;
        }
    }
}