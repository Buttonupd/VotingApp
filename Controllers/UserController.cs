using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingApp.Data;
using VotingApp.Models;

namespace VotingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Reference DB calls

        private VotesDbContext _dbContext;

        public UserController(VotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Retrive users : Get request
        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            UserVotesIncrement user = new UserVotesIncrement();

            // use a try-catch block to mitigate common connection exceptions
            try
            {
                // Test * Optimize : Switch Staments/TernaryOp

                if (user.Voted == true)
                {
                    user.VoteCounter = 1;
                }

                else
                {
                    user.VoteCounter = 0;
                }

                var users = _dbContext.uservotesIncrement.ToList();
                if(users.Count  == 0)
                {
                    return StatusCode(404, "User not found");
                }

                return Ok(users);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occured !");
            }

            
            /*var users = GetUsers();*/
          
        }
        // Create Users : Post request 
        [HttpPost("CreateUser")]

        public IActionResult Create([FromBody] UserRequest request)
        {
            UserVotesIncrement user = new UserVotesIncrement();

            user.Id = request.Id; // Optimize database (non-assigned field) as request param
            user.Username = request.Username;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.VoteCounter = request.VoteCounter;
       
            try
            {
                _dbContext.uservotesIncrement.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Something went wrong");
            }
            var users = _dbContext.uservotesIncrement.ToList();
            return Ok(users);
           
        }
        // Update Users : Put request
       [HttpPut("UpdateUsers")]

       public IActionResult Update([FromBody] UserRequest request)
        {
            try
            {
                var user = _dbContext.uservotesIncrement.FirstOrDefault(x => x.Id == request.Id);

                if(user == null)
                {
                    return StatusCode(400, "User not found");
                }

                user.Username = request.Username;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.VoteCounter = request.VoteCounter;
                var Checker = user.Voted;
               

                // Restrict Multiple Votes from a single user 

                if (user.VoteCounter > 1)
                {
                    Checker = true;
                    return StatusCode(403, "Votes can only be cast once "); 
                }

                else
                {

                    _dbContext.Entry(user).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Something went wrong");
            }
            var users = _dbContext.uservotesIncrement.ToList();
            return Ok(users);
        }
        // Delete Users : Delete Requests
        [HttpDelete("DeleteUser/{Id}")]

        public IActionResult Delete([FromRoute]int Id)
        {
            try
            {
                var user = _dbContext.uservotesIncrement.FirstOrDefault(x => x.Id == Id);

                if (user == null)
                {
                    return StatusCode(400, "User not found");
                }

                _dbContext.Entry(user).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Something went wrong");
            }
            var users = _dbContext.uservotesIncrement.ToList();
            return Ok(users);
        }

       /* private List <UserRequest> GetUsers()
        {
            return new List<UserRequest> {
                new UserRequest {Username = "JD", FirstName="Billy"},
                new UserRequest {Username = "JD", FirstName="Billy"},
                new UserRequest {Username = "JD", FirstName="Billy"}
            };
        }*/
    }
}
