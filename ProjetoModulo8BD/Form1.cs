using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ProjetoModulo8BD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
            MySqlConnection conexao = new MySqlConnection(conn);

            try
            {
                //foi criado a cum comando 
                conexao.Open();
                MySqlCommand comando = new MySqlCommand();


                //fiz receber uma referencia do conexao
                comando = conexao.CreateCommand();

                //depois foi criado um comando textual para fazer a consulta
                comando.CommandText = "select nome from usuarios where id = 4;";
                // criado uma leitura recebendo o comando reader que executa o texto retornando o resultado
                MySqlDataReader reader = comando.ExecuteReader();

                // ele ira percorer o reader em cada coluna/linhas da tabela e mostrar o resultado 
                while(reader.Read())
                {
                    if(reader["nome"] != null)
                    {
                        MessageBox.Show(reader["nome"].ToString());
                    }
                }
            }
            catch(MySqlException msqle)
            {
                MessageBox.Show("Erro de acesso ao Mysql" + msqle.Message);

            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
