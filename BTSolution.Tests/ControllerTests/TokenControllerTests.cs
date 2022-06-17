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
    internal class TokenControllerTests
    {
        private Mock<ITokenLogic> _tokenLogic;
        private Mock<ITokenControllerHelper> _tokenControllerHelper;
        private TokenController _tokenController;

        [SetUp]
        public void Setup()
        {
            _tokenLogic = new Mock<ITokenLogic>();
            _tokenControllerHelper = new Mock<ITokenControllerHelper>();
            _tokenController = new TokenController(_tokenLogic.Object, _tokenControllerHelper.Object);
        }

        [Test]
        public void GenerateToken_Return_BadRequest()
        {
            int userId = 0;
            var result = _tokenController.GenerateToken(userId) as StatusCodeResult;
            Assert.That(result.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void GenerateToken_Return_AccessTokenDTO()
        {
            AccessTokenDTO accessTokenDTO = new AccessTokenDTO
            {
                UserId=6,
                Duration=30,
                Token = "P23ncD"
            };
            _tokenLogic.Setup(x => x.AddToken(It.IsAny<AccessTokenDTO>())).Returns(accessTokenDTO).Verifiable();
            _tokenControllerHelper.Setup(x => x.BuildAccessTokenDTO(accessTokenDTO.Token,accessTokenDTO.UserId)).Returns(accessTokenDTO).Verifiable();
            var result = _tokenController.GenerateToken(accessTokenDTO.UserId) as OkObjectResult;
            Assert.That(result.StatusCode, Is.EqualTo(200));
            var model = result.Value as AccessTokenDTO;
            Assert.That(model.UserId, Is.EqualTo(accessTokenDTO.UserId));
            Assert.That(model.Duration, Is.EqualTo(accessTokenDTO.Duration));
            Assert.That(model.Token, Is.EqualTo(accessTokenDTO.Token));



        }
    }
}
