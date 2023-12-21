using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Proyecto_Cliente.Entities;
using Proyecto_Cliente.Repositories;

namespace Proyecto_Cliente.Controllers
{
    public class ServicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("ServicioAsignar")]
        public async Task<ActionResult> ServicioAsignarAsync(string rut, string nombre_servicio, string anio, string token)
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "ServicioAsignarAsync");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "ServicioAsignarAsync");
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

            Proyecto_Cliente.Repositories.Servicio servicio = new Proyecto_Cliente.Repositories.Servicio();
            bool user = servicio.ServicioAsignar(rut, nombre_servicio, anio);

            if (user) { return Ok("Asignación de servicio realizada correctamente."); }
            else { return BadRequest("No se pudo generar la acción."); }
        }

        [HttpPost("InsServicio")]
        public async Task<ActionResult> InsServicio(string nombre, string token, string parametros = "")
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "InsServicio");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "InsServicio");
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

            if (nombre != "InsServicio")
            {
                return NotFound($"El método {nombre} no se ha encontrado");
            }

            GetData gd_ = new GetData();
            string resultado_ = await gd.GetDbData(nombre, parametros);

            if (resultado_ == "NotFound" || resultado_.Equals("0"))
            {
                //return NotFound($"El método {nombre} no se ha encontrado");
                return Ok("Servicio agregado.");
            }
            else
            {
                return Ok("No se pudo ejecutar la acción.");
            }
        }

        [HttpGet("GetAsignacionByRut")]
        public Task<ActionResult> GetAsignacionByRut(string rut)
        {
            //Clases.Log.LogWrite($"LoginByToken: loginToken={loginToken}");


            Proyecto_Cliente.Repositories.Servicio servicio = new Proyecto_Cliente.Repositories.Servicio();
            //string token = log.LoginByToken(loginToken);
            string servicio_ = servicio.GetAsignacionByRut(rut);

            if (servicio_ != "0") { return Task.FromResult<ActionResult>(Ok(servicio_)); }
            else { return Task.FromResult<ActionResult>(BadRequest("Hubo un problema al ejecutar la acción.")); }

        }

        [HttpGet("GetAsignacion")]
        public async Task<ActionResult> GetAsignacion(string rut, string token)
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "GetAsignacion");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "GetAsignacion");
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

            Proyecto_Cliente.Repositories.Servicio servicio = new Proyecto_Cliente.Repositories.Servicio();
            //string token = log.LoginByToken(loginToken);
            string servicio_ = servicio.GetAsignacionByRut(rut);

            if (servicio_ != "0") { return Ok(servicio_); }
            else { return BadRequest("Hubo un problema al ejecutar la acción."); }

        }

        [HttpPost("CreateServicioComuna")]
        public async Task<ActionResult> CreateServicioComuna(string nombre_comuna, string nombre_region, string nombre_servicio, string token)
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "CreateServicioComuna");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "CreateServicioComuna");
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

            Proyecto_Cliente.Repositories.Servicio servicio = new Proyecto_Cliente.Repositories.Servicio();
            //string token = log.LoginByToken(loginToken);
            if(nombre_comuna == null) { nombre_comuna = string.Empty; }
            if(nombre_region == null) {  nombre_region = string.Empty; }

            bool servicio_ = servicio.CreateServicioComuna(nombre_comuna, nombre_region, nombre_servicio);

            if (servicio_) { return Ok("Servicio Asignado a comuna correctamente."); }
            else { return BadRequest("No se pudo asignar el servicio a la comuna, intente nuevamente."); }

        }
    }
}
