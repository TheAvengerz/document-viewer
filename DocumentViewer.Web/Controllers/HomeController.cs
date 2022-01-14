using DocumentViewer.Web.Models;
using DocumentViewer.Web.Utilities;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentViewer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult ViewDocument(string filename)
        {
            try
            {
                var pageCount = Preview(filename);
                return Json(new { success = true, data = pageCount });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public int Preview(string filename)
        {
            try
            {
                int pageCount = 0;
                string imageFilesFolder = Utils.GetOutputDirectoryPath(filename);
                string imageFilesPath = Path.Combine(imageFilesFolder, "page-{0}.png");
                Stream stream = GetFileStream(FilesCollection.PKB_PDF);

                using (Viewer viewer = new Viewer(stream))
                {
                    //Get document info
                    ViewInfo info = viewer.GetViewInfo(ViewInfoOptions.ForPngView(false));
                    pageCount = info.Pages.Count;

                    //Set options and render document
                    PngViewOptions options = new PngViewOptions(imageFilesPath);
                    viewer.View(options);
                }

                return pageCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Stream GetFileStream(string file)
        {
            return System.IO.File.OpenRead(file);
        }
    }
}
