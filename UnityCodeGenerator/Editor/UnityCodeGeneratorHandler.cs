using System;
using System.Reflection;
using Nstdspace.Commons.Extensions;
using UnityEditor;
using UnityEditor.Callbacks;

namespace Nstdspace.UnityCodeGenerator.Editor
{
    public static class UnityCodeGeneratorHandler
    {
        [DidReloadScripts]
        private static void InvokeGenerators()
        {
            TypeCache.GetTypesDerivedFrom<AbstractUnityCodeGenerator>()
                .ForEach(InvokeGenerator);
        }

        private static void InvokeGenerator(Type generator)
        {
            AbstractUnityCodeGenerator result =
                (AbstractUnityCodeGenerator) GetDefaultConstructor(generator).Invoke();
            result.GenerateSourceFiles();
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