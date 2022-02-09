using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using aspmvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace aspmvc.Controllers
{
    [Route("Blog")]
    public class BlogController : Controller
    {
        private readonly BlogDBContext _db;

        public BlogController(BlogDBContext db)
        {
            _db = db;
        }

        [Route("")]
        public IActionResult Index()
        {
            var posts = _db.Posts.OrderByDescending(x => x.Posted).Take(5).ToArray();

            return View(posts);
        }

        [Route("Welcome")]
        public IActionResult Welcome()
        {
            return new ContentResult {Content = "welcome"};
        }


        [Route("{year:int}/{month:int}/{key}")]
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

        [Authorize]
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
                return RedirectToAction("Index");
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