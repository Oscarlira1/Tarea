using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDatos
    {
        public async Task<bool> LoginAsync(string correo, string clave)
        {
            bool valido = false;
            try
            {
                string sql = "SELECT 1 FROM Login WHERE Usuario=@Usuario AND contrasena=@contrasena;";
                using (MySqlConnection _conexion = new MySqlConnection(conexion.base_1))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Usuario", MySqlDbType.VarChar, 50).Value = correo;
                        comando.Parameters.Add("@contrasena", MySqlDbType.VarChar, 50).Value = clave;

                        valido = Convert.ToBoolean(await comando.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return valido;
        }
    }
}
