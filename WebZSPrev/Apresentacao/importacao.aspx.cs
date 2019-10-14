using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebZSPrev.ObjetoTransferencia;

namespace WebZSPrev.Apresentacao
{
    public partial class importacao : System.Web.UI.Page
    {
        string id = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                id = Session["id_usuario"].ToString();
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            
        }

        public void escreve()
        {
            
        }


        public void tredMsg()
        {

          

        
        }
        protected void Button1_Click(object sender, EventArgs e)
        {


            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FilePath = Server.MapPath("~/PlanilhasImportadas/" + FileName);
                FileUpload1.SaveAs(FilePath);
                // DataTable dt = excel_to_dt(FilePath, Extension, "1");
                DataTable dt2 = GetDataTableFromExcel(FilePath, true);



                // fazer duplo check na tabela temp (conferir se todos tem ids)
                // insert em massa na tabela cliente.


                // criar lote inserindo na tabela lote.
                Importacao ob = new Importacao();
                ob.id_responsavel = Convert.ToInt32(id);
                string lote = ob.manutencao("gerar_lote");

                // tirar os duplicados e inserir na tabela temp.
                ImportacaoLista impLista = new ImportacaoLista();

                int qtdTotal = dt2.Rows.Count;
                int qtdAtual = 0;
                int qtd_linha_vazia = 0;

                foreach (DataRow dr in dt2.Rows)
                {
                    Importacao imp = new Importacao();
                    qtdAtual++;
                    imp.id = null;
                    string _nb = dr[0].ToString();
                    imp.nb = dr[0].ToString();
                    imp.cidade = dr[1].ToString();
                    imp.requerente = dr[2].ToString();
                    string strDer = dr[3].ToString();

                    // LINHAS EM BRANCO 'GetDataTableFromExcel' ESTÁ 
                    // ENTENDO COMO LINHA DE DADOS MAS ESTÁ TOTALMENTE EM BRANCO, NESSE CASO ESTOU PULANDO ESSAS LINHAS...
                    // SE TODAS A PROP DO OBJ FOREM DIFERENTE DE VAZIO.. ENTÃO VALIDA
                    if (imp.nb != "" || imp.cidade != "" || imp.requerente != "")
                    {
                        //******************************************************
                        //------------------- 
                        //------------------- VALIDAÇÕES
                        //------------------- 
                        //******************************************************


                        bool nb_valido = validaNB(_nb);

                        if (!nb_valido)
                        {
                            ob.manutencao("para_importacao");
                            string tbl = @"<table id='tbl - result' class='minimalistBlack'>";
                            tbl += "<tr><td>NB inconsistente: </td><td> " + _nb + "</td></tr></table>";
                            result_import.Text = tbl;
                            return;
                        }




                        DateTime der;

                        if (DateTime.TryParse(strDer, out der))
                        {
                            imp.der = der;
                        }

                        else
                        {
                            ob.manutencao("para_importacao");
                            string tbl = @"<table id='tbl - result' class='minimalistBlack'>";
                            tbl += "<tr><td>Data inconsistente: </td><td> " + strDer + "</td></tr></table>";
                            result_import.Text = tbl;
                            return;

                        }


                        imp.lote = Convert.ToInt32(lote);
                        impLista.Add(imp);
                        imp.manutencao("inserir");


                    }
                    else
                    {
                        qtd_linha_vazia++;
                        if(qtd_linha_vazia > 3)
                        {
                            qtd_linha_vazia = 0;
                            break;
                        }
                    }

                }


                string html = ob.manutencao("segunda_etapa");
                result_import.Text = html;




                //obj preenchido
            }


        }

        public bool validaNB(string nb)
        {

            if (nb.Length == 16)
            {
                if (nb.Substring(2, 1) == "/" && nb.Substring(6, 1) == "." && nb.Substring(10, 1) == "." && nb.Substring(14, 1) == "-")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            {
                return false;
            }

        }

        private DataTable excel_to_dt(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties='Excel 8.0;HDR={1}'";
                    break;

                case ".xlsx": //Excel 07
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 8.0;HDR={1}'";

                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();

            return dt;
        }

        public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        string texto = cell.Text.Trim();
                        row[cell.Start.Column - 1] = texto;
                    }
                }
                return tbl;
            }
        }
    }
}