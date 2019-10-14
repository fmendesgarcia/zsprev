using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Status
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

        public List<Status> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");
                DataTable dt;

                List<Status> listaStatus = new List<Status>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Status novoStatus = new Status();


                        novoStatus.id = Convert.ToInt32("id");
                        novoStatus.nome = Convert.ToString("nome");
                        novoStatus.apagado = Convert.ToInt32("apagado");

                        listaStatus.Add(novoStatus);
                    }

                return listaStatus;

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


        public List<Status> ComboStatus(int id_user, string valor_aps, string  valor_especie, string valor_responsavel, string procedure)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@obj", "status");
                acesso.AdicionarParametros("@id_user", id_user);
                acesso.AdicionarParametros("@valor_aps", valor_aps);
                acesso.AdicionarParametros("@valor_especie", valor_especie);
                acesso.AdicionarParametros("@valor_responsavel", valor_responsavel);

                DataTable dt;
                List<Status> listaStatus = new List<Status>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Status novoStatus = new Status();


                        novoStatus.id = Convert.ToInt32(dr["id"]);
                        novoStatus.nome = Convert.ToString(dr["nome"]);


                        listaStatus.Add(novoStatus);
                    }

                return listaStatus;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }
        }
    }
}