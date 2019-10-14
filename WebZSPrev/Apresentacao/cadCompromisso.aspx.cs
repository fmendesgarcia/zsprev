using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebZSPrev.Apresentacao
{
    public partial class compromisso : System.Web.UI.Page
    {
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

                //Response.Redirect("login.aspx");
            }



            if (!IsPostBack)
            {
                ObjetoTransferencia.TipoCompromisso tc = new ObjetoTransferencia.TipoCompromisso();
                ddlTipoCompromisso.DataSource = tc.consulta("usp_manutencao_tipo_compromisso", "consultar");
                ddlTipoCompromisso.DataTextField = "nome";
                ddlTipoCompromisso.DataValueField = "id";
                ddlTipoCompromisso.DataBind();
                ddlTipoCompromisso.Items.Insert(0, new ListItem("Selecione...", "0"));

                ObjetoTransferencia.Responsavel resp = new ObjetoTransferencia.Responsavel();
                ddlResponsavel.DataSource = resp.consulta("usp_manutencao_responsavel", "consultar");
                ddlResponsavel.DataTextField = "nome";
                ddlResponsavel.DataValueField = "id";
                ddlResponsavel.DataBind();
                ddlResponsavel.Items.Insert(0, new ListItem("Selecione...", "0"));

            }

        }

        protected void btnGravaCompromisso_Click(object sender, EventArgs e)
        {
            try
            {


                ObjetoTransferencia.Compromisso compromisso = new ObjetoTransferencia.Compromisso();
                compromisso.id_cliente = Convert.ToInt32(hidcliente.Value);


                DateTime dt;
                if (DateTime.TryParse(txtData.Text, out dt))
                    compromisso.data = dt;


                compromisso.datacad = null;
                compromisso.id_tipo = Convert.ToInt32(ddlTipoCompromisso.SelectedValue.ToString());
                compromisso.id_responsavel = Convert.ToInt32(ddlResponsavel.SelectedValue.ToString());
                compromisso.texto = txtCompromisso.Text;


                string comando = "";

                if (!string.IsNullOrEmpty(hidCompromisso.Value))
                {
                    comando = "alterar";
                    compromisso.id = Convert.ToInt32(hidCompromisso.Value);
                }
                else
                {
                    comando = "inserir";
                }

                if (radio_pendente.Checked)
                {
                    compromisso.id_status = 3;
                }
                else
                {
                    compromisso.id_status = 4;
                }


                compromisso.manutencao("usp_manutencao_compromisso", comando);

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar gravar movimentação, motivo: " + ex.Message);
            }
        }
    }
}