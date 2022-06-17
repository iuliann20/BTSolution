using BTSolution.BL.Classes;
using BTSolution.BL.Interfaces;
using BTSolution.DAL.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.Tests.LogicTests
{
    internal class TokenLogicTests
    {
        private Mock<IAccessTokenRepository> _accessTokenRepository;
        private ITokenLogic _tokenLogic;
        [SetUp]
        public void Setup()
        {
            _accessTokenRepository = new Mock<IAccessTokenRepository>();
            _tokenLogic = new TokenLogic(_accessTokenRepository.Object);
        }

        [Test]
        public void GenerateToken_Test()
        {
            var result = _tokenLogic.GenerateOTP();
            Assert.That(result.Length, Is.EqualTo(6));
        }
    }
}
