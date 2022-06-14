using BTSolution.TL.DTOs;

namespace BTSolution.Helpers.Interfaces
{
    public interface IUserControllerHelper
    {
        UserDTO BuildUserDTO(string username);
    }
}
