using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismail_HomeworkAssignment3.Controllers
{
    public class HomeController : Controller
    {
        // this method returns the index view
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string radioButtonInput )
        {
            if( file == null || radioButtonInput == null)
            {
                ViewBag.Message = "Please Sellect a File and File Type";
            }
            else if( radioButtonInput == "Image")
            {
                // Upload  image to the image folder               
                string name = Path.GetFileName(file.FileName);
                string path = "~/Media/Images/" + name;
                file.SaveAs(Server.MapPath(path));
                ViewBag.Message = path;
            }
            else if( radioButtonInput == "Video")
            {
                // Upload video the vidoes folder
                string name = Path.GetFileName(file.FileName);
                string path = "~/Media/Videos/" + name;
                file.SaveAs(Server.MapPath(path));
                ViewBag.Message = path;
            }
            else if( radioButtonInput== "Document")
            {
                // Upload document to the documents folder
                string name = Path.GetFileName(file.FileName);
                string path = "~/Media/Documents/" + name;
                file.SaveAs(Server.MapPath(path));
                ViewBag.Message = path;

            }
                       
            return View();
        }


    }
}