using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Compilation;
using SystemAssembly = System.Reflection.Assembly;

namespace Nstdspace.UnityCodeGenerator
{
    public static class CodeGeneratorResolver
    {
        private const string NstdspaceUnityCodeGeneratorRuntimeAssemblyName = "Nstdspace.UnityCodeGenerator";

        public static List<Type> GetUnityCodeGenerators()
        {
            return GetAssembliesReferencingUnityCodeGeneratorRuntimeAssembly()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass)
                .Where(type => type.IsSubclassOf(typeof(AbstractUnityCodeGenerator)))
                .ToList();
        }

        private static List<SystemAssembly> GetAssembliesReferencingUnityCodeGeneratorRuntimeAssembly()
        {
            List<string> referencingAssemblyNames = CompilationPipeline
                .GetAssemblies(AssembliesType.PlayerWithoutTestAssemblies)
                .Where(DoesReferenceRuntimeAssembly)
                .Select(assembly => assembly.name)
                .ToList();

            List<SystemAssembly> referencingAssemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(assembly => referencingAssemblyNames.Contains(assembly.GetName().Name))
                .ToList();

            return referencingAssemblies;
        }

        private static bool DoesReferenceRuntimeAssembly(Assembly assembly)
        {
            return assembly.assemblyReferences.Any(
                reference => reference.name == NstdspaceUnityCodeGeneratorRuntimeAssemblyName
            );
        }
    }
}