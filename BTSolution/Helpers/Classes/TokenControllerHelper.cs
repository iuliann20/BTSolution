using BTSolution.Helpers.Interfaces;
using BTSolution.TL.DTOs;

namespace BTSolution.Helpers.Classes
{
    public class TokenControllerHelper: ITokenControllerHelper
    {
        public AccessTokenDTO BuildAccessTokenDTO(string token, int userId)
        {
            AccessTokenDTO accessTokenDTO = new AccessTokenDTO
            {
                CreationDate = DateTime.Now,
                Duration = 30,
                Token = token,
                UserId = userId
            };
            return accessTokenDTO;
        }
    }
}
