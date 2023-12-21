using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Proyecto_Cliente.Repositories
{
    public class Login
    {


        public string getTokenLogin(string email, string password)
        {
            Encriptacion encrip = new Encriptacion();
            string fecha = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string tokenLogin = encrip.AES256_Encriptar(encrip.AES256_LOGIN_Key, fecha + '#' + email + '#' + encrip.GetSHA256(password));
            return tokenLogin;
        }

        public string LoginByToken(string loginToken)
        {
            try
            {
                Encriptacion encrip = new Encriptacion();
                string tokenUsuario = "";

                string tokenDescoficado = encrip.AES256_Desencriptar(encrip.AES256_LOGIN_Key, loginToken);
                string fecha = tokenDescoficado.Split('#')[0];
                string email = tokenDescoficado.Split('#')[1];
                string password = tokenDescoficado.Split('#')[2];

                // Validar fecha
                DateTime fechaLogin = DateTime.ParseExact(fecha, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.UtcNow.Subtract(fechaLogin).TotalSeconds >= 60)
                {
                    return "-1";    // -1 = Límite de tiempo excedido
                }

                // Validar login
                string SQL = $"SELECT * FROM dbo.Usuario WHERE Email='{email}' AND Clave=0x{password}";

                DataTable dt = AccesoDatos.GetTmpDataTable(SQL);
                if (dt.Rows.Count > 0)
                {
                    tokenUsuario = dt.Rows[0]["Email"].ToString() + "#" + DateTime.UtcNow.AddHours(18).ToString("yyyyMMddHHmmss"); 
                    tokenUsuario = encrip.AES256_Encriptar(encrip.AES256_USER_Key, tokenUsuario);
                    return tokenUsuario;
                }
                else
                {
                    return "-2";    
                }
            }
            catch (Exception)
            {
                return "-3";     
            }
        }



        public static string GetEmailUsuarioFromTokenValidate(string token)
        {
            Encriptacion encrip = new Encriptacion();
            token = encrip.CorregirToken(token);
            string tokenDescodificado = encrip.AES256_Desencriptar(encrip.AES256_USER_Key, token);
            string emailUsuario = tokenDescodificado.Split('#')[0];
            return emailUsuario;
        }

        public static bool ValidarTokenUsuario(string tokenUsuario, out string emailUser)
        {
            try
            {
                Encriptacion encrip = new Encriptacion();
                tokenUsuario = encrip.CorregirToken(tokenUsuario);
                string tokenDescodificado = encrip.AES256_Desencriptar(encrip.AES256_USER_Key, tokenUsuario);
                string emailUsuario = tokenDescodificado.Split('#')[0];
                emailUser = emailUsuario;
                string fecha = tokenDescodificado.Split('#')[1];

                // Validar fecha
                DateTime fechaCaducidad = DateTime.ParseExact(fecha, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.UtcNow > fechaCaducidad)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                emailUser = "";
                return false;
                
            }

            
        }



    }
}
