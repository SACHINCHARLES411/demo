using demo.Data;
using demo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly APIContext _aPIContext;

        public UserController(APIContext aPIContext)
        {
            _aPIContext = aPIContext;
        }

        [HttpPost("postUser")]

        public IActionResult postuser(PostUser user)
        {
            var users = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };
            _aPIContext.Add(users);
            _aPIContext.SaveChanges();
            return Ok(user);
        }

        [HttpGet("GetAllUser")]

        public IActionResult GetUser()
        {
            return Ok(_aPIContext.users.ToList());
        }

        [HttpPut("{id}UpdateUser")]

        public IActionResult updateUser(int id,User user)
        {
            var users = _aPIContext.users.Find(id);

            if(users != null)
            {
                user.id= id;
                users.Name = user.Name;
                users.Email= user.Email;
                users.Password = user.Password;

                _aPIContext.SaveChanges();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpDelete("{id}RemoveUser")]

        public IActionResult removeuser(int id)
        {
            var users = _aPIContext.users.Find(id);

            if (users != null)
            {
                _aPIContext.Remove(users);
                _aPIContext.SaveChanges();
                return Ok("User Removed Successfully");
            }
            return NotFound();
        }
    }
}
