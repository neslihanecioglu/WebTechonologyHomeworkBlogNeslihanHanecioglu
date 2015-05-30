using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTechnologyHomeworkBlog.Models;

namespace WebTechnologyHomeworkBlog.Controllers
{
    public class imageController : Controller
    {
        private ArticleDBContext db = new ArticleDBContext();

        [Authorize]
        [HttpPost]
        public virtual ActionResult Index(IEnumerable<HttpPostedFileBase> images)
        {
            if (images != null)
            {
                foreach (var file in images) //çoklu şekilde geldiği için döngüye alıyoruz.
                {
                    var path = Path.Combine(Server.MapPath("~/image1/"), file.FileName); //path değişkenine yüklenecek yolu ve resim ismini atadık.

                    file.SaveAs(path); //SaveAs ile de path değişkenine atanan resim yolu ve ismini alarak yükleme işlemini yaptık.




                }

            }



            // after successfully uploading redirect the user
            return RedirectToAction("Index","Articles");
        }
      
         

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
