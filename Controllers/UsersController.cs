using BAL_Tutorial.Services;
using DAL_Tutorial.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tutorials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<User> AddUser(User user)
        {
            try
            {
                var createdUser = await _userService.AddUser(user);
                return createdUser;


            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;

            }
        }
        [HttpDelete]
        public bool DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }
        [HttpPut]
        public bool UpdateUser(int id, User user)
        {
            var oldUser = _userService.GetUserById(id);
            if (oldUser == null)
            {
                return false;
            }

            _userService.UpdateUser(user);
            return true;
        }
        [HttpGet("test")]

        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userService.GetAllUsers();

        }
    }
}
