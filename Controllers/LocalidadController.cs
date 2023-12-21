using Microsoft.AspNetCore.Mvc;
using Proyecto_Cliente.Repositories;
using System.Reflection;

namespace Proyecto_Cliente.Controllers
{
    public class LocalidadController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }

        #region Create
        [HttpPost("PaisCreate")]
        public async Task<ActionResult> PaisCreateAsync(string nombre, string token)
        {
            string emailUser = "";
            
            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "PaisCreateAsync");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "PaisCreateAsync");
            }

            #region Valida Admin
            var Email = Login.GetEmailUsuarioFromTokenValidate(token);
            string Nombre = "Admin";
            string isAdmin = "getAdmin";
            GetData gd = new GetData();
            string resultado = await gd.GetDbData(isAdmin, "nombre:" + Nombre + '|' + "email:" +  Email);

            if (resultado == "NotFound" || resultado.Equals("0"))
            {
                return NotFound($"No tiene permisos necesarios.");
            }
            #endregion

            Proyecto_Cliente.Repositories.Localidad pais = new Proyecto_Cliente.Repositories.Localidad();
            //string token = log.LoginByToken(loginToken);
            bool pais_ = pais.PaisInsert(nombre);

            if (pais_) { return Ok("País Ingresado correctamente."); }
            else { return BadRequest("No se pudo ingresar el país, intente nuevamente."); }

        }

        [HttpPost("RegionCreate")]
        public ActionResult RegionCreate(string nombre_region, string nombre_pais, string token)
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "RegionCreate");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "RegionCreate");
            }
            #endregion

            Proyecto_Cliente.Repositories.Localidad region = new Proyecto_Cliente.Repositories.Localidad();
            //string token = log.LoginByToken(loginToken);
            bool region_ = region.RegionInsert(nombre_region, nombre_pais);

            if (region_) { return Ok("Región Ingresada correctamente."); }
            else { return BadRequest("No se pudo ingresar la región, intente nuevamente."); }

        }

        [HttpPost("ComunaCreate")]
        public ActionResult ComunaCreate(string nombre_comuna, string nombre_region, string token)
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "ComunaCreate");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "ComunaCreate");
            }
            #endregion

            Proyecto_Cliente.Repositories.Localidad comuna = new Proyecto_Cliente.Repositories.Localidad();
            //string token = log.LoginByToken(loginToken);
            bool comuna_ = comuna.ComunaInsert(nombre_comuna, nombre_region);

            if (comuna_) { return Ok("Comuna Ingresada correctamente."); }
            else { return BadRequest("No se pudo ingresar la comuna, intente nuevamente."); }

        }
        #endregion

        #region Get
        [HttpGet("getLocalidades")]
        public async Task<ActionResult> getLocalidades(string nombre, string token, string parametros = "")
        {

            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "getLocalidades");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "getLocalidades");
            }
            #endregion

            if (nombre != "getlocalidades")
            {
                return NotFound($"El método {nombre} no se ha encontrado");
            }

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

        [HttpGet("getPaisbyNombre")]
        public async Task<ActionResult> getPaisbyNombre(string nombre, string token, string parametros = "")
        {

            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "getPaisbyNombre");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "getPaisbyNombre");
            }
            #endregion

            if (nombre != "getPaisbyNombre")
            {
                return NotFound($"El método {nombre} no se ha encontrado");
            }

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

        [HttpGet("getRegionbyNombre")]
        public async Task<ActionResult> getRegionbyNombre(string nombre, string token, string parametros = "")
        {

            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "getRegionbyNombre");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "getRegionbyNombre");
            }
            #endregion

            if (nombre != "getRegionByNombre")
            {
                return NotFound($"El método {nombre} no se ha encontrado");
            }

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

        [HttpGet("getComunaByNombre")]
        public async Task<ActionResult> getComunaByNombre(string nombre, string token, string parametros = "")
        {

            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "getComunaByNombre");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "getComunaByNombre");
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

        #endregion

        #region Update
        [HttpPut("UpdPais")]
        public async Task<ActionResult> UpdPais(string nombre, string token, string parametros = "")
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "UpdPais");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "UpdPais");
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

            if (nombre != "UpdPais")
            {
                return NotFound($"El método {nombre} no se ha encontrado");
            }

            GetData gd_ = new GetData();
            string resultado_ = await gd.GetDbData(nombre, parametros);

            if (resultado_ == "NotFound" || resultado_.Equals("0"))
            {
                //return NotFound($"El método {nombre} no se ha encontrado");
                return Ok("País actualizado.");
            }
            else
            {
                return Ok("No se pudo ejecutar la acción.");
            }
        }

        [HttpPut("UpdRegion")]
        public async Task<ActionResult> UpdRegion(string nombre, string token, string parametros = "")
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "UpdRegion");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "UpdRegion");
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

            if (nombre != "UpdRegion")
            {
                return NotFound($"El método {nombre} no se ha encontrado");
            }

            GetData gd_ = new GetData();
            string resultado_ = await gd.GetDbData(nombre, parametros);

            if (resultado_ == "NotFound" || resultado_.Equals("0"))
            {
                //return NotFound($"El método {nombre} no se ha encontrado");
                return Ok("Region actualizada.");
            }
            else
            {
                return Ok("No se pudo ejecutar la acción.");
            }
        }

        [HttpPut("UpdComuna")]
        public async Task<ActionResult> UpdComuna(string nombre, string token, string parametros = "")
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "UpdComuna");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "UpdComuna");
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

            if (nombre != "UpdComuna")
            {
                return NotFound($"El método {nombre} no se ha encontrado");
            }

            GetData gd_ = new GetData();
            string resultado_ = await gd.GetDbData(nombre, parametros);

            if (resultado_ == "NotFound" || resultado_.Equals("0"))
            {
                //return NotFound($"El método {nombre} no se ha encontrado");
                return Ok("Comuna actualizada.");
            }
            else
            {
                return Ok("No se pudo ejecutar la acción.");
            }
        }

        #endregion

        #region Delete
        [HttpDelete("DelComuna")]
        public async Task<ActionResult> DelComuna(string nombre_comuna, string token, string parametros = "")
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "DelComuna");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "DelComuna");
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

            Proyecto_Cliente.Repositories.Localidad pais = new Proyecto_Cliente.Repositories.Localidad();
            bool pais_ = pais.ComunaDel(nombre_comuna);

            if (pais_) { return Ok("Comuna borrada."); }
            else { return BadRequest("No se pudo realizar la acción."); }
        }

        [HttpDelete("DelRegion")]
        public async Task<ActionResult> DelRegion(string nombre_region, string token, string parametros = "")
        {
            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "DelRegion");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "DelRegion");
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

            Proyecto_Cliente.Repositories.Localidad pais = new Proyecto_Cliente.Repositories.Localidad();
            bool pais_ = pais.RegionDel(nombre_region);

            if (pais_) { return Ok("Region borrada."); }
            else { return BadRequest("No se pudo realizar la acción."); }
        }

        [HttpDelete("DelPais")]
        public async Task<ActionResult> DelPais(string nombre_pais, string token, string parametros = "")
        {

            #region Validacion token y log
            string emailUser = "";

            if (!Login.ValidarTokenUsuario(token, out emailUser))
            {
                Log_Bitacora.InsertLog(emailUser, "Error validación token: " + "DelPais");
                return Ok(new { Message = "Token no válido." });
            }
            else
            {
                Log_Bitacora.InsertLog(emailUser, "Se llama al método: " + "DelPais");
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

            Proyecto_Cliente.Repositories.Localidad pais = new Proyecto_Cliente.Repositories.Localidad();
            bool pais_ = pais.PaisDel(nombre_pais);

            if (pais_) { return Ok("País borrado."); }
            else { return BadRequest("No se pudo realizar la acción."); }
        }

        #endregion
    }
}
