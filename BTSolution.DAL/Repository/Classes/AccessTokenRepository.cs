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
                Duration = accessTokenDTO.Duration,
                Token = accessTokenDTO.Token,
                TokenId = accessTokenDTO.TokenId,
                UserId = accessTokenDTO.UserId
            };
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
                    UserId = userId
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
                UserId = x.UserId
            }).Where(x => x.CreationDate.AddSeconds(x.Duration) > DateTime.Now).ToList();
            return accessTokensDTO;
        }
    }
}
