using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBL.Models
{
    public class CommentBL
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
        public DateTime Date { get; set; }
        public int ArticleId { get; set; }
    }
}
