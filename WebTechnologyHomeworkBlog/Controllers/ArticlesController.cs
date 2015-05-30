using System;
using System.Collections.Generic;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTechnologyHomeworkBlog.Models;
using System.IO;

namespace WebTechnologyHomeworkBlog.Controllers
{
    
    public class ArticlesController : Controller
    {
      
        private ArticleDBContext db = new ArticleDBContext();

        const int pageSize = 2;
        private int ArticleID;
        // GET: Articles
        public ActionResult Index(int page = 1)
        {

            var articles = db.Articles.OrderBy(p => p.ArticleID)
                .Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //The expression (page -1) * pageSize skips all the products before the specified page. 
            //The Take() method only selects a certain number of products, which is pageSize.

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = Math.Ceiling((double)db.Articles.Count() / pageSize);
            return View(articles);









        }
        [Authorize]
        [HttpPost]
        public virtual ActionResult Index(IEnumerable<HttpPostedFileBase> images)
        {

          
            if (images != null) 
            {
                foreach (var file in images) 
                {
                   
                    var path = Path.Combine(Server.MapPath("~/image/"), file.FileName); 

                    file.SaveAs(path); 
                    }
                    }
           
           

            // after successfully uploading redirect the user
            return RedirectToAction("Index");
        }
         [Authorize]
        [HttpPost]
        public virtual ActionResult Index1(IEnumerable<HttpPostedFileBase> images)
        {


            if (images != null)
            {
                foreach (var file in images) 
                {

                    var path = Path.Combine(Server.MapPath("~/image1/"), file.FileName); 

                    file.SaveAs(path); 
                }
            }



            // after successfully uploading redirect the user
            return RedirectToAction("Index");
        }

         [Authorize]
        [HttpPost]
        public virtual ActionResult Index2(IEnumerable<HttpPostedFileBase> images)
        {


            if (images != null)
            {
                foreach (var file in images) 
                {

                    var path = Path.Combine(Server.MapPath("~/image2/"), file.FileName); 

                    file.SaveAs(path); 
                }
            }



            // after successfully uploading redirect the user
            return RedirectToAction("Index", new { page = 2 });
        }

         [Authorize]
        [HttpPost]
        public virtual ActionResult Index3(IEnumerable<HttpPostedFileBase> images)
        {


            if (images != null)
            {
                foreach (var file in images) 
                {

                    var path = Path.Combine(Server.MapPath("~/image3/"), file.FileName); 

                    file.SaveAs(path); 
                }
            }



            // after successfully uploading redirect the user
            return RedirectToAction("Index", new { page = 2 });
        }
         [Authorize]
        [HttpPost]
        public virtual ActionResult Index4(IEnumerable<HttpPostedFileBase> images)
        {


            if (images != null)
            {
                foreach (var file in images) 
                {

                    var path = Path.Combine(Server.MapPath("~/image4/"), file.FileName); 

                    file.SaveAs(path);
                }
            }



            // after successfully uploading redirect the user
            return RedirectToAction("Index", new { page = 3 });
        }
         [Authorize]
        [HttpPost]
        public virtual ActionResult Index5(IEnumerable<HttpPostedFileBase> images)
        {


            if (images != null)
            {
                foreach (var file in images) 
                {

                    var path = Path.Combine(Server.MapPath("~/image5/"), file.FileName); 

                    file.SaveAs(path); 
                }
            }



            // after successfully uploading redirect the user
            return RedirectToAction("Index", new { page = 3 });
        }
         [Authorize]
        [HttpPost]
        public virtual ActionResult Index6(IEnumerable<HttpPostedFileBase> images)
        {


            if (images != null)
            {
                foreach (var file in images) 
                {

                    var path = Path.Combine(Server.MapPath("~/image6/"), file.FileName); 

                    file.SaveAs(path); 
                }
            }



            // after successfully uploading redirect the user
            return RedirectToAction("Index", new { page = 4 });
        }
         [Authorize]
        [HttpPost]
        public virtual ActionResult Index7(IEnumerable<HttpPostedFileBase> images)
        {


            if (images != null)
            {
                foreach (var file in images) 
                {

                    var path = Path.Combine(Server.MapPath("~/image7/"), file.FileName); 

                    file.SaveAs(path); 
                }
            }



            // after successfully uploading redirect the user
            return RedirectToAction("Index", new { page = 4 });
        }

         [Authorize]
         [HttpPost]
         public virtual ActionResult Index8(IEnumerable<HttpPostedFileBase> images)
         {


             if (images != null)
             {
                 foreach (var file in images) 
                 {

                     var path = Path.Combine(Server.MapPath("~/image8/"), file.FileName); 

                     file.SaveAs(path); 
                 }
             }



             // after successfully uploading redirect the user
             return RedirectToAction("Index", new { page = 5 });
         }
         [Authorize]
         [HttpPost]
         public virtual ActionResult Index9(IEnumerable<HttpPostedFileBase> images)
         {


             if (images != null)
             {
                 foreach (var file in images) 
                 {

                     var path = Path.Combine(Server.MapPath("~/image9/"), file.FileName); 

                     file.SaveAs(path); 
                 }
             }



             // after successfully uploading redirect the user
             return RedirectToAction("Index", new { page = 5 });
         }
         [Authorize]
         [HttpPost]
         public virtual ActionResult Index10(IEnumerable<HttpPostedFileBase> images)
         {


             if (images != null)
             {
                 foreach (var file in images) 
                 {

                     var path = Path.Combine(Server.MapPath("~/image10/"), file.FileName); 

                     file.SaveAs(path); 
                 }
             }



             // after successfully uploading redirect the user
             return RedirectToAction("Index", new { page = 6 });
         }
         
        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
         [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleID,ArticleName,ArticleGenre,ArticleTitle,ArticleContent,AuthorName,ReleaseDate")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }
         [Authorize]
        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleID,ArticleName,ArticleGenre,ArticleTitle,ArticleContent,AuthorName,ReleaseDate")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
         [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
      
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
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
