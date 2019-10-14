using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebZSPrev.Properties;
using MySql;

namespace WebZSPrev.AcessaDados
{
    public class AcessaDadosMySql
    {
        public class AcessaDadosSqlServer
        {

            //Cria a conexao...
            private MySqlConnection CriaConexao()
            {
                return new MySqlConnection(Settings.Default.conn);

            }
            //Parametros que vão para o banco
            private MySqlParameterCollection mySqlParameterCollection = new MySqlCommand().Parameters;
            //= new MySqlCommand().Parameters;


            //Método para limpar os parametros;
            public void LimpaParametros()
            {
                mySqlParameterCollection.Clear();
            }

            //Metodo Para criar parametros(aqui a coleção de parametro recebe um novo parametro (no caos uma string que sera usada em caso de string de sql
            //e um object que é se você for usar uma procedure))
            public void AdicionarParametros(string nomeParametro, object valorParametro)
            {
                mySqlParameterCollection.AddWithValue(nomeParametro, valorParametro);

            }

            //Persistencia___ inserir, alterar, excluri.
            public object ExecutaManipulacao(CommandType commandType, string storedProcedureOuTextoSql)
            {
                try
                {
                    ////chamando a conexao com o banco;
                    //    SqlConnection sqlConnection = CriaConexao();
                    //    //abrindo a conexao;
                    //    sqlConnection.Open();
                    //    //criando os parametros;
                    //    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    //    sqlCommand.CommandType = commandType;
                    //    sqlCommand.CommandText = storedProcedureOuTextoSql;
                    //    sqlCommand.CommandTimeout = 7200;// in senconds'

                    //   // colocando os parametros dentro da caixa de parametros.
                    //    foreach (SqlParameter sqlParameter in sqlParameterCollection)
                    //    {
                    //        sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));  
                    //    }

                    MySqlConnection sqlConnection = CriaConexao();
                    sqlConnection.Open();
                    MySqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = commandType;
                    sqlCommand.CommandText = storedProcedureOuTextoSql;
                    sqlCommand.CommandTimeout = 7200;

                    foreach (MySqlParameter sqlParameter in mySqlParameterCollection)
                    {
                        sqlCommand.Parameters.Add(new MySqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }
                    return sqlCommand.ExecuteScalar();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }


            }

            //Consulta registros no banco de dados
            public DataTable ExecutaConsulta(CommandType commandType, string storedProcedureOuTextoSql)
            {
                try
                {

                    MySqlConnection sqlConnection = CriaConexao();
                    sqlConnection.Open();
                    MySqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = commandType;
                    sqlCommand.CommandText = storedProcedureOuTextoSql;
                    sqlCommand.CommandTimeout = 7200;

                    foreach (MySqlParameter sqlParameter in mySqlParameterCollection)
                    {
                        sqlCommand.Parameters.Add(new MySqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }

                    ////Cria Adaptador, passando o caixa que vai para o banco para ele.
                    //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    ////Datatable = Cria Tabela de dados vazia onde vou colocar os dados que vem  do banco
                    //DataTable dataTable = new DataTable();

                    ////Mardar o comando ir até o banco buscar os dados e o adaptador preencher a Tabela de dados(DataTable);
                    //sqlDataAdapter.Fill(dataTable);

                    //return dataTable;

                    //Transendo os resultados do banco e com eles preencho um datatable;
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    return dataTable;

                }


                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }
    }
}