using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class SituacaoBeneficio
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
                throw new Exception("Erro ao ao chamar a " + procedure + " para o método: " + metodo + ". Motivo: " + ex.Message);
            }
        }

        public List<SituacaoBeneficio> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");
                DataTable dt;

                List<SituacaoBeneficio> listaSituacaoBeneficio = new List<SituacaoBeneficio>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        SituacaoBeneficio novoSituacaoBeneficio = new SituacaoBeneficio();


                        novoSituacaoBeneficio.id = Convert.ToInt32("id");
                        novoSituacaoBeneficio.nome = Convert.ToString("nome");
                        novoSituacaoBeneficio.apagado = Convert.ToInt32("apagado");





                        listaSituacaoBeneficio.Add(novoSituacaoBeneficio);
                    }

                return listaSituacaoBeneficio;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, situação beneficio: " + ex.Message);
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