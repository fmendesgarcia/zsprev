using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Aps
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int apagado { get; set; }

        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@apagado", this.apagado);


                acesso.AdicionarParametros("@metodo", metodo);


                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, procedure).ToString();
            }
            catch (Exception ex)
            {
                //Mensagem de erro.
                throw new Exception("Erro ao chamar a " + procedure + " para o método: " + metodo + ". Motivo: " + ex.Message);
            }
        }



        public List<Aps> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");
                DataTable dt;

                List<Aps> listAps = new List<Aps>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Aps novoAps = new Aps();


                        novoAps.id = Convert.ToInt32("id");
                        novoAps.nome = Convert.ToString("nome");
                        novoAps.apagado = Convert.ToInt32("apagado");

                        listAps.Add(novoAps);
                    }

                return listAps;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }

        }

        public List<Aps> ComboAps(int id_user, string valor_especie, string valor_status, string valor_responsavel, string procedure)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@obj", "aps");
                acesso.AdicionarParametros("@id_user", id_user);
                acesso.AdicionarParametros("@valor_especie", valor_especie);
                acesso.AdicionarParametros("@valor_status", valor_status);
                acesso.AdicionarParametros("@valor_responsavel", valor_responsavel);

                DataTable dt;

                List<Aps> listAps = new List<Aps>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Aps novoAps = new Aps();


                        novoAps.id = Convert.ToInt32(dr["id"]);
                        novoAps.nome = Convert.ToString(dr["nome"]);


                        listAps.Add(novoAps);
                    }

                return listAps;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }
        }

        public DataTable consultadt(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");

                using (DataTable dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }

        }
    }
}