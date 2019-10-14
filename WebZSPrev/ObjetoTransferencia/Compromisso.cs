using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{

    public class Compromisso
    {

        public int id { get; set; }
        public DateTime? datacad { get; set; }
        public DateTime? data { get; set; }
        public int id_tipo { get; set; }
        public int id_responsavel { get; set; }
        public int id_status { get; set; }
        public int id_cliente { get; set; }
        public string texto { get; set; }
        public int apagado { get; set; }



        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@data", this.data);
                acesso.AdicionarParametros("@id_tipo", this.id_tipo);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@id_status", this.id_status);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
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



        public List<Compromisso> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@data", this.data);
                acesso.AdicionarParametros("@id_tipo", this.id_tipo);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@id_status", this.id_status);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@texto", this.texto);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");
                DataTable dt;

                List<Compromisso> listaCompromisso = new List<Compromisso>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Compromisso novoCompromisso = new Compromisso();


                        novoCompromisso.id = Convert.ToInt32("id");
                        novoCompromisso.datacad = Convert.ToDateTime("datacad");
                        novoCompromisso.data = Convert.ToDateTime("data");
                        novoCompromisso.id_tipo = Convert.ToInt32("id_tipo");
                        novoCompromisso.id_responsavel = Convert.ToInt32("id_responsavel");
                        novoCompromisso.id_status = Convert.ToInt32("id_status");
                        novoCompromisso.id_cliente = Convert.ToInt32("id_cliente");
                        novoCompromisso.texto = Convert.ToString("texto");
                        novoCompromisso.apagado = Convert.ToInt32("apagado");





                        listaCompromisso.Add(novoCompromisso);
                    }

                return listaCompromisso;

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
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@data", this.data);
                acesso.AdicionarParametros("@id_tipo", this.id_tipo);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@id_status", this.id_status);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@texto", this.texto);
                acesso.AdicionarParametros("@apagado", this.apagado);
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
    }
}