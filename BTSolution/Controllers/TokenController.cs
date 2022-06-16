using BTSolution.BL.Interfaces;
using BTSolution.Helpers.Interfaces;
using BTSolution.TL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenLogic _tokenLogic;
        private readonly ITokenControllerHelper _tokenControllerHelper;

        public TokenController(ITokenLogic tokenLogic, ITokenControllerHelper tokenControllerHelper)
        {
            _tokenLogic = tokenLogic;
            _tokenControllerHelper = tokenControllerHelper;
        }
        [HttpGet]
        [Route("GenerateToken/{userId}")]
        public IActionResult GenerateToken(int userId)
        {
            string? token = _tokenLogic.GenerateOTP();
            AccessTokenDTO tokenDTO = _tokenControllerHelper.BuildAccessTokenDTO(token, userId);
            return Ok(_tokenLogic.AddToken(tokenDTO));
        }
        [HttpGet]
        [Route("GetToken/{token}")]
        public IActionResult GetToken(string token)
        {
            var tokenFromDb = _tokenLogic.GetToken(token);
            return Ok(tokenFromDb);
        }
    }
}
