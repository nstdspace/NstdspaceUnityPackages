using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor.Callbacks;

namespace Nstdspace.UnityCodeGenerator.Editor
{
    public class UnityCodeGeneratorHandler
    {
        [DidReloadScripts]
        private static void CreateAssetWhenReady()
        {
            GetAbstractUnityCodeGenerators()
                .ForEach(InvokeGenerator);
        }

        private static void InvokeGenerator(Type generator)
        {
            AbstractUnityCodeGenerator result =
                (AbstractUnityCodeGenerator) GetDefaultConstructor(generator).Invoke();
            result.GenerateSourceFiles();
        }

        private static List<Type> GetAbstractUnityCodeGenerators()
        {
            List<Type> generators = Assembly.GetAssembly(typeof(AbstractUnityCodeGenerator))
                .GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.IsSubclassOf(typeof(AbstractUnityCodeGenerator)))
                .ToList();
            return generators;
        }

        private static ConstructorInfo GetDefaultConstructor(Type type)
        {
            return type.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public,
                null,
                CallingConventions.HasThis,
                new Type[] { },
                null
            );
        }
    }

    public static class ConstructorExtensions
    {
        public static object Invoke(this ConstructorInfo constructor)
        {
            return constructor.Invoke(new object[] { });
        }
    }
}