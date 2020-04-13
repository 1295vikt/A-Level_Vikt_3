using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(24, ErrorMessage = "Name length can't be more than 24 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please use english letters only.")]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string Image { get; set; }
        public int AuthorId { get; set; }
        public DateTime Date { get; set; }
        //public List<CommentModel> Comments { get; set; }
    }
}