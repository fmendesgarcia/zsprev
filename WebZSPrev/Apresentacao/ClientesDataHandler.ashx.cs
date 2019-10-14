using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebZSPrev.Apresentacao
{
    /// <summary>
    /// Summary description for ClientesDataHandler
    /// </summary>
    public class ClientesDataHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            int displayLenght = int.Parse(context.Request["iDisplayLength"]);
            int displayStart = int.Parse(context.Request["iDisplayStart"]);
            string sortCol = context.Request["iSortCol_0"];
            string sortDir = context.Request["sSortDir_0"];
            string search = context.Request["sSearch"];

            // parametros adicionais:
            string _apsVal = context.Request["_apsVal"];
            string _especieVal = context.Request["_especieVal"];
            string _statusVal = context.Request["_statusVal"];
            string _respVal = context.Request["_respVal"];
            string _orderBy = context.Request["_orderBy"];


            int id_usuario = 0;
            if (context.Session["id_usuario"] != null)
                id_usuario = Convert.ToInt32(context.Session["id_usuario"]);


            AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

            acesso.LimpaParametros();
            acesso.AdicionarParametros("@DisplayLength", displayLenght);
            acesso.AdicionarParametros("@DisplayStart", displayStart);
            acesso.AdicionarParametros("@SortCol", sortCol);
            acesso.AdicionarParametros("@SortDir", sortDir);
            acesso.AdicionarParametros("@Search", search);
            acesso.AdicionarParametros("@id_responsavel", id_usuario);

            acesso.AdicionarParametros("@_apsVal", _apsVal);
            acesso.AdicionarParametros("@_especieVal", _especieVal);
            acesso.AdicionarParametros("@_statusVal", _statusVal);
            acesso.AdicionarParametros("@_respVal", _respVal);
            acesso.AdicionarParametros("@_orderBy", _orderBy);


            DataTable dt = null;
            List<ObjetoTransferencia.ClienteTable> listaCliente = new List<ObjetoTransferencia.ClienteTable>();
            int filteredCount = 0;
            using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, "usp_get_cliente_order_2"))
                foreach (DataRow dr in dt.Rows)
                {

                    ObjetoTransferencia.ClienteTable novoCliente = new ObjetoTransferencia.ClienteTable();


                    filteredCount = Convert.ToInt32(dr["_TotalCount"]);
                    novoCliente.id = dr["_id"].ToString();
                    novoCliente.nome = dr["_nome"].ToString();
                    novoCliente.nb = dr["_nb"].ToString();
                    novoCliente.data_nascimento = dr["_data_nascimento"].ToString();
                    novoCliente.cpf = dr["_cpf"].ToString();
                    novoCliente.datacad = dr["_datacad"].ToString();
                    novoCliente.dataalt = dr["_dataalt"].ToString();
                    novoCliente.status = dr["_status"].ToString();
                    novoCliente.status_pasta = dr["_status_pasta"].ToString();
                    novoCliente.responsavel = dr["_responsavel"].ToString();
                    novoCliente.tipo = dr["_tipo"].ToString();
                    novoCliente.motivo = dr["_motivo"].ToString();
                    novoCliente.der = dr["_der"].ToString();
                    novoCliente.aps = dr["_aps"].ToString();
                    novoCliente.especie = dr["_especie"].ToString();
                    novoCliente.situacao_beneficio = dr["_situacao_beneficio"].ToString();
                    novoCliente.idade = dr["_idade"].ToString();
                    novoCliente.buttons = dr["_buttons"].ToString();

                    listaCliente.Add(novoCliente);
                }

            var result = new
            {

                iTotalRecords = 100,
                iTotalDisplayRecords = filteredCount,
                aaData = listaCliente

            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(result));


        }

        public int TotalClientes()
        {
            AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();
            acesso.LimpaParametros();
            string strTotal =  acesso.ExecutaConsulta(CommandType.Text, "SELECT count(*) FROM tblCliente where apagado = 0").ToString();
            return int.Parse(strTotal);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}