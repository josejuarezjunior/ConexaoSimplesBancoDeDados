using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas
{
    public class Conexao
    {
        //Fazendo uma instância de Sql Connection
        SqlConnection con = new SqlConnection();
        
        //Construtor
        public Conexao()
        {
            //Informando a string de conexão
            con.ConnectionString = "Data Source=JJHOME;Initial Catalog=Pessoas;Integrated Security=True";
        }
        //Metodo conectar
        public SqlConnection conectar()
        {
            //Verificando se a conexão com o banco de dados está fechada.
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        //Metodo desconectar
        public void desconectar()
        {
            //Verificando se a conexão com o banco de dados está aberta.
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

        }
    }
}
