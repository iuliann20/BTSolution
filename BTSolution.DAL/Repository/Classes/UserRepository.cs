using BTSolution.DAL.Entities;
using BTSolution.DAL.Repository.Interfaces;
using BTSolution.TL.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.DAL.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly BTSolutionDbContext _dbContext;

        public UserRepository(BTSolutionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserDTO AddUser(UserDTO userDTO)
        {
            User user = new User
            {
                UserName = userDTO.UserName
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName
            };
        }

        public UserDTO GetUserByName(string userName)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return null;
            }
            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName
            };
        }
        public void DeleteUserById(int id)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.UserId == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new DataException();
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> usersDTO = _dbContext.Users.Select(x => new UserDTO
            {
                UserId = x.UserId,
                UserName = x.UserName
            }).ToList();
            return usersDTO;
        }

        public UserDTO GetUserById(int id)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.UserId == id);
            if (user != null)
            {
                return new UserDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName
                };
            }
            else
            {
                throw new DataException();
            }
        }
    }
}
