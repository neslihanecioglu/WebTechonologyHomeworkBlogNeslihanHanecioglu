using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTechnologyHomeworkBlog.Models;

namespace WebTechnologyHomeworkBlog.Controllers
{
    public class Articles1Controller : Controller
    {
        private ArticleDBContext db = new ArticleDBContext();

        const int pageSize = 2;//which represents the maximum number of products we want to show at a time.

        // GET: Articles



      
        public ActionResult Index(int page = 1)
        {

            var articles = db.Articles.OrderBy(p => p.ArticleID)
                .Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //The expression (page -1) * pageSize skips all the products before the specified page. 
            //The Take() method only selects a certain number of products, which is pageSize.

            ViewBag.CurrentPage1 = page;
            ViewBag.PageSize1 = pageSize;
            ViewBag.TotalPages1 = Math.Ceiling((double)db.Articles.Count() / pageSize);
            return View(articles);

}
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentContent")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
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
