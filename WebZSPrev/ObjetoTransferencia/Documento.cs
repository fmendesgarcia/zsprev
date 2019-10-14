using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Documento
    {

        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_responsavel { get; set; }
        public int id_tipo { get; set; }
        public string obs { get; set; }
        public string nome_original { get; set; }
        public string nome_salvo { get; set; }
        public DateTime? datacad { get; set; }
        public DateTime? dataalt { get; set; }
        public int apagado { get; set; }



        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@id_tipo", this.id_tipo);
                acesso.AdicionarParametros("@obs", this.obs);
                acesso.AdicionarParametros("@nome_original", this.nome_original);
                acesso.AdicionarParametros("@nome_salvo", this.nome_salvo);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@dataalt", this.dataalt);
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


        public List<Documento> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@metodo", metodo);
                DataTable dt;

                List<Documento> listaDocumento = new List<Documento>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Documento novoDocumento = new Documento();

                        novoDocumento.id = Convert.ToInt32(dr["id"]);
                        novoDocumento.id_tipo = Convert.ToInt32(dr["id_tipo"]);
                        novoDocumento.id_responsavel = Convert.ToInt32(dr["id_responsavel"]);
                        novoDocumento.obs = Convert.ToString(dr["obs"]);
                        novoDocumento.datacad = Convert.ToDateTime(dr["datacad"]);
                        novoDocumento.dataalt = Convert.ToDateTime(dr["dataalt"]);
                        novoDocumento.apagado = Convert.ToInt32(dr["apagado"]);


                        listaDocumento.Add(novoDocumento);
                    }

                return listaDocumento;

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

    }
}