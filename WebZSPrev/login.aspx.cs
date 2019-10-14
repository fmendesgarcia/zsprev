using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebZSPrev.Apresentacao
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ObjetoTransferencia.Responsavel resp = new ObjetoTransferencia.Responsavel();

            resp.usuario = txtuser.Text;
            resp.senha = txtsenha.Text;

            resp.dataalt = null;
            resp.datacad = null;

            string retorno = resp.manutencao("usp_manutencao_responsavel", "acesso");

            int id;

            bool resultado = int.TryParse(retorno, out id);

            if(resultado)
            {
                if(id > 0)
                {
                    List<ObjetoTransferencia.Responsavel> lista =  resp.consulta("usp_manutencao_responsavel", "consultar");
                    resp = lista[0];


                    Session["id_usuario"] = resp.id;
                    Session["nome"] = resp.nome;
                    Session["usuario"] = resp.usuario;
                    Session["permissao"] = resp.permissao;

                    Response.Redirect("consultaCliente.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Usuario ou senha incorretos!');", true);
                }
            }
        }
    }
}