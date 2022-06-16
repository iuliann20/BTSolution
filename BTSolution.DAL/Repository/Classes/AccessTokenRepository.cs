using BTSolution.DAL.Entities;
using BTSolution.DAL.Repository.Interfaces;
using BTSolution.TL.DTOs;
using System.Data;

namespace BTSolution.DAL.Repository.Classes
{
    public class AccessTokenRepository : IAccessTokenRepository
    {
        private readonly BTSolutionDbContext _dbContext;

        public AccessTokenRepository(BTSolutionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AccessTokenDTO AddToken(AccessTokenDTO accessTokenDTO)
        {
            AccessToken accessToken = new AccessToken
            {
                CreationDate = DateTime.Now,
                Duration = accessTokenDTO.Duration,
                Token = accessTokenDTO.Token,
                UserId = accessTokenDTO.UserId
            };
            _dbContext.Add(accessToken);
            _dbContext.SaveChanges();
            return new AccessTokenDTO
            {
                CreationDate = accessToken.CreationDate,
                Duration = accessToken.Duration,
                Token = accessToken.Token,
                TokenId = accessToken.TokenId,
                UserId = accessToken.UserId,
                IsValid = accessToken.CreationDate.AddSeconds(accessToken.Duration) > DateTime.Now ? true : false
            };
        }

        public AccessTokenDTO GetToken(string token)
        {
            AccessToken accessToken = _dbContext.AccessTokens.FirstOrDefault(x => x.Token == token);
            if(accessToken == null)
            {
                throw new Exception();
            }
            AccessTokenDTO accessTokenDTO = new AccessTokenDTO
            {
                CreationDate = accessToken.CreationDate,
                Duration = accessToken.Duration,
                TokenId = accessToken.TokenId,
                Token = accessToken.Token,
                UserId = accessToken.UserId,
                IsValid = accessToken.CreationDate.AddSeconds(accessToken.Duration)>DateTime.Now ? true : false
            };
            return accessTokenDTO;
        }
        public AccessTokenDTO GetTokenByUserId(int userId)
        {
            AccessToken accessToken = _dbContext.AccessTokens.FirstOrDefault(x => x.UserId == userId);
            if (accessToken != null)
            {
                return new AccessTokenDTO
                {
                    TokenId = accessToken.TokenId,
                    CreationDate = accessToken.CreationDate,
                    Token = accessToken.Token,
                    Duration = accessToken.Duration,
                    UserId = userId,
                    IsValid = accessToken.CreationDate.AddSeconds(accessToken.Duration) > DateTime.Now ? true : false
                };
            }
            else
            {
                throw new DataException();
            }
        }

        public List<AccessTokenDTO> GetAllValidTokensByUserId(int id)
        {
            List<AccessTokenDTO> accessTokensDTO = _dbContext.AccessTokens.Select(x => new AccessTokenDTO
            {
                CreationDate = x.CreationDate,
                Duration = x.Duration,
                TokenId = x.TokenId,
                Token = x.Token,
                UserId = x.UserId,
                IsValid = x.CreationDate.AddSeconds(x.Duration) > DateTime.Now ? true : false
            }).Where(x => x.CreationDate.AddSeconds(x.Duration) > DateTime.Now).ToList();
            return accessTokensDTO;
        }

        public void DeleteTokenById(int id)
        {
            AccessToken accessToken = _dbContext.AccessTokens.FirstOrDefault(x => x.TokenId == id);
            if (accessToken != null)
            {
                _dbContext.Remove(accessToken);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new DataException();
            }
        }
        
    }
}
