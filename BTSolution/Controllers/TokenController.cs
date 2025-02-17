﻿using BTSolution.BL.Interfaces;
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
            if (userId == 0)
            {
                return BadRequest();
            }
            string? token = _tokenLogic.GenerateOTP();
            AccessTokenDTO tokenDTO = _tokenLogic.AddToken(_tokenControllerHelper.BuildAccessTokenDTO(token, userId));
            return Ok(tokenDTO);
        }
        [HttpGet]
        [Route("CheckIfTokenIsValid/{token}")]
        public IActionResult CheckIfTokenIsValid(string token)
        {
            if (token == null)
            {
                return BadRequest();
            }
            var tokenFromDb = _tokenLogic.GetToken(token);
            return Ok(tokenFromDb);
        }

        [HttpGet]
        [Route("DeleteInvalidUserTokens/{userId}")]
        public IActionResult DeleteInvalidUserTokens(int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }
            _tokenLogic.DeleteInvalidTokensByUserId(userId);
            return Ok();

        }
    }
}
