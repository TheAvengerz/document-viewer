using System.IO;
using System.Runtime.CompilerServices;

namespace DocumentViewer.Web.Utilities
{
    internal static class Utils
    {
        public const string TemplatePath = @"./Template";
        public const string OutputPath = @"./PreviewFiles";

        public static string GetOutputDirectoryPath([CallerFilePath] string callerFilePath = null)
        {
            string outputDirectory = Path.Combine(OutputPath, Path.GetFileNameWithoutExtension(callerFilePath));

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            string path = Path.GetFullPath(outputDirectory);

            return path;
        }
    }
}
