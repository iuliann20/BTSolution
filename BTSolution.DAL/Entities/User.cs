using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.DAL.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
