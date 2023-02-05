using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using RestfullAPI.Interfaces;

namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProductContext _context;

        public UserController(ProductContext context)
        {
            _context = context;
        }
  
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(User login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == login.Username.ToLower());
            if(user == null)
            {
                return Unauthorized("Kullanıcı adı yanlış");
            }
            var password = await _context.Users.FirstOrDefaultAsync(x => x.Password == login.Password.ToLower());
            if(password == null)
            {
                return Unauthorized("Parola yanlış");
            }
            return Ok("Giriş Başarılı");
        }
    }
}
