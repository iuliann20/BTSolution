using BTSolution.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenLogic _tokenLogic;

        public TokenController(ITokenLogic tokenLogic)
        {
            _tokenLogic = tokenLogic;
        }
        
    }
}
