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
    public partial class administracaoUser1 : System.Web.UI.Page
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



        }


        [WebMethod]
        public static string inserir(string nome, string usuario, string senha, string email, string permissao)
        {
            string retorno = "Inserido com sucesso!";
            try
            {
                Responsavel objeto = new Responsavel();
                objeto.nome = nome;
                objeto.usuario = usuario;
                objeto.senha = senha;
                objeto.email = email;
                objeto.permissao = permissao;
                objeto.manutencao("usp_manutencao_responsavel", "inserir");
            }
            catch (Exception ex)
            {
                retorno = "Falha, motivo: " + ex.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string alterar(int id, string nome, string usuario, string senha, string email, string permissao)
        {
            string retorno = "Alterado com sucesso!";
            try
            {
                Responsavel objeto = new Responsavel();
                objeto.id = id;
                objeto.nome = nome;
                objeto.usuario = usuario;
                objeto.senha = senha;
                objeto.email = email;
                objeto.permissao = permissao;
                objeto.manutencao("usp_manutencao_responsavel", "alterar");
            }
            catch (Exception ex)
            {
                retorno = "Falha, motivo: " + ex.ToString();
            }
            return retorno;
        }


        [WebMethod]
        public static string excluir(int id)
        {

            string retorno = "Excluído com sucesso!";
            try
            {
                Responsavel objeto = new Responsavel();
                objeto.id = id;
                objeto.apagado = 1;
                objeto.manutencao("usp_manutencao_responsavel", "alterar");
            }
            catch (Exception ex)
            {
                retorno = "Falha, motivo: " + ex.ToString();
            }
            return retorno;

        }


        private static string jresponse(DataTable dt)
        {
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string json = JsonConvert.SerializeObject(dt, Formatting.None, jsSettings);
            return json;
        }


        [WebMethod]
        public static string consultar(int id)
        {
            string retorno = null;
            ObjetoTransferencia.Responsavel objeto = new Responsavel();
            objeto.id = id;
            using (DataTable dt = objeto.consultadt("usp_manutencao_responsavel", "consultar"))
            {
                retorno = jresponse(dt);
            }

            return retorno;
        }










    }
}