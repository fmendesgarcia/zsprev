using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Movimentacao
    {

        public int id { get; set; }
        public int id_tipo { get; set; }
        public int id_responsavel { get; set; }
        public int id_cliente { get; set; }
        public DateTime? datacad { get; set; }
        public DateTime? dataalt { get; set; }
        public DateTime? data { get; set; }
        public string texto { get; set; }
        public int apagado { get; set; }



        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_tipo", this.id_tipo);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@dataalt", this.dataalt);
                acesso.AdicionarParametros("@data", this.data);
                acesso.AdicionarParametros("@texto", this.texto);
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



        public List<Movimentacao> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_tipo", this.id_tipo);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", metodo);
                DataTable dt;

                List<Movimentacao> listaMovimentacao = new List<Movimentacao>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Movimentacao novoMovimentacao = new Movimentacao();


                        novoMovimentacao.id = Convert.ToInt32("id");
                        novoMovimentacao.id_tipo = Convert.ToInt32("id_tipo");
                        novoMovimentacao.id_responsavel = Convert.ToInt32("id_responsavel");
                        novoMovimentacao.id_cliente = Convert.ToInt32("id_cliente");
                        novoMovimentacao.datacad = Convert.ToDateTime("datacad");
                        novoMovimentacao.dataalt = Convert.ToDateTime("dataalt");
                        novoMovimentacao.data = Convert.ToDateTime("data");
                        novoMovimentacao.texto = Convert.ToString("texto");
                        novoMovimentacao.apagado = Convert.ToInt32("apagado");





                        listaMovimentacao.Add(novoMovimentacao);
                    }

                return listaMovimentacao;

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
                acesso.AdicionarParametros("@id_tipo", this.id_tipo);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@metodo", metodo);

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


        public string Apagar(int id)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", id);
                acesso.AdicionarParametros("@metodo", "apagar");
                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, "usp_manutencao_movimentacao").ToString();
            }
            catch (Exception ex)
            {

                return "Falha ao apagar registro, motivo: " + ex.Message;
            }
        }
    }
}