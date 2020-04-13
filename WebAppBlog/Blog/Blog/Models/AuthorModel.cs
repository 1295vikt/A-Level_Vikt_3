using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(12, ErrorMessage = "Name length can't be more than 12 characters.")]
        [MinLength(3, ErrorMessage = "Name length can't be more less than 3 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please use english letters only.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [MaxLength(12, ErrorMessage = "Name length can't be more than 12 characters.")]
        [MinLength(3, ErrorMessage = "Name length can't be more less than 3 characters.")]
        public string Nickname { get; set; }
        public string Avatar { get; set; }
        //public DateTime DateRegistered { get; set; }
    }
}