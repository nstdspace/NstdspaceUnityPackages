using UnityEngine;

namespace Nstdspace.Commons
{
    public class RandomUtils
    {
        public static Vector2 OnUnitCircle()
        {
            float angle = Random.Range(0f, 2 * Mathf.PI);
            float x = Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            return new Vector2(x, y);
        }

        public static Vector2 InUnitSquare()
        {
            float x = Random.Range(0f, 1f);
            float y = Random.Range(0f, 1f);
            return new Vector2(x, y);
        }
    }
}