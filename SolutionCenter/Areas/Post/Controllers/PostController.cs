using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.DatabaseContext;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;
using EntityLayer.Entites;

namespace SolutionCenter.Areas.Post.Controllers
{
    [Area("Post")]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        private readonly Context context;
        public PostController(IPostService postService, ICategoryService categoryService, IUserService userService, Context context)
        {
            this.categoryService = categoryService;
            this.postService = postService;
            this.userService = userService;
            this.context = context;
        }


        public IActionResult CreatePost()
        {
            var categories = categoryService.TGetListAll();
            ViewBag.category = categories;
            return View();

        }

        public IActionResult Index()
        {
            var posts = postService.TGetListAll();
            ViewBag.posts = posts;
            return View();
        }
        public IActionResult GetUser(string id)
        {
            var user = userService.GetUser(id);
            ViewBag.user = user;
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreatePost(EntityLayer.Entites.Post post)
        {
            var categoryIds = post.CategoryIDs;
            postService.Add(post, categoryIds);
            return RedirectToAction("CreatePost");
        }
       
        public IActionResult GetPost(Guid id)
        {
            var post = postService.TGetByID(id);
            ViewBag.post = post;
            var userid = post.AppUserId;
            var user = userService.GetUser(userid);
            ViewBag.user = user;
            return View();
        }

    }
}

