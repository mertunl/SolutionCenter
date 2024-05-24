using BusinessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using EntityLayer.Entites;
using EntityLayer.Enum;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace SolutionCenter.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        private readonly IPostService postService;
        private readonly IUserService userService;
        private readonly IOfferService offerService;
        private readonly UserManager<AppUser> userManager;
        private readonly Context context;

        public UserController(IPostService postService, IUserService userService, IOfferService offerService, UserManager<AppUser> userManager, Context context)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.offerService = offerService;
            this.postService = postService;
            this.context = context;

        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Profile()
        {
            var user = userManager.GetUserId(User);
            var userPost = context.Posts.Where(p => p.AppUserId == user).ToList();
            ViewBag.UserPost = userPost;
            return View();
        }
        public IActionResult GetPost()
        {
            var user = userManager.GetUserId(User);
            var userPost = context.Posts.Where(p => p.AppUserId == user).ToList();
            ViewBag.UserPost = userPost;
            return View();
        }
        public IActionResult GetAboutPost(Guid id)
        {
            
            var post = postService.TGetByID(id);
            ViewBag.post = post;
            var userid = post.AppUserId;
            var user = userService.GetUser(userid);
            ViewBag.user = user;
            return View();
        }
        public IActionResult GetStat()
        {
            var user = userManager.GetUserId(User);
            var PostCount = context.Posts.Count(p => p.AppUserId == user);
            var SendOfOfferCount = context.Offers.Count(p => p.AppUserId == user);
            var ReceivedOfOfferCount = context.Offers.Count(p => p.Offeree == user);
            ViewBag.PostOfNumber = PostCount;
            ViewBag.SendOfOffer = SendOfOfferCount;
            ViewBag.ReceivedOfOffer = ReceivedOfOfferCount;

            return View();
        }
        public IActionResult GetOffer()
        {
            var user = userManager.GetUserId(User);
                var posts = context.Offers
                .Where(o => o.Offeree == user && o.OfferStatus==OfferStatus.Pending)
                .Select(o => new { PostID = o.PostID, Price = o.Price ,AppUserId =o.AppUserId,OfferID = o.OfferID,OfferStatus=o.OfferStatus})
                .Distinct()
                .ToList();

            var userPosts = new List<UserPostViewModel>();

            foreach (var postInfo in posts)
            {
                var post = postService.TGetByID(postInfo.PostID);

                var postByName = userService.GetUser(postInfo.AppUserId).Select(n => n.Name).FirstOrDefault();

                if (post != null)
                {
                    var userPostViewModel = new UserPostViewModel
                    {
                        Name = postByName,
                        Title = post.Title,
                        Content = post.Content,
                        Price = postInfo.Price,
                        OfferID = postInfo.OfferID,
                        OfferStatus = postInfo.OfferStatus,
                    };

                    userPosts.Add(userPostViewModel);
                }
            }

            ViewBag.UserPosts = userPosts;
  
            return View();
        }

        public IActionResult GetMyAcceptOffer()
        {
            var user = userManager.GetUserId(User);
            var posts = context.Offers
            .Where(o => o.Offeree == user && o.OfferStatus == OfferStatus.Approved)
            .Select(o => new { PostID = o.PostID, Price = o.Price, AppUserId = o.AppUserId, OfferID = o.OfferID, OfferStatus = o.OfferStatus})
            .Distinct()
            .ToList();

            var userPosts = new List<UserPostViewModel>();

            foreach (var postInfo in posts)
            {
                var post = postService.TGetByID(postInfo.PostID);

                var postByName = userService.GetUser(postInfo.AppUserId).Select(n => n.Name).FirstOrDefault();

                if (post != null)
                {
                    var userPostViewModel = new UserPostViewModel
                    {
                        Name = postByName,
                        Title = post.Title,
                        Content = post.Content,
                        Price = postInfo.Price,
                        OfferID = postInfo.OfferID,
                        OfferStatus = postInfo.OfferStatus,
                    };

                    userPosts.Add(userPostViewModel);
                }
            }

            ViewBag.UserPosts = userPosts;


            return View();
        }
        public IActionResult GetMyRejectedOffer()
        {
            var user = userManager.GetUserId(User);
            var posts = context.Offers
            .Where(o => o.Offeree == user && o.OfferStatus == OfferStatus.Rejected)
            .Select(o => new { PostID = o.PostID, Price = o.Price, AppUserId = o.AppUserId, OfferID = o.OfferID, OfferStatus = o.OfferStatus })
            .Distinct()
            .ToList();

            var userPosts = new List<UserPostViewModel>();

            foreach (var postInfo in posts)
            {
                var post = postService.TGetByID(postInfo.PostID);

                var postByName = userService.GetUser(postInfo.AppUserId).Select(n => n.Name).FirstOrDefault();

                if (post != null)
                {
                    var userPostViewModel = new UserPostViewModel
                    {
                        Name = postByName,
                        Title = post.Title,
                        Content = post.Content,
                        Price = postInfo.Price,
                        OfferID = postInfo.OfferID,
                        OfferStatus = postInfo.OfferStatus,
                    };

                    userPosts.Add(userPostViewModel);
                }
            }

            ViewBag.UserPosts = userPosts;


            return View();
        }
        public IActionResult GetAcceptOffer()
        {
            var user = userManager.GetUserId(User);
            var posts = context.Offers
            .Where(o => o.AppUserId == user && o.OfferStatus == OfferStatus.Approved)
            .Select(o => new { PostID = o.PostID, Price = o.Price, AppUserId = o.AppUserId, OfferID = o.OfferID, OfferStatus = o.OfferStatus,Offeree=o.Offeree })
            .Distinct()
            .ToList();

            var userPosts = new List<UserPostViewModel>();

            foreach (var postInfo in posts)
            {
                var post = postService.TGetByID(postInfo.PostID);

                var postByName = userService.GetUser(postInfo.Offeree).Select(n => n.Name).FirstOrDefault();

                if (post != null)
                {
                    var userPostViewModel = new UserPostViewModel
                    {
                        Name = postByName,
                        Title = post.Title,
                        Content = post.Content,
                        Price = postInfo.Price,
                        OfferID = postInfo.OfferID,
                        OfferStatus = postInfo.OfferStatus,
                    };

                    userPosts.Add(userPostViewModel);
                }
            }

            ViewBag.UserPosts = userPosts;


            return View();
        }
        public IActionResult GetRejectedOffer()
        {
            var user = userManager.GetUserId(User);
            var posts = context.Offers
            .Where(o => o.AppUserId == user && o.OfferStatus == OfferStatus.Rejected)
            .Select(o => new { PostID = o.PostID, Price = o.Price, AppUserId = o.AppUserId, OfferID = o.OfferID, OfferStatus = o.OfferStatus, Offeree = o.Offeree })
            .Distinct()
            .ToList();

            var userPosts = new List<UserPostViewModel>();

            foreach (var postInfo in posts)
            {
                var post = postService.TGetByID(postInfo.PostID);

                var postByName = userService.GetUser(postInfo.Offeree).Select(n => n.Name).FirstOrDefault();

                if (post != null)
                {
                    var userPostViewModel = new UserPostViewModel
                    {
                        Name = postByName,
                        Title = post.Title,
                        Content = post.Content,
                        Price = postInfo.Price,
                        OfferID = postInfo.OfferID,
                        OfferStatus = postInfo.OfferStatus,
                    };

                    userPosts.Add(userPostViewModel);
                }
            }

            ViewBag.UserPosts = userPosts;


            return View();
        }
        public IActionResult OfferNavBar()
        {

            return View();
        }
        public IActionResult GetMyOffer()
        {
            var user = userManager.GetUserId(User);
            var posts = context.Offers
                .Where(o => o.AppUserId == user)
                .Select(o => new { PostID = o.PostID, Price = o.Price,OfferStatus=o.OfferStatus})
                .Distinct()
                .ToList();
            var userPosts = new List<UserPostViewModel>();

            foreach (var postInfo in posts)
            {
                var post = postService.TGetByID(postInfo.PostID);/*context.Posts.FirstOrDefault(p => p.PostID == postInfo.PostID);*/

                var postByName = userService.GetUser(post.AppUserId).Select(n => n.Name).FirstOrDefault();

                if (post != null)
                {
                    var userPostViewModel = new UserPostViewModel
                    {
                        Name = postByName,
                        Title = post.Title,
                        Content = post.Content,
                        Price = postInfo.Price,
                        OfferStatus = postInfo.OfferStatus
                    };

                    userPosts.Add(userPostViewModel);
                }
            }

            ViewBag.UserPosts = userPosts;

            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


    }
}
