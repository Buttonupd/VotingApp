using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// Create a database reference file
namespace VotingApp.Models
{

    public class UserRequest
    {
        public int Id { get; set; }

        public String Username { get; set; }

        public bool Voted { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public  int VoteCounter { get; set; }

    }
}
