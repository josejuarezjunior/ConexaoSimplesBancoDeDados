using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas
{
    public class Cadastro
    {
        //Instanciando uma conexão com o banco de dados
        Conexao conexao = new Conexao();
        //Instanciando SqlCommand
        SqlCommand cmd = new SqlCommand();
        //Mensagem
        public string mensagem = "";
        public Cadastro(string nome, string telefone)
        {
            //Passos:
            //Comando Sql --- SqlCommand
            cmd.CommandText = "insert into Usuarios (nome, telefone) values (@nome, @telefone)";
            //Parâmetros
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@telefone", telefone);
            try
            {
                //Conectar com o banco de dados - Classe Conexao
                cmd.Connection = conexao.conectar();
                //Executar comando
                /* ExecuteNonQuery = Envia um valor para o banco de dados
                 * ExecuteReader = Envia o valor ao banco de dados e traz ao sistema. 
                */
                cmd.ExecuteNonQuery();
                //Desconectar
                conexao.desconectar();
                //Mostrar mensagem de sucesso -- Variável
                this.mensagem = "Cadastrado com sucesso!";
            }
            /*
             * Por padrão o argumento do catch será "Exception", a excessão mais genérica.
             * Nesse caso devemos alterar para "SqlException".
             */
            catch (SqlException e)
            {
                //Mostrar mensagem de erro -- Variável
                this.mensagem = "Erro ao tentar conexão com o banco de dados!";
                this.mensagem = e.Message;
            }
                        
        }
    }
}
