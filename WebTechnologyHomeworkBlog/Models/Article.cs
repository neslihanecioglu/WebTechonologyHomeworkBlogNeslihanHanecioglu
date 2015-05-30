using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebTechnologyHomeworkBlog.Models
{
    public class Article
    {
        public int ArticleID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string ArticleName { get; set; }


       
        [Required]
        [StringLength(30)]
        public string ArticleGenre { get; set; }


        public string ArticleTitle { get; set; }


        [StringLength(60000, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string ArticleContent { get; set; }
        public string AuthorName { get; set; }


       public virtual IList<Comment> Comments { get; set; }
        public string CommentContent { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }





    }
    public class ArticleDBContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public bool ArticleID { get; set; }
    }





}