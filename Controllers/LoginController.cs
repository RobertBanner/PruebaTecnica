using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Proyecto_Cliente.Repositories;

namespace Proyecto_Cliente.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("getTokenLogin")]
        public ActionResult GetTokenLogin([FromForm] string email, [FromForm] string password)
        {
            Log_Bitacora.InsertLog("", "Se genera token de validación para correo: " + email);
            Login log = new Login();
            return Ok(log.getTokenLogin(email, password));
        }

        [HttpPost("loginByToken")]
        public ActionResult LoginByToken([FromForm] string loginToken)
        {
            Log_Bitacora.InsertLog("", "Se genera token de validación");
            Login log = new Login();
            string token = log.LoginByToken(loginToken);

            switch (token)
            {
                case "-1": return BadRequest("Límite de tiempo excedido");
                case "-2": return BadRequest("Usuario o clave incorrectos");
                case "-3": return BadRequest("No se pudo hacer el login, revise los datos enviados");
                default: return Ok(token);
            }
        }



    }
}
