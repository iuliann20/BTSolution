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
    public class UserLogic: IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO AddUser(UserDTO userDTO)
        {
            UserDTO user = _userRepository.AddUser(userDTO);
            return user;
        }

        public UserDTO GetUserByName(string userName)
        {
            UserDTO user = _userRepository.GetUserByName(userName);
            return user;
        }

        public void DeleteUserById(int id)
        {
            _userRepository.DeleteUserById(id);
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> users = _userRepository.GetAllUsers();
            return users;
        }

        public UserDTO GetUserById(int id)
        {
            UserDTO user = _userRepository.GetUserById(id);
            return user;
        }
    }
}
