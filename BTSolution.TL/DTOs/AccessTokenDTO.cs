using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.TL.DTOs
{
    public class AccessTokenDTO
    {
        public int TokenId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Duration { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
        public bool IsValid { get; set; }
    }
}
