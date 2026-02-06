using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        //[Authorize] Solo autenticación general
        //[Authorize(Roles = "Admin")] Restringir por roles (si se usan roles en el token)
        [AllowAnonymous]  //Permitir acceso a cualquiera
        [HttpGet]
        public IActionResult GetValues()
        {
            return Ok( new string[] {"Value1","Value2"});
        }
        [Authorize]
        [HttpGet("perfil")]
        public IActionResult Perfil()
        {
            return Ok("Acceso permitido");
        }

    }
}
