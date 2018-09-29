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
            UsuarioBD usu = new UsuarioBD();
            MessageBox.Show(usu.BuscarNome(Convert.ToInt32(txtIdBusca.Text.Trim())));
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new UsuarioBD().InserirUsuario(txtNome.Text.Trim());
        }
        private void button3_Click(object sender, EventArgs e)
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

                //depois foi criado um comando textual para fazer a criaçao na tabela
                comando.CommandText = "update usuarios set nome = @nome where id = @id;";
                comando.Parameters.AddWithValue("nome", txtNome2.Text.Trim());
                comando.Parameters.AddWithValue("id", Convert.ToInt32( txtId.Text.Trim()));
                int valorRetorno = comando.ExecuteNonQuery();

                if (valorRetorno < 1)
                    MessageBox.Show("Erro ao alterar!");
                else
                    MessageBox.Show("Alterado com sucesso!");


                // ele ira percorer o reader em cada coluna/linhas da tabela e mostrar o resultado 

            }
            catch (MySqlException msqle)
            {
                MessageBox.Show("Erro de acesso ao Mysql" + msqle.Message);

            }
            finally
            {
                conexao.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

                //depois foi criado um comando textual para fazer a criaçao na tabela
                comando.CommandText = "delete from usuarios where id = @id;";
            
                comando.Parameters.AddWithValue("id", Convert.ToInt32(txt2.Text.Trim()));
                int valorRetorno = comando.ExecuteNonQuery();

                if (valorRetorno < 1)
                    MessageBox.Show("Erro ao excluir!");
                else
                    MessageBox.Show("Excluido com sucesso!");


                // ele ira percorer o reader em cada coluna/linhas da tabela e mostrar o resultado 

            }
            catch (MySqlException msqle)
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
