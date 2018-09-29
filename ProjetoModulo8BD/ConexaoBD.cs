using MySql.Data.MySqlClient;
using System.Configuration;

namespace ProjetoModulo8BD
{
    public class ConexaoBD
    {
        private static readonly ConexaoBD InstanciaMySQL = new ConexaoBD();

        public static ConexaoBD getInstancia()
        {
            return InstanciaMySQL;

        }

        public MySqlConnection getConexao()
        {
            string conn = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
            return new MySqlConnection(conn);
        }

    }
}
