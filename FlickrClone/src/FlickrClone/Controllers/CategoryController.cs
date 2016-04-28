using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using FlickrClone.Models;
using Microsoft.Data.Entity;
using System.Security.Claims;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using System.IO;
using Microsoft.Net.Http.Headers;

namespace FlickrClone.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(UserManager<ApplicationUser> userManager, ApplicationDbContext db, IHostingEnvironment env)
        {
            _userManager = userManager;
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index(int id)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());

            var theView = await _db.Categories
                .FirstOrDefaultAsync(x => x.CategoryId == id);

            //ViewBag.Category = await _db.

            return View(theView);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file, Photo photo)
        {
           
            var uploads = Path.Combine(_env.WebRootPath, "Images");
            if (file != null)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                await file.SaveAsAsync(Path.Combine(uploads, fileName));
                var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
                photo.User = currentUser;
                photo.Location = Path.Combine(uploads, fileName);
                _db.Photos.Add(photo);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Category", new { id = photo.CategoryId });
        }
    }
}
