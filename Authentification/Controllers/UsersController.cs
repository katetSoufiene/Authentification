using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentification.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTAuthenticationManager authenticationManager;

        public UsersController(IJWTAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        // GET: api/<UsersController>
        [HttpGet]
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("authentificat")]
        [AllowAnonymous]
        public IActionResult Authentificat([FromBody] User user)
        {
            var token = authenticationManager.Authetificate(user.Name, user.Password);

            if (token == null) return Unauthorized();

            return Ok(token);
        }



    }
}
