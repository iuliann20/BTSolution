using BTSolution.BL.Interfaces;
using BTSolution.DAL.Repository.Interfaces;
using BTSolution.TL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.BL.Classes
{
    public class TokenLogic: ITokenLogic
    {
        private readonly IAccessTokenRepository _accessTokenRepository;

        public TokenLogic(IAccessTokenRepository accessTokenRepository)
        {
            _accessTokenRepository = accessTokenRepository;
        } 

        public AccessTokenDTO AddToken(AccessTokenDTO accessTokenDTO)
        {
            AccessTokenDTO accessToken=_accessTokenRepository.AddToken(accessTokenDTO);
            return accessToken;
        }

        public AccessTokenDTO GetTokenByUserId(int userId)
        {
            AccessTokenDTO accessToken= _accessTokenRepository.GetTokenByUserId(userId);
            return accessToken;
        }

        public List<AccessTokenDTO> GetAllValidTokensByUserId(int id)
        {
            List<AccessTokenDTO> accessTokenDTOs= _accessTokenRepository.GetAllValidTokensByUserId(id);
            return accessTokenDTOs;
        }

        public void DeleteTokenById(int id)
        {
            _accessTokenRepository.DeleteTokenById(id);
        }

        public string GenerateOTP()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string smallAlphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";
            string characters = alphabets + smallAlphabets + numbers;
            string otp = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }
    }
}
