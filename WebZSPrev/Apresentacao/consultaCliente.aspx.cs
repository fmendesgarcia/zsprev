using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebZSPrev.ObjetoTransferencia;

namespace WebZSPrev.Apresentacao
{
    public partial class consulta : System.Web.UI.Page
    {

        string id_user = null;
        string valor_aps = "0";
        string valor_especie = "0";
        string valor_status = "0";
        string valor_responsavel = "0";


        protected void Page_Load(object sender, EventArgs e)
        {



            try
            {
                id_user = Session["id_usuario"].ToString();


                if (string.IsNullOrEmpty(id_user))
                {
                    //Response.Redirect("login.aspx");
                }

            }
            catch
            {
                //Response.Redirect("login.aspx");
            }


            string permissao = null;

            try
            {
                permissao = Session["permissao"].ToString();
            }
            catch
            {

            }

            if (permissao != null)
            {
                if (permissao == "p1")
                {
                    mspanNome.Attributes.Add("readonly", "readonly");
                    mspanResponsavel.Disabled = true;
                    mspanEspecie.Disabled = true;
                    mspanAps.Disabled = true;
                    dropResponsavelMassa.Disabled = true;
                   
                    
                }
            }

            










            if (!IsPostBack)
            {
                try
                {
                    valor_aps = Session["combo_aps"].ToString();
                    valor_especie = Session["combo_especie"].ToString();
                    valor_responsavel = Session["combo_responsavel"].ToString();
                    valor_status = Session["combo_status"].ToString();
                }
                catch
                {

                }


                CarregaAps();

                CarregaEspecie();

                CarregaStatus();

                CarregaResponsavel();

                // SETANDO:

                try
                {
                    dropAps.SelectedValue = valor_aps;

                }
                catch { }


                try
                {
                    dropEspecie.SelectedValue = valor_especie;

                }
                catch { }


                try
                {
                    dropStatus.SelectedValue = valor_status;

                }
                catch { }


                try
                {
                    dropResponsavel.SelectedValue = valor_responsavel;
                }
                catch { }







                // Carrega combo com os valores que estavam quando o usuario deixou a pagina.



            }

        }

        protected void btnLimparComboxMultFilter_Click(object sender, EventArgs e)
        {
           
        }

       


        protected void btnLimpaFiltros_Click1(object sender, EventArgs e)
        {

        }

        protected void btnLimpaFiltros_Click(object sender, EventArgs e)
        {
            try
            {

                valor_aps = "0";
                valor_especie = "0";
                valor_status = "0";
                valor_responsavel = "0";

                CarregaAps();

                CarregaEspecie();

                CarregaStatus();

                CarregaResponsavel();


            }
            catch
            {

            }

            GuardaComboNaSession();
        }



        [WebMethod]
        public static string consultar_web_service(string ids)
        {

            try
            {
                WsInfoqualy infoQualy = new WsInfoqualy();
                string ret = infoQualy.Start(ids);

                return ret;

            }
            catch(Exception ex)
            {

                return ex.Message;
            }
         
        }

        [WebMethod]
        public static string alterar_em_massa(string id_status, string id_responsavel, string id_clientes)
        {
            string retorno = null;
            try
            {
                Cliente c = new Cliente();
                retorno = c.alterar_em_massa(id_status, id_responsavel, id_clientes);

            }
            catch (Exception ex)
            {

                retorno = ex.Message;
            }

            return retorno;
        }


        private void CarregaEspecie()
        {
            ObjetoTransferencia.Especie especie = new ObjetoTransferencia.Especie();
            dropEspecie.Items.Clear();
            dropEspecie.DataSource = especie.ComboEspecie(Convert.ToInt32(id_user), valor_aps, valor_status, valor_responsavel, "usp_combos_consulta_cliente");
            dropEspecie.DataTextField = "nome";
            dropEspecie.DataValueField = "id";
            dropEspecie.DataBind();
            dropEspecie.Items.Insert(0, new ListItem("Selecione...", "0"));
            dropEspecie.Items.Insert(1, new ListItem("(Vazio)", "1000"));
        }

        private void CarregaResponsavel()
        {
            ObjetoTransferencia.Responsavel responsavel = new ObjetoTransferencia.Responsavel();
            dropResponsavel.Items.Clear();
            dropResponsavel.DataSource = responsavel.ComboResponsavel(Convert.ToInt32(id_user), valor_aps, valor_especie, valor_status, "usp_combos_consulta_cliente");
            dropResponsavel.DataTextField = "nome";
            dropResponsavel.DataValueField = "id";
            dropResponsavel.DataBind();
            dropResponsavel.Items.Insert(0, new ListItem("Selecione...", "0"));
            dropResponsavel.Items.Insert(1, new ListItem("(Vazio)", "1000"));

        }

