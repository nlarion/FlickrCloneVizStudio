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
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IHostingEnvironment _env;

        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager, ApplicationDbContext db, IHostingEnvironment env)
        {
            _userManager = userManager;
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());

            var theView = _db.Profile
                .Where(x => x.User.Id == currentUser.Id);

            return View(theView);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_env.WebRootPath, "Images");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    await file.SaveAsAsync(Path.Combine(uploads, fileName));
                }
            }
            return View();
        }
    }
}
