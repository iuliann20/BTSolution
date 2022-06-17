using BTSolution.BL.Interfaces;
using BTSolution.Controllers;
using BTSolution.Helpers.Interfaces;
using BTSolution.TL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.Tests.ControllerTests
{
    public class UserControllerTests
    {
        private Mock<IUserLogic> _userLogic;
        private Mock<IUserControllerHelper> _userControllerHelper;
        private UserController _userController;

        [SetUp]
        public void Setup()
        {
            _userLogic = new Mock<IUserLogic>();
            _userControllerHelper = new Mock<IUserControllerHelper>();
            _userController = new UserController(_userLogic.Object, _userControllerHelper.Object);
        }

        [Test]
        public void AddUser_Return_BadRequest()
        {
            string userName = string.Empty;
            var result = _userController.AddUser(userName) as StatusCodeResult;
            Assert.That(result.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void AddUser_Return_UserDTO()
        {
            UserDTO userDTO = new UserDTO
            {
                UserId = 6,
                UserName = "iuliann20"
            };

            _userLogic.Setup(x => x.AddUser(It.IsAny<UserDTO>())).Returns(userDTO).Verifiable();
            _userControllerHelper.Setup(x => x.BuildUserDTO(It.IsAny<string>())).Returns(userDTO).Verifiable();
            var result = _userController.AddUser(userDTO.UserName) as OkObjectResult;
            Assert.That(result.StatusCode, Is.EqualTo(200));
            var model = result.Value as UserDTO;
            Assert.That(model.UserId, Is.EqualTo(userDTO.UserId));
            Assert.That(model.UserName, Is.EqualTo(userDTO.UserName));
            _userLogic.Verify(x => x.AddUser(It.IsAny<UserDTO>()), Times.Exactly(1));
            _userControllerHelper.Verify(x => x.BuildUserDTO(It.IsAny<string>()), Times.Exactly(1));

        }
    }
}
