using UnityEngine;

namespace Nstdspace.Commons.Extensions
{
    public static class GameObjectExtensions
    {
        public static void DestroyChildren(this GameObject gameObject)
        {
            DestroyChildren(gameObject.transform);
        }

        public static void DestroyChildren(this MonoBehaviour monoBehaviour)
        {
            DestroyChildren(monoBehaviour.transform);
        }

        public static void DestroyChildren(this Transform transform)
        {
            transform.ForEach<Transform>(childTransform => Object.Destroy(childTransform.gameObject));
        }

        public static void DestroySelf(this GameObject @object)
        {
            Object.Destroy(@object);
        }

        public static void DestroySelf(this Transform transform)
        {
            DestroySelf(transform.gameObject);
        }

        public static void Activate(this GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void Deactivate(this GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public static void Scale(this Transform transform, Vector3 by)
        {
            Vector3 scale = transform.localScale;
            scale.Scale(by);
            transform.localScale = scale;
        }
    }
}