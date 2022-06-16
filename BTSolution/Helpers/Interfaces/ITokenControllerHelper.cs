using BTSolution.TL.DTOs;

namespace BTSolution.Helpers.Interfaces
{
    public interface ITokenControllerHelper
    {
        AccessTokenDTO BuildAccessTokenDTO(string token, int userId);
    }
}
