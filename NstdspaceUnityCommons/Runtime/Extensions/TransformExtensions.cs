using UnityEngine;

namespace Nstdspace.Commons.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        ///     Overwrites the x and y component of the given transforms position without
        ///     modifying the z component.
        /// </summary>
        /// <param name="transform">the transform whose position should be changed</param>
        /// <param name="position">the target position in the XY-Plane</param>
        public static void Set2dPosition(this Transform transform, Vector2 position)
        {
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }

        public static void SetPositionX(this Transform transform, float x)
        {
            Vector3 position = transform.position;
            position = new Vector3(x, position.y, position.z);
            transform.position = position;
        }

        public static void SetPositionY(this Transform transform, float y)
        {
            Vector3 position = transform.position;
            position = new Vector3(position.x, y, position.z);
            transform.position = position;
        }

        public static void SetPositionZ(this Transform transform, float z)
        {
            Vector3 position = transform.position;
            position = new Vector3(position.x, position.y, z);
            transform.position = position;
        }
    }
}