using BTSolution.TL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.BL.Interfaces
{
    public interface ITokenLogic
    {
        AccessTokenDTO AddToken(AccessTokenDTO accessTokenDTO);
        AccessTokenDTO GetTokenByUserId(int userId);
        List<AccessTokenDTO> GetAllValidTokensByUserId(int id);
        void DeleteTokenById(int id);
        string GenerateOTP();
        AccessTokenDTO GetToken(string token);
    }
}
