using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebTechnologyHomeworkBlog.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Required(ErrorMessage = "Please enter your comment.")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public Article Article { get; set; }
        public string  articleName { get; set; }

    }
    public class CommentDBContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
    }
}