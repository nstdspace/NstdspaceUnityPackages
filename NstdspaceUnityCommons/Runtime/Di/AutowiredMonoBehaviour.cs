using System.Linq;
using System.Reflection;
using UnityEngine;

namespace TilemapTest
{
    public class AutowiredMonoBehaviour : MonoBehaviour
    {
        private void Start()
        {
            var autowireFields = GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes.Any(a => a.AttributeType == typeof(AutowireAttribute)));
            foreach (var field in autowireFields)
            {
                var injectedObject = ResolveComponent(field);
                field.SetValue(this, injectedObject);
            }
        }

        private Component ResolveComponent(FieldInfo autowiredComponentField)
        {
            var componentType = autowiredComponentField.FieldType;
            var componentOnThis = GetComponent(componentType);
            if (componentOnThis != null)
            {
                return componentOnThis;
            }

            var componentInChildren = GetComponentInChildren(componentType);
            if (componentInChildren != null) {
                return componentInChildren;
            }
            
            return (Component) FindAnyObjectByType(componentType);
        }
    }
}