using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebZSPrev.ObjetoTransferencia;

namespace WebZSPrev.Apresentacao
{
    public partial class requests : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            string valorParametro = Request.QueryString["objeto"];
            string _id = null;
            string id_usuario = null;
            try
            {
                id_usuario = Session["id_usuario"].ToString();
                _id = Request.QueryString["id"];
            }
            catch
            { 

            }

            var jsonSerialiser = new JavaScriptSerializer();


            if (valorParametro == "motivo_cli")
            {
                ObjetoTransferencia.Motivo objeto = new Motivo();
                using (DataTable dt = objeto.consultadt("usp_manutencao_motivo", "consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "tipo_cli")
            {
                ObjetoTransferencia.TipoCli objeto = new TipoCli();
                using (DataTable dt = objeto.consultadt("usp_manutencao_tipo_cli", "consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "situacao_benficio_cli")
            {
                ObjetoTransferencia.SituacaoBeneficio objeto = new SituacaoBeneficio();
                using (DataTable dt = objeto.consultadt("usp_manutencao_situacao_beneficio", "consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "status_cli")
            {
                ObjetoTransferencia.Status objeto = new Status();
                using (DataTable dt = objeto.consultadt("usp_manutencao_status", "consultar"))
                {
                    jresponse(dt);
                }
            }


            else if (valorParametro == "status_pasta")
            {
                ObjetoTransferencia.StatusPasta objeto = new StatusPasta();
                using (DataTable dt = objeto.consultadt("usp_manutencao_status_pasta", "consultar"))
                {
                    jresponse(dt);
                }
            }

           

            else if (valorParametro == "aps_origem")
            {
                ObjetoTransferencia.Aps objeto = new Aps();
                using (DataTable dt = objeto.consultadt("usp_manutencao_aps", "consultar"))
                {
                    jresponse(dt);
                }
            }

            //tipo_doc

            else if (valorParametro == "tipo_doc")
            {
                ObjetoTransferencia.TipoDoc objeto = new TipoDoc();
                using (DataTable dt = objeto.consultadt("usp_manutencao_tipo_doc", "consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "documento")
            {
                ObjetoTransferencia.Documento objeto = new Documento();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;
                using (DataTable dt = objeto.consultadt("usp_manutencao_documento", "consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "documento_id")
            {
                ObjetoTransferencia.Documento objeto = new Documento();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;
                using (DataTable dt = objeto.consultadt("usp_manutencao_documento", "consultar_id"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "tipo_comp")
            {
                ObjetoTransferencia.TipoCompromisso objeto = new TipoCompromisso();
                using (DataTable dt = objeto.consultadt("usp_manutencao_tipo_compromisso", "consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "compromisso")
            {
                ObjetoTransferencia.Compromisso objeto = new Compromisso();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;
                using (DataTable dt = objeto.consultadt("usp_manutencao_compromisso", "consultar"))
                {
                    jresponse(dt);
                }
            }


            else if (valorParametro == "compromisso_id")
            {
                ObjetoTransferencia.Compromisso objeto = new Compromisso();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;
                using (DataTable dt = objeto.consultadt("usp_manutencao_compromisso", "consultar_id"))
                {
                    jresponse(dt);
                }
            }


            else if (valorParametro == "tipo_mov")
            {
                ObjetoTransferencia.TipoMovimentacao objeto = new TipoMovimentacao();
                using (DataTable dt = objeto.consultadt("usp_manutencao_tipo_movimentcao", "consultar"))
                {
                    jresponse(dt);
                }
            }


            else if (valorParametro == "user")
            {
                ObjetoTransferencia.Responsavel objeto = new Responsavel();
                using (DataTable dt = objeto.consultadt("usp_manutencao_responsavel", "consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "cli")
            {
                ObjetoTransferencia.Cliente objeto = new Cliente();
                objeto.id_responsavel = Convert.ToInt32(id_usuario);
                using (DataTable dt = objeto.consultadt("usp_manutencao_cliente", "user_consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "cli_id")
            {
                ObjetoTransferencia.Cliente objeto = new Cliente();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;
                using (DataTable dt = objeto.consultadt("usp_manutencao_cliente", "consultar"))
                {
                    jresponse(dt);
                }
            }


            else if (valorParametro == "cli_id_codigos")
            {
                ObjetoTransferencia.Cliente objeto = new Cliente();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;
                using (DataTable dt = objeto.consultadt("usp_manutencao_cliente", "consultar_codigos"))
                {
                    jresponse(dt);
                }
            }


            

            else if (valorParametro == "especie")
            {
                ObjetoTransferencia.Especie objeto = new Especie();
                using (DataTable dt = objeto.consultadt("usp_manutencao_especie", "consultar"))
                {
                    jresponse(dt);
                }
            }

            // endereco
            else if (valorParametro == "cidade")
            {
                ObjetoTransferencia.Comarca objeto = new Comarca();
                using (DataTable dt = objeto.consultadt("usp_manutencao_comarca", "consultar"))
                {
                    jresponse(dt);
                }
            }
            else if (valorParametro == "uf")
            {
                ObjetoTransferencia.UF objeto = new UF();
                using (DataTable dt = objeto.consultadt("usp_manutencao_uf", "consultar"))
                {
                    jresponse(dt);
                }
            }
            else if (valorParametro == "endereco")
            {
                ObjetoTransferencia.Endereco objeto = new Endereco();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;

                using (DataTable dt = objeto.consultadt("usp_manutencao_endereco", "consultar_id_cliente"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "endereco_id")
            {
                ObjetoTransferencia.Endereco objeto = new Endereco();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;

                using (DataTable dt = objeto.consultadt("usp_manutencao_endereco", "consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "contato")
            {
                ObjetoTransferencia.Contato objeto = new Contato();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;

                using (DataTable dt = objeto.consultadt("usp_manutencao_contato", "consultar_id_cliente"))
                {
                    jresponse(dt);
                }
            }


            else if (valorParametro == "contato_id")
            {
                ObjetoTransferencia.Contato objeto = new Contato();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;

                using (DataTable dt = objeto.consultadt("usp_manutencao_contato", "consultar"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "especie_id")
            {
                ObjetoTransferencia.Especie objeto = new Especie();
                objeto.id = Convert.ToInt32(_id);
                using (DataTable dt = objeto.consultar_cod_esp("usp_manutencao_especie", "consultar_cod_esp"))
                {
                    jresponse(dt);
                }
            }

            else if (valorParametro == "movimentacao")
            {
                ObjetoTransferencia.Movimentacao objeto = new Movimentacao();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;

                using (DataTable dt = objeto.consultadt("usp_manutencao_movimentacao", "consultar_id_cliente"))
                {
                    jresponse(dt);
                }
            }


            else if (valorParametro == "movimentacao_id")
            {
                ObjetoTransferencia.Movimentacao objeto = new Movimentacao();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;

                using (DataTable dt = objeto.consultadt("usp_manutencao_movimentacao", "consultar"))
                {
                    jresponse(dt);
                }
            }


            else if (valorParametro == "obs_contato")
            {
                ObjetoTransferencia.Obs objeto = new Obs();
                objeto.id = Convert.ToInt32(_id);
                objeto.apagado = 0;

                using (DataTable dt = objeto.consultadt("usp_manutencao_obs_contato", "consultar"))
                {
                    jresponse(dt);
                }
            }



        }

        private void jresponse(DataTable dt)
        {
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string json = JsonConvert.SerializeObject(dt, Formatting.None, jsSettings);
            Response.Write(json);
        }
    }
}