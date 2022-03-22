using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Nstdspace.UnityCodeGenerator
{
    public abstract class AbstractUnityCodeGenerator
    {
        protected abstract List<GeneratedSource> GenerateSources();

        public void GenerateSourceFiles()
        {
            List<GeneratedSource> generatedSources = GenerateSources();
            foreach (GeneratedSource source in generatedSources)
            {
                string path = ConstructGeneratedSourceFilePath(source);
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);

                var sourceCode = "// This is an automatically generated file. DO NOT edit it manually." +
                                 Environment.NewLine +
                                 source.SourceCode;
                WriteGeneratedSourceFile(path, sourceCode);
            }
        }

        private static string ConstructGeneratedSourceFilePath(GeneratedSource source)
        {
            string[] namespacePaths = source.RelativeNamespace.Split(".");
            List<string> paths = new();
            paths.Add(Directory.GetCurrentDirectory());
            paths.Add("Assets");
            paths.Add("Generated");
            paths.AddRange(namespacePaths);
            paths.Add(source.Name);
            return Path.Combine(paths.ToArray());
        }

        private static void WriteGeneratedSourceFile(string path, string sourceFileContent)
        {
            if (!IsOverwriteRequired(path, sourceFileContent))
            {
                Debug.Log("File contents match generated source, do nothing..");
                return;
            }

            FileInfo fileInfo = DeleteFile(path);
            FileStream fileStream = fileInfo.Create();
            Debug.Log($@"<color=""#00AA00"">Writing generated code to {fileInfo.FullName}...</color>");
            StreamWriter writer = new(fileStream);
            writer.Write(sourceFileContent);
            writer.Flush();
            writer.Close();
        }

        private static bool IsOverwriteRequired(string path, string newContent)
        {
            using SHA256 hash = SHA256.Create();
            byte[] fileBytes = File.ReadAllBytes(path);
            byte[] newContentBytes = Encoding.UTF8.GetBytes(newContent);
            byte[] fileContentHash = hash.ComputeHash(fileBytes);
            byte[] newContentHash = hash.ComputeHash(newContentBytes);
            return !fileContentHash.SequenceEqual(newContentHash);
        }

        private static FileInfo DeleteFile(string path)
        {
            FileInfo fileInfo = new(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            return fileInfo;
        }
    }
}