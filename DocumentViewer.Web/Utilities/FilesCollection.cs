using System.IO;

namespace DocumentViewer.Web.Utilities
{
    public static class FilesCollection
    {
        public static string PKB_PDF =>
            GetTemplateFilePath("PKB.pdf");

        private static string GetTemplateFilePath(string filePath) =>
           Path.Combine(Utils.TemplatePath, filePath);
    }
}
