using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingApp.Data
{
    
    public class UserVotesIncrement
    {
        

        public int Id { get; set; }

        public String Username { get; set; }
        
        public bool Voted { get; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int VoteCounter { get; set; }
    }
}

