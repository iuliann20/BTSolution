using BTSolution.TL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.DAL.Repository.Interfaces
{
    public interface IAccessTokenRepository
    {
        AccessTokenDTO AddToken(AccessTokenDTO accessTokenDTO);
        AccessTokenDTO GetTokenByUserId(int userId);
        List<AccessTokenDTO> GetAllValidTokensByUserId(int id);
        void DeleteTokenById(int id);
        AccessTokenDTO GetToken(string token);
        void DeleteInvalidTokensByUserId(int userId);
    }
}
