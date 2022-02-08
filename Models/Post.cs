using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace aspmvc.Models{
    public class Post{
        
        public long Id { get; set; }
        
        [Required]
        [StringLength(100,MinimumLength = 5,ErrorMessage = "Title must be between 5 and 100 characters long")]
        public string Title {get;set;}
        public string? Author {get;set;}
        [Required]
        [StringLength(100,ErrorMessage = "Body must be at least 100 characters long")]
        public string Body {get;set;}
        public DateTime Posted {get;set;}
        
       
    }
}