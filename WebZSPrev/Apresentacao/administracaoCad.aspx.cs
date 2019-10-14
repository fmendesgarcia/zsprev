using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebZSPrev.ObjetoTransferencia;

namespace WebZSPrev.Apresentacao
{
    public partial class administracaoParametros : System.Web.UI.Page
    {
        static string item;
        static int id;
        static string acao;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string id = Session["id_usuario"].ToString();
                if (string.IsNullOrEmpty(id))
                {
                    //Response.Redirect("login.aspx");
                }

            }
            catch
            {

                // Response.Redirect("login.aspx");
            }


            try
            {
                acao = "";
                item = "";
                id = 0;

                acao = Request.QueryString["acao"];
                item = Request.QueryString["item"];



                if (acao == "Editar" || acao == "Excluir")
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                }


                consulta();




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        private void jresponse(DataTable dt)
        {
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string json = JsonConvert.SerializeObject(dt, Formatting.None, jsSettings);
            Response.Write(json);
        }


        public void consulta()
        {
            string retorno = "";
            if (acao == "Editar")
            {
                if (item == "motivo_cli")
                {
                    ObjetoTransferencia.Motivo objeto = new Motivo();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_motivo", "consultar"))
                    {
                        //retorno = JsonConvert.SerializeObject(dt);

                        valor.Value = dt.Rows[0][1].ToString();

                    }
                }

                else if (item == "tipo_cli")
                {
                    ObjetoTransferencia.TipoCli objeto = new TipoCli();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_tipo_cli", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }

                else if (item == "situacao_benficio_cli")
                {
                    ObjetoTransferencia.SituacaoBeneficio objeto = new SituacaoBeneficio();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_situacao_beneficio", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }

                else if (item == "status_cli")
                {
                    ObjetoTransferencia.Status objeto = new Status();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_status", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }


                else if (item == "status_cli")
                {
                    ObjetoTransferencia.SituacaoBeneficio objeto = new SituacaoBeneficio();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_status", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }

                else if (item == "aps_origem")
                {
                    ObjetoTransferencia.Aps objeto = new Aps();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_aps", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }

                //tipo_doc

                else if (item == "tipo_doc")
                {
                    ObjetoTransferencia.TipoDoc objeto = new TipoDoc();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_tipo_doc", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }

                else if (item == "tipo_comp")
                {
                    ObjetoTransferencia.TipoCompromisso objeto = new TipoCompromisso();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_tipo_compromisso", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }


                else if (item == "tipo_mov")
                {
                    ObjetoTransferencia.TipoMovimentacao objeto = new TipoMovimentacao();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_tipo_movimentcao", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }

                else if (item == "especie")
                {
                    ObjetoTransferencia.Especie objeto = new Especie();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_especie", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }

                else if (item == "status_pasta")
                {
                    ObjetoTransferencia.StatusPasta objeto = new StatusPasta();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_status_pasta", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }

                else if (item == "obs_contato")
                {
                    ObjetoTransferencia.Obs objeto = new Obs();
                    objeto.id = id;
                    using (DataTable dt = objeto.consultadt("usp_manutencao_obs_contato", "consultar"))
                    {
                        valor.Value = dt.Rows[0][1].ToString();
                    }
                }
            }
            else if (acao == "Excluir")
            {

            }

        }


        [WebMethod]
        public static string inserir(string valor, string item)
        {
            string retorno = "Inserido com sucesso!";

            if (item == "motivo_cli")
            {
                try
                {
                    Motivo objeto = new Motivo();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_motivo", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }

            else if (item == "tipo_cli")
            {
                try
                {
                    TipoCli objeto = new TipoCli();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_tipo_cli", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }


            }

            else if (item == "situacao_benficio_cli")
            {
                try
                {
                    SituacaoBeneficio objeto = new SituacaoBeneficio();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_situacao_beneficio", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }


            }

            else if (item == "status_cli")
            {
                try
                {
                    Status objeto = new Status();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_status", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }


            else if (item == "status_pasta")
            {
                try
                {
                    StatusPasta objeto = new StatusPasta();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_status_pasta", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }


            }

            else if (item == "aps_origem")
            {
                try
                {
                    Aps objeto = new Aps();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_aps", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }

            //tipo_doc

            else if (item == "tipo_doc")
            {
                try
                {
                    ObjetoTransferencia.TipoDoc objeto = new TipoDoc();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_tipo_doc", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }

            else if (item == "tipo_comp")
            {
                try
                {
                    ObjetoTransferencia.TipoCompromisso objeto = new TipoCompromisso();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_tipo_compromisso", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }


            else if (item == "tipo_mov")
            {
                try
                {
                    TipoMovimentacao objeto = new TipoMovimentacao();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_tipo_movimentcao", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }


            else if (item == "especie")
            {
                try
                {
                    Especie objeto = new Especie();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_especie", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }

            else if (item == "status_pasta")
            {
                try
                {
                    StatusPasta objeto = new StatusPasta();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_status_pasta", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }

            else if (item == "obs_contato")
            {
                try
                {
                    StatusPasta objeto = new StatusPasta();
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_obs_contato", "inserir");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }



            return retorno;
        }

        [WebMethod]
        public static string alterar(string valor, string item, int id)
        {

            string retorno = "Alterado com sucesso!";

            if (item == "motivo_cli")
            {
                try
                {
                    Motivo objeto = new Motivo();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_motivo", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }

            else if (item == "tipo_cli")
            {
                try
                {
                    TipoCli objeto = new TipoCli();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_tipo_cli", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }


            }

            else if (item == "situacao_benficio_cli")
            {
                try
                {
                    SituacaoBeneficio objeto = new SituacaoBeneficio();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_situacao_beneficio", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }


            }

            else if (item == "status_cli")
            {
                try
                {
                    Status objeto = new Status();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_status", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }


            else if (item == "status_pasta")
            {
                try
                {
                    StatusPasta objeto = new StatusPasta();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_status_pasta", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }


            }

            else if (item == "aps_origem")
            {
                try
                {
                    Aps objeto = new Aps();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_aps", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }

            //tipo_doc

            else if (item == "tipo_doc")
            {
                try
                {
                    ObjetoTransferencia.TipoDoc objeto = new TipoDoc();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_tipo_doc", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }

            else if (item == "tipo_comp")
            {
                try
                {
                    ObjetoTransferencia.TipoCompromisso objeto = new TipoCompromisso();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_tipo_compromisso", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }


            else if (item == "tipo_mov")
            {
                try
                {
                    TipoMovimentacao objeto = new TipoMovimentacao();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_tipo_movimentcao", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }

            else if (item == "especie")
            {
                try
                {
                    Especie objeto = new Especie();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_especie", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }

            else if (item == "status_pasta")
            {
                try
                {
                    StatusPasta objeto = new StatusPasta();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_status_pasta", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }
            else if (item == "obs_contato")
            {
                try
                {
                    StatusPasta objeto = new StatusPasta();
                    objeto.id = id;
                    objeto.nome = valor;
                    objeto.manutencao("usp_manutencao_obs_contato", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }





            return retorno;
        }

        [WebMethod]
        public static string excluir(int id, string item)
        {
            string retorno = "Exclusão efetuada com sucesso!";
            if (item == "motivo_cli")
            {
                try
                {
                    Motivo objeto = new Motivo();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_motivo", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }

            else if (item == "tipo_cli")
            {
                try
                {
                    TipoCli objeto = new TipoCli();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_tipo_cli", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }


            }

            else if (item == "situacao_benficio_cli")
            {
                try
                {
                    SituacaoBeneficio objeto = new SituacaoBeneficio();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_situacao_beneficio", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }


            }

            else if (item == "status_cli")
            {
                try
                {
                    Status objeto = new Status();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_status", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }


            else if (item == "status_pasta")
            {
                try
                {
                    StatusPasta objeto = new StatusPasta();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_status_pasta", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }


            }

            else if (item == "aps_origem")
            {
                try
                {
                    Aps objeto = new Aps();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_aps", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }

            //tipo_doc

            else if (item == "tipo_doc")
            {
                try
                {
                    ObjetoTransferencia.TipoDoc objeto = new TipoDoc();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_tipo_doc", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }

            else if (item == "tipo_comp")
            {
                try
                {
                    ObjetoTransferencia.TipoCompromisso objeto = new TipoCompromisso();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_tipo_compromisso", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }


            else if (item == "tipo_mov")
            {
                try
                {
                    TipoMovimentacao objeto = new TipoMovimentacao();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_tipo_movimentcao", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }

            }

            else if (item == "especie")
            {
                try
                {
                    Especie objeto = new Especie();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_especie", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }


            else if (item == "status_pasta")
            {
                try
                {
                    StatusPasta objeto = new StatusPasta();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_status_pasta", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }

            else if (item == "obs_contato")
            {
                try
                {
                    Obs objeto = new Obs();
                    objeto.id = id;
                    objeto.apagado = 1;
                    objeto.manutencao("usp_manutencao_obs_contato", "alterar");
                }
                catch (Exception ex)
                {

                    retorno = "Falha, motivo: " + ex.ToString();
                }
            }


            return retorno;

        }
    }
}