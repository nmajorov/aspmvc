using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using aspmvc.Models;
namespace aspmvc.Controllers
{
    [Route("Hello")]
    public class HelloController:Controller 
    {
        [Route("")]
        public IActionResult Index(){
            return new ContentResult {Content ="Hello"};
        }
        
        [Route("Welcome")]
        public IActionResult Welcome(){
            return new ContentResult {Content ="welcome"};
        }


        [Route("blog/{year:int}/{month:int}/{key}")]
        public IActionResult Post(int year,int month,string key){
            var post = new Post{
                Author ="Nikolaj Majorov",
                Title ="ASP MVC NET",
                Posted = DateTime.Now,
                Body = "this is a great post"
            };
            
            return View(post);
        }
    }
}
