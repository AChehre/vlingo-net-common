﻿using System.IO;

namespace Vlingo.Common.Compiler
{
    public static class DynaFile
    {
        public readonly static string GeneratedSources = $"target{Path.DirectorySeparatorChar}generated-sources{Path.DirectorySeparatorChar}";
        public readonly static string GeneratedTestSources = $"target{Path.DirectorySeparatorChar}generated-test-sources{Path.DirectorySeparatorChar}";
        public readonly static string RootOfMainClasses = $"target{Path.DirectorySeparatorChar}classes{Path.DirectorySeparatorChar}";
        public readonly static string RootOfTestClasses = $"target{Path.DirectorySeparatorChar}test-classes{Path.DirectorySeparatorChar}";

        public static FileInfo PersistDynaClass(string pathToClass, byte[] dynaClass)
        {
            var file = new FileInfo(pathToClass);

            using (var stream = file.OpenWrite())
            {
                stream.Write(dynaClass, 0, dynaClass.Length);
            }

            return file;
        }

        public static FileInfo PersistDynaClassSource(string pathToSource, string dynaClassSource)
        {
            var file = new FileInfo(pathToSource);

            using (var stream = new StreamWriter(file.OpenWrite()))
            {
                stream.Write(dynaClassSource);
            }

            return file;
        }

        public static string ToFullPath(string fullyQualifiedClassName) => ToPath(fullyQualifiedClassName, true);

        public static string ToNamespacePath(string fullyQualifiedClassName) => ToPath(fullyQualifiedClassName, false);

        private static string ToPath(string fullyQualifiedClassName, bool includeClassName)
        {
            var lastDotIndex = fullyQualifiedClassName.LastIndexOf('.');
            var directoryPath = fullyQualifiedClassName.Substring(0, lastDotIndex).Replace('.', Path.DirectorySeparatorChar);
            if (includeClassName)
            {
                return $"{directoryPath}{Path.DirectorySeparatorChar}{fullyQualifiedClassName.Substring(lastDotIndex + 1)}";
            }
            else
            {
                return directoryPath;
            }
        }
    }
}