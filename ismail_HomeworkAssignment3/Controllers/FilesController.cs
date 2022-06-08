using ismail_HomeworkAssignment3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismail_HomeworkAssignment3.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            // Get file from the files folder 
            string[] files = Directory.GetFiles(Server.MapPath("~/Media/Documents"));

            List<FileModel> fileModels = new List<FileModel>();
            // Make list of files to show in the view 
            for(int i = 0; i < files.Length; i++)
            {
                FileModel file = new FileModel();
                // Get only the name 
                file.FileName = Path.GetFileName(files[i]);
                fileModels.Add(file);
            }
            return View(fileModels);
        }


        public ActionResult Download(string name)
        {
            // Get the file path
            string fullName = Server.MapPath("~/Media/Documents/" + name);

            byte[] fileBytes = GetFile(fullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name);
        }

        // Method to get the file and return as a type o
        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }


        // GET: Files/Delete/5
        public ActionResult Delete(string name)
        {
            string fullPath = Request.MapPath("~/Media/Documents/" + name);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("Index");
        }

      
    }
}
