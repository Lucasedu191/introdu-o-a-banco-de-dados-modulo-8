using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoModulo8BD
{
    public class UsuarioBD
    {
        public String BuscarNome(int id)
        {
            using (MySqlConnection conexao = ConexaoBD.getInstancia().getConexao())
            {
                try
                {
                    //foi criado a cum comando 
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();

           

                    //fiz receber uma referencia do conexao
                    comando = conexao.CreateCommand();

                    comando.CommandText = "select nome from usuarios where id = @id;";
                    comando.Parameters.AddWithValue("id", id);


                    MySqlDataReader reader = comando.ExecuteReader();
                    //depois foi criado um comando textual para fazer a consulta

                    // criado uma leitura recebendo o comando reader que executa o texto retornando o resultado
           

                    // ele ira percorer o reader em cada coluna/linhas da tabela e mostrar o resultado 
                    while (reader.Read())
                    {
                        if (reader["nome"] != null)
                        {
                            return reader["nome"].ToString();
                        }
                    }
                }
                catch (MySqlException msqle)
                {
                    MessageBox.Show("Erro de acesso ao Mysql" + msqle.Message);

                }
                finally
                {
                    conexao.Close();
                }
                return string.Empty;
            }
        }

        public void InserirUsuario(string nome)
        {
            using (MySqlConnection conexao = ConexaoBD.getInstancia().getConexao())
            {

                try
                {
                    //foi criado a cum comando 
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand();


                    //fiz receber uma referencia do conexao
                    comando = conexao.CreateCommand();

                    //depois foi criado um comando textual para fazer a criaçao na tabela
                    comando.CommandText = "insert into usuarios(nome) values(@varNome);";
                    comando.Parameters.AddWithValue("varNome", nome);
                    int valorRetorno = comando.ExecuteNonQuery();

                    if (valorRetorno < 1)
                        MessageBox.Show("Erro ao inserir!");
                    else
                        MessageBox.Show("Inserido com sucesso!");


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
}