        private void CarregaAps()
        {
            ObjetoTransferencia.Aps aps = new ObjetoTransferencia.Aps();
            dropAps.Items.Clear();
            dropAps.DataSource = aps.ComboAps(Convert.ToInt32(id_user), valor_especie, valor_status, valor_responsavel, "usp_combos_consulta_cliente");
            dropAps.DataTextField = "nome";
            dropAps.DataValueField = "id";
            dropAps.DataBind();
            dropAps.Items.Insert(0, new ListItem("Selecione...", "0"));
            dropAps.Items.Insert(1, new ListItem("(Vazio)", "1000"));

        }

        private void CarregaStatus()
        {
            ObjetoTransferencia.Status status = new ObjetoTransferencia.Status();
            dropStatus.Items.Clear();
            dropStatus.DataSource = status.ComboStatus(Convert.ToInt32(id_user), valor_aps, valor_especie, valor_responsavel, "usp_combos_consulta_cliente");
            dropStatus.DataTextField = "nome";
            dropStatus.DataValueField = "id";
            dropStatus.DataBind();
            dropStatus.Items.Insert(0, new ListItem("Selecione...", "0"));
            dropStatus.Items.Insert(1, new ListItem("(Vazio)", "1000"));

        }





        protected void dropAps_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                valor_aps = dropAps.SelectedValue ?? "0";
                valor_especie = dropEspecie.SelectedValue ?? "0";
                valor_status = dropStatus.SelectedValue ?? "0";
                valor_responsavel = dropResponsavel.SelectedValue ?? "0";
            }
            catch { }


            CarregaEspecie();

            CarregaStatus();

            CarregaResponsavel();


            try
            {
                dropAps.SelectedValue = valor_aps;

            }
            catch { }


            try
            {
                dropEspecie.SelectedValue = valor_especie;

            }
            catch { }


            try
            {
                dropStatus.SelectedValue = valor_status;

            }
            catch { }


            try
            {
                dropResponsavel.SelectedValue = valor_responsavel;
            }
            catch { }


            GuardaComboNaSession();




        }

        protected void dropEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                valor_aps = dropAps.SelectedValue ?? "0";
                valor_especie = dropEspecie.SelectedValue ?? "0";
                valor_status = dropStatus.SelectedValue ?? "0";
                valor_responsavel = dropResponsavel.SelectedValue ?? "0";
            }
            catch
            {


            }

            CarregaAps();

            CarregaStatus();

            CarregaResponsavel();

            try
            {
                dropAps.SelectedValue = valor_aps;

            }
            catch { }


            try
            {
                dropEspecie.SelectedValue = valor_especie;

            }
            catch { }

            try
            {
                dropStatus.SelectedValue = valor_status;

            }
            catch { }


            try
            {
                dropResponsavel.SelectedValue = valor_responsavel;
            }
            catch { }


            GuardaComboNaSession();



        }

        protected void dropStatus_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                valor_aps = dropAps.SelectedValue ?? "0";
                valor_especie = dropEspecie.SelectedValue ?? "0";
                valor_status = dropStatus.SelectedValue ?? "0";
                valor_responsavel = dropResponsavel.SelectedValue ?? "0";
            }
            catch { }



            CarregaAps();

            CarregaEspecie();

            CarregaResponsavel();


            try
            {
                dropAps.SelectedValue = valor_aps;

            }
            catch { }

            try
            {
                dropEspecie.SelectedValue = valor_especie;

            }
            catch { }

            try
            {
                dropStatus.SelectedValue = valor_status;

            }
            catch { }

            try
            {
                dropResponsavel.SelectedValue = valor_responsavel;
            }
            catch { }

            GuardaComboNaSession();

        }

        protected void dropResponsavel_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                valor_aps = dropAps.SelectedValue ?? "0";
                valor_especie = dropEspecie.SelectedValue ?? "0";
                valor_status = dropStatus.SelectedValue ?? "0";
                valor_responsavel = dropResponsavel.SelectedValue ?? "0";
            }
            catch { }



            CarregaAps();


            CarregaEspecie();


            CarregaStatus();


            try
            {
                dropAps.SelectedValue = valor_aps;

            }
            catch { }

            try
            {
                dropEspecie.SelectedValue = valor_especie;

            }
            catch { }

            try
            {
                dropStatus.SelectedValue = valor_status;

            }
            catch { }

            try
            {
                dropResponsavel.SelectedValue = valor_responsavel;
            }
            catch { }

            GuardaComboNaSession();





        }

        public void GuardaComboNaSession()
        {
            try
            {
                Session["combo_aps"] = valor_aps;
                Session["combo_especie"] = valor_especie;
                Session["combo_responsavel"] = valor_responsavel;
                Session["combo_status"] = valor_status;
            }
            catch
            {

            }

        }

        protected void btnLimparMultFilter_Click(object sender, EventArgs e)
        {
           
        }
    }
}