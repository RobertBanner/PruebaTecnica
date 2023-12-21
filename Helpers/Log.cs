using Microsoft.AspNetCore.Hosting.Server;
using Proyecto_Cliente.Entities;


namespace Proyecto_Cliente.Helpers
{
    public static class Log
    {
        public static bool WriteLog(Client client, string type)
        {
            #region Variables
            bool out_ = false;
            string path = @"C:\Logs\";
            System.IO.Directory.CreateDirectory(path);
            string subPath = "Log_" + type + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            #endregion

            #region Serialize
            var texto = Serializer.SerializeObject(client);
            #endregion

            #region Write Log File
            File.WriteAllText(path + subPath, texto);
            #endregion

            #region Validate Write File
            // Read a file
            string readText = File.ReadAllText(path + subPath);

            if(!string.IsNullOrEmpty(readText))
            {
                out_ = true;
            }

            #endregion
            return out_;
        }
    }
}
