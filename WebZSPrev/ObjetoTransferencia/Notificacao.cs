using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Notificacao
    {

        public int id { get; set; }
        public int id_usuario { get; set; }
        public int id_cliente { get; set; }
        public DateTime datacad { get; set; }
        public DateTime data { get; set; }
        public string acao { get; set; }
        public int lida { get; set; }
        public int apagado { get; set; }



        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_usuario", this.id_usuario);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@data", this.data);
                acesso.AdicionarParametros("@acao", this.acao);
                acesso.AdicionarParametros("@lida", this.lida);
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














        public List<Notificacao> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_usuario", this.id_usuario);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@data", this.data);
                acesso.AdicionarParametros("@acao", this.acao);
                acesso.AdicionarParametros("@lida", this.lida);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");
                DataTable dt;

                List<Notificacao> listaNotificacao = new List<Notificacao>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Notificacao novoNotificacao = new Notificacao();


                        novoNotificacao.id = Convert.ToInt32("id");
                        novoNotificacao.id_usuario = Convert.ToInt32("id_usuario");
                        novoNotificacao.id_cliente = Convert.ToInt32("id_cliente");
                        novoNotificacao.datacad = Convert.ToDateTime("datacad");
                        novoNotificacao.data = Convert.ToDateTime("data");
                        novoNotificacao.acao = Convert.ToString("acao");
                        novoNotificacao.lida = Convert.ToInt32("lida");
                        novoNotificacao.apagado = Convert.ToInt32("apagado");





                        listaNotificacao.Add(novoNotificacao);
                    }

                return listaNotificacao;

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
                acesso.AdicionarParametros("@id_usuario", this.id_usuario);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@data", this.data);
                acesso.AdicionarParametros("@acao", this.acao);
                acesso.AdicionarParametros("@lida", this.lida);
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