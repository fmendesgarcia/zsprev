using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebZSPrev.Apresentacao
{
    public partial class View : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        

            string permissao = null;
            string nome = null;
            try
            {
                permissao = Session["permissao"].ToString();
            }
            catch { }

            try
            {
                nome = Session["nome"].ToString();
            }
            catch { }



            string menu = "";
            if (string.IsNullOrEmpty(permissao))
            {
                //Response.Redirect("login.aspx");
            }
            else
            {
                if (permissao == "p1")
                {



                    menu = @"<div class=""collapse navbar-collapse"" id=""bs-example-navbar-collapse-1"">" +
                           @"<ul id = ""itens_menu"" style=""font-weight: bold;"" runat=""server"" class=""nav navbar-nav"">" +
                           @"<li class=""""><a onclick=""active_no_clicado(this); "" href=""consultacliente.aspx"">Consultar</a></li> </ul>" +
                                           
                           
                           @"<ul id=""itens_menu"" runat=""server"" class=""nav navbar-nav"" style=""float: right;"">" +
                             @"<li class=""active""><div style=""float: right; font-size: 14px; margin-top: 16px; color: black; margin-right: 8px; ""> Olá, <b>" + nome.ToUpper() + "</b> </div></a></li>" +
                             @"<li class=""active"">" +
                                     @"<a onclick=""sair();"" style=""padding: 0px;"" href=""login.aspx""><img src=""imgs/desligar.JPEG"" style=""width: 30px; height: 35px;margin-top: 8px;""></a></li></ul></div>";





                }
                else
                {

                    menu = @"<div class=""collapse navbar-collapse"" id=""bs-example-navbar-collapse-1"">" +
                           @"<ul id = ""itens_menu"" style=""font-weight: bold;"" runat=""server"" class=""nav navbar-nav"">" +
                           @"<li class=""""><a onclick=""active_no_clicado(this); "" href=""consultacliente.aspx"">Consultar</a></li>" +
                  @"<li class=""""><a onclick = ""active_no_clicado(this); limpa_obj();"" href=""cadcliente.aspx"">Incluir</a></li>" +

                 @"<li class=""""><a onclick = ""active_no_clicado(this);"" href=""importacao.aspx"">Importar</a></li>" +

                 @"<li class=""""><a onclick = ""active_no_clicado(this); limpa_obj();"" href=""administracaoMenu.aspx"">Administração</a></li>" +
                 @"</li></ul>" +

                 @"<ul id=""itens_menu"" runat=""server"" class=""nav navbar-nav"" style=""float: right;"">" +
                 @"<li class=""active""><div id=""div_adm"" style=""float: right; font-size: 14px; margin-top: 16px; color: black; margin-right: 8px; ""> Olá, <b>" + nome.ToUpper() + "</b> </div></a></li>" +
                 @"<li class=""active"">" +

                 @"<a onclick=""sair();"" style=""padding: 0px;"" href=""login.aspx""><img src=""imgs/desligar.JPEG"" style=""width: 30px; height: 35px;margin-top: 8px;""></a></li></ul></div>";

                             


                         
                }
            }

            menu_server.InnerHtml = menu;



        }
    }
}