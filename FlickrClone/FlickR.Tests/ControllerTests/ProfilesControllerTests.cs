//using System.Collections.Generic;
//using Microsoft.AspNet.Mvc;
//using Microsoft.Data.Entity;
//using FlickrClone.Controllers;
//using FlickrClone.Models;
//using Xunit;
//using System.Security.Claims;
//using Microsoft.AspNet.Authorization;
//using Microsoft.AspNet.Identity;


//namespace FlickR.Tests.ControllerTests
//{
//    public class ProfilesControllerTests
//    {
//        private readonly ApplicationDbContext _db;

//        private readonly UserManager<ApplicationUser> _userManager;
//        [Fact]
//        public void Get_ModelList_Index_Test()
//        {

//        //Arrange
//        ProfileController controller = new ProfileController(UserManager<ApplicationUser> userManager, ApplicationDbContext db);
//            IActionResult actionResult = controller.Index();
//            ViewResult indexView = controller.Index() as ViewResult;

//            //Act
//            var result = indexView.ViewData.Model;

//            //Assert
//            Assert.IsType<List<Photo>>(result);
           
//        }
//    }
//}
