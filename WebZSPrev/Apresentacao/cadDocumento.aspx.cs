using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebZSPrev.Apresentacao
{
    public partial class documento : System.Web.UI.Page
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
                ObjetoTransferencia.TipoDoc tipoDoc = new ObjetoTransferencia.TipoDoc();
                ddlTipoDoc.DataSource = tipoDoc.consulta("usp_manutencao_tipo_doc", "consultar");
                ddlTipoDoc.DataTextField = "nome";
                ddlTipoDoc.DataValueField = "id";
                ddlTipoDoc.DataBind();
                ddlTipoDoc.Items.Insert(0, new ListItem("Selecione...", "0"));




            }





            try
            {
                string _evt = this.Request["__EVENTTARGET"]; // 1st parameter

                if (_evt == "ContentPlaceHolder1_btnDownloadFile")
                {
                    string id_e_nome = Request["__EVENTARGUMENT"]; // parameter

                    if (!String.IsNullOrEmpty(id_e_nome))
                    {
                        string[] parametros;
                        int id = 0;
                        int nome = 1;

                        parametros = id_e_nome.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        Response.ContentType = "Application/pdf";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + parametros[nome] + ".pdf");
                        Response.TransmitFile(Server.MapPath("~/Documentos/") + parametros[id] + ".pdf");
                        //Response.End();
                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           



        }

        protected void btnGravaDocumento_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {

                    ObjetoTransferencia.Documento doc = new ObjetoTransferencia.Documento();

                    string filename = Path.GetFileName(FileUpload1.FileName);
                    doc.nome_original = filename;
                    string strId = doc.manutencao("usp_manutencao_documento", "inserir");
                    FileUpload1.SaveAs(Server.MapPath("~/Documentos/") + strId + ".pdf");

                    doc.id_cliente = Convert.ToInt32(hidcliente.Value);
                    doc.id_tipo = Convert.ToInt32(ddlTipoDoc.SelectedValue.ToString());
                    doc.id_responsavel = Convert.ToInt32(Session["id_usuario"]);
                    doc.obs = txtObs.Text;
                    doc.nome_salvo = strId;
                    doc.id = Convert.ToInt32(strId);
                    doc.dataalt = null;
                    doc.datacad = null;

                    doc.manutencao("usp_manutencao_documento", "alterar");

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        protected void btnDownloadFile_Click(object sender, EventArgs e)
        {
            string id_e_nome = Request["__EVENTARGUMENT"]; // parameter

            if (!String.IsNullOrEmpty(id_e_nome))
            {
                string[] parametros;
                int id = 0;
                int nome = 1;

                parametros = id_e_nome.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + parametros[id] + ".pdf");
                Response.TransmitFile(Server.MapPath("~/Documentos/") + parametros[nome] + ".pdf");
                //Response.End();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
         

        }
    }
}