using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace aspmvc.Controllers
{
    public class HelloController:Controller 
    {
        // 
        // GET: /Hello/

        [HttpGet("Hello/")]
        public IActionResult Index(){
            return new ContentResult {Content ="Hello"};
        }
        
        [HttpGet("Hello/Welcome")]
        public IActionResult Welcome(){
            return new ContentResult {Content ="welcome"};
        }
    }
}
