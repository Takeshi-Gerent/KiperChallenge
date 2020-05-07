using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Api.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthService authService;

        public UserController(AuthService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest user)
        {
            var token = authService.Authenticate(user.Login, user.Password);

            if (token == null)
                return BadRequest(new { message = "Usuário ou senha incorreta" });

            return Ok(new { Token = token });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(authService.UserFromUserName(HttpContext.User.Identity.Name));
        }
    }
}