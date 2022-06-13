using BTSolution.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSolution.DAL
{
    public class BTSolutionDbContext:DbContext
    {
        public BTSolutionDbContext(DbContextOptions<BTSolutionDbContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<AccessToken> AccessTokens { get; set; }
    }
}
