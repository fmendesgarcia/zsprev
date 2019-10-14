using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Importacao
    {
        public int? id { get; set; }
        public string nb { get; set; }
        public string cidade { get; set; }
        public string requerente { get; set; }
        public DateTime? der { get; set; }
        public int? id_responsavel { get; set; }
        public int? lote { get; set; }

        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nb", this.nb);
                acesso.AdicionarParametros("@cidade", this.cidade);
                acesso.AdicionarParametros("@requerente", this.requerente);
                acesso.AdicionarParametros("@der", this.der);
                acesso.AdicionarParametros("@metodo", metodo);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@lote", this.lote);

                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, "usp_manutencao_importacao").ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ao chamar a usp_manutencao_importacao" + " para o método: " + metodo + ". Motivo: " + ex.Message);
            }
        }

    }

    public class ImportacaoLista : List<Importacao>
    {

    }
}