using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Proyecto_Cliente.Repositories;
using Proyecto_Cliente.Models;
using Proyecto_Cliente.Entities;
using System.Data.SqlClient;

namespace Proyecto_Cliente.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("userInsert")]
        public ActionResult UserInsert([FromForm] string rut, [FromForm] string nombre, [FromForm] string apellido, [FromForm] string email, [FromForm] string password, [FromForm] string token)
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "UserInsert");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "UserInsert");
            }
            #endregion

            Proyecto_Cliente.Repositories.Usuario usu = new Proyecto_Cliente.Repositories.Usuario();
            //string token = log.LoginByToken(loginToken);
            bool user = usu.userInsert(rut, nombre, apellido, email, password);

            if (user) { return Ok("Usuario Ingresado correctamente."); }
            else { return BadRequest("No se pudo ingresar el usuario, intente nuevamente."); }
        }

        [HttpGet("getUsuarios")]
        public async Task<ActionResult> getUsuarios(string nombre, string token, string parametros = "")
        {

            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "getUsuarios");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "getUsuarios");
            }
            #endregion

            GetData gd = new GetData();
            string resultado = await gd.GetDbData(nombre, parametros);
            if (resultado == "NotFound" || resultado.Equals("0"))
            {
                return NotFound($"El método {nombre} no se ha encontrado");
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpGet("GetLogsByRut")]
        public async Task<ActionResult> GetLogsByRut(string user, string fecha, string token)
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "GetLogsByRut");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "GetLogsByRut");
            }
            #endregion

            #region Valida Admin
            var Email = Login.GetEmailUsuarioFromTokenValidate(token);
            string Nombre = "Admin";
            string isAdmin = "getAdmin";
            GetData gd = new GetData();
            string resultado = await gd.GetDbData(isAdmin, "nombre:" + Nombre + '|' + "email:" + Email);

            if (resultado == "NotFound" || resultado.Equals("0"))
            {
                return NotFound($"No tiene permisos necesarios.");
            }
            #endregion

            Proyecto_Cliente.Repositories.Log_Bitacora usuario = new Proyecto_Cliente.Repositories.Log_Bitacora();
            //string token = log.LoginByToken(loginToken);
            string usuario_ = usuario.GetLogsByRut(user, fecha);

            if (usuario_ != "0") { return Ok(usuario_); }
            else { return BadRequest("Hubo un problema al ejecutar la acción."); }

        }



    }
}
