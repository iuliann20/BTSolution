using BTSolution.Helpers.Interfaces;
using BTSolution.TL.DTOs;

namespace BTSolution.Helpers.Classes
{
    public class UserControllerHelper : IUserControllerHelper
    {
        public UserDTO BuildUserDTO(string username)
        {
            return new UserDTO
            {
                UserName = username
            };
        }

    }
}
