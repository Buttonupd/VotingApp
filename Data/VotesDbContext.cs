using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingApp.Data
{
    public class VotesDbContext :DbContext
    {
        public VotesDbContext(DbContextOptions<VotesDbContext> options):base(options)
        {
            
        }

        public DbSet<UserVotesIncrement> uservotesIncrement { get; set; }
    }
}
