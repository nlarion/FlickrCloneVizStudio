using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlickrClone.Models;
using Xunit;

namespace FlickR.Tests
{
    public class ProfileTest
    {
        [Fact]
        public void GetProfileIdTest()
        {
            //Arrange
            var id = new Category();
            id.ProfileId = 1;

            //Act
            var result = id.ProfileId;

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetPhotosFromProfile()
        {
            var testPhoto = new Photo();
            testPhoto.PhotoId = 1;

            var result = testPhoto.PhotoId;

            Assert.Equal(1, result);
        }
    }
}
