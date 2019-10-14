<%@ Page Title="" Language="C#" MasterPageFile="~/Apresentacao/View.Master" AutoEventWireup="true" CodeBehind="importacao.aspx.cs" Inherits="WebZSPrev.Apresentacao.importacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        document.getElementById("itens_menu").getElementsByTagName("li")[2].className = 'active';
    </script>


    <!-- /.row -->
    <div class="row" style="margin-top: 5px;">
        <div class="col-lg-12" style="margin-top: 10px;">
            <div class="panel panel-default">
                <div class=" panel-heading">Importação</div>
                <div class="panel-body">


                    <div class="form-group">
                        <label>Importar registros</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                       
                    </div>


                    <p>

                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Iniciar importação" OnClick="Button1_Click" OnClientClick="msg();" />
                      
                    </p>

                    <p>
                        <asp:Label ID="result" Text="" runat="server" />
                        <asp:Label ID="result_import" Text="" runat="server" />

                    </p>
                </div>
            </div>
        </div>
        <!-- /.panel -->
    </div>
    <!-- /.col-lg-12 -->

    <script>
        function msg()
        {
            document.getElementById("ContentPlaceHolder1_result").innerText = "Importando os registros, aguarde...";
            try
            {
                document.getElementById("ContentPlaceHolder1_tbl-result").remove();
            }
            catch(ex)
            {

            }

        }
    </script>


</asp:Content>
