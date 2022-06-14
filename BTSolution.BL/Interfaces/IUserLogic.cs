using BTSolution.TL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.BL.Interfaces
{
    public interface IUserLogic
    {
        UserDTO AddUser(UserDTO userDTO);
        UserDTO GetUserByName(string userName);
        void DeleteUserById(int id);
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);
    }
}
