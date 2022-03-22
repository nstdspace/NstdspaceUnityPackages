using System;
using System.Reflection;
using UnityEditor.Callbacks;

namespace Nstdspace.UnityCodeGenerator.Editor
{
    public static class UnityCodeGeneratorHandler
    {
        [DidReloadScripts]
        private static void InvokeGenerators()
        {
            CodeGeneratorResolver
                .GetUnityCodeGenerators()
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