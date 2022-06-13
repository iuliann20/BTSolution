using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.DAL.Entities
{
    public class AccessToken
    {
        [Key]
        public int TokenId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Duration { get; set; }
        public string Token { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
