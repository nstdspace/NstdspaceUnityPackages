using UnityEngine;

namespace Nstdspace.Commons
{
    public static class SpriteUtils
    {
        /// <summary>
        ///     Scales the given sprite renderer such that the rendered sprite
        ///     appears exactly at the given size in world space.
        /// </summary>
        /// <param name="spriteRenderer">the sprite renderer to scale</param>
        /// <param name="targetWorldSize">the desired world size of the rendered sprite</param>
        public static void ScaleTo(SpriteRenderer spriteRenderer, Vector2 targetWorldSize)
        {
            Vector2 currentWorldSize = spriteRenderer.bounds.size;
            Vector2 scale = targetWorldSize / currentWorldSize;
            spriteRenderer.transform.localScale = scale;
        }

        /// <summary>
        ///     Returns center of the sprite without inclusion of its borders
        ///     (i.e. the center of the remaining sprite with its borders removed).
        ///     The result is given in pivot-relative world coordinates.
        /// </summary>
        /// <param name="sprite"></param>
        public static Vector2 GetCenterInBorders(Sprite sprite)
        {
            // left bottom right top
            Vector4 spriteBorder = GetWorldBorder(sprite);
            Vector2 min = (Vector2)sprite.bounds.min + new Vector2(spriteBorder.x, spriteBorder.y);
            Vector2 max = (Vector2)sprite.bounds.max - new Vector2(spriteBorder.z, spriteBorder.w);
            Vector2 centerPosition = min + (max - min) * 0.5f;
            return centerPosition;
        }

        /// <summary>
        ///     Returns the border of the sprite as Vector4 (left, bottom, right, top)
        ///     in world space size.
        /// </summary>
        /// <returns></returns>
        public static Vector4 GetWorldBorder(Sprite sprite)
        {
            return sprite.border / sprite.pixelsPerUnit;
        }
    }
}