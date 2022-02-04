using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

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
            return new ContentResult { Content = string.Format("Year: {0}; Month {1}; Key: {2}",year,month,key)};  
        }
    }
}
