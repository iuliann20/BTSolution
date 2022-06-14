using BTSolution.BL.Interfaces;
using BTSolution.Helpers.Interfaces;
using BTSolution.TL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        private readonly IUserControllerHelper _userControllerHelper;

        public UserController(IUserLogic userLogic, IUserControllerHelper userControllerHelper)
        {
            _userLogic = userLogic;
            _userControllerHelper = userControllerHelper;
        }

        /// <summary>
        /// Adds the user to the db
        /// </summary>
        /// <param name="user">user object to be added</param>
        [HttpPost("{userName}")]
        public IActionResult AddUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest();
            }

            UserDTO user = _userLogic.AddUser(_userControllerHelper.BuildUserDTO(userName));
            return Ok(user);
        }

        /// <summary>
        ///     Returns all the users from the db
        /// </summary>
        [HttpGet]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            var userList = _userLogic.GetAllUsers();
            return Ok(userList);
        }

        /// <summary>
        /// Removes the user from the db
        /// </summary>
        /// <param name="userId"></param>
        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(int userId)
        {
            if (userId < 0)
            {
                return BadRequest();
            }

            _userLogic.DeleteUserById(userId);

            return Ok();
        }
    }
}
