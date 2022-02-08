using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using aspmvc.Models;

namespace aspmvc.Controllers
{
    [Route("Hello")]
    public class HelloController : Controller
    {
        private readonly BlogDBContext _db;

        public HelloController(BlogDBContext db)
        {
            _db = db;
        }

        [Route("")]
        public IActionResult Index()
        {
            return new ContentResult {Content = "Hello"};
        }

        [Route("Welcome")]
        public IActionResult Welcome()
        {
            return new ContentResult {Content = "welcome"};
        }


        [Route("blog/{year:int}/{month:int}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post
            {
                Author = "Nikolaj Majorov",
                Title = "ASP MVC NET",
                Posted = DateTime.Now,
                Body = "this is a great post"
            };

            return View(post);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(CreatePostRequest postRequest)
        {
            if (ModelState.IsValid)
            {
                var post = new Post();
                post.Author = User.Identity.Name;
                post.Posted = DateTime.Now.ToUniversalTime();
                post.Body = postRequest.Body;
                post.Title = postRequest.Title;
                _db.Posts.Add(post);
                _db.SaveChanges();
            }

            return View();
        }

        public class CreatePostRequest
        {
            public string Title { get; set; }
            public string Body { get; set; }
        }
    }
}