using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Compilation;
using SystemAssembly = System.Reflection.Assembly;

namespace Nstdspace.UnityCodeGenerator.Editor
{
    public static class CodeGeneratorResolver
    {
        public static List<Type> GetUnityCodeGenerators()
        {
            return GetAssembliesReferencingType<AbstractUnityCodeGenerator>()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass)
                .Where(type => type.IsSubclassOf(typeof(AbstractUnityCodeGenerator)))
                .ToList();
        }

        private static List<SystemAssembly> GetAssembliesReferencingType<T>()
        {
            List<string> referencingAssemblyNames = GetReferencingAssemblyNames<T>();
            return GetAssemblies(referencingAssemblyNames);
        }

        private static List<SystemAssembly> GetAssemblies(ICollection<string> assemblyNames)
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(assembly => assemblyNames.Contains(assembly.GetName().Name))
                .ToList();
        }

        private static List<string> GetReferencingAssemblyNames<T>()
        {
            List<string> referencingAssemblyNames = CompilationPipeline
                .GetAssemblies(AssembliesType.PlayerWithoutTestAssemblies)
                .Where(DoesReferenceType<T>)
                .Select(assembly => assembly.name)
                .ToList();
            return referencingAssemblyNames;
        }

        private static bool DoesReferenceType<T>(Assembly assembly)
        {
            return assembly.assemblyReferences.Any(
                reference => reference.name == typeof(T).Assembly.GetName().Name
            );
        }
    }
}