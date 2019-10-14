<%@ Page Title="" Language="C#" MasterPageFile="~/Apresentacao/View.Master" AutoEventWireup="true" CodeBehind="cadDocumento.aspx.cs" Inherits="WebZSPrev.Apresentacao.documento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row" style="margin-top: 10px;">
        <div class="col-lg-12" style="margin-top: 10px;">
            <div class="panel panel-default">

                <div class="panel-body">
                    <div class="row">
                        <div class="" style="margin-right: 0px; margin-left: 0px;">
                            <div class="col-lg-12">
                                <div class="col-sm-12">
                                    <ul class="nav nav-tabs">
                                        <li role="presentation"><a href="cadCliente.aspx">Cliente</a></li>
                                        <li role="presentation"><a href="cadCompromisso.aspx">Compromissos</a></li>
                                        <li role="presentation" class="active"><a href="cadDocumento.aspx">Documentos</a></li>
                                    </ul>


                                    <div class="alert alert-danger" style="margin-top: 25px;">
                                        <strong>Atenção!</strong> Somente serão aceitos arquivos no seguintes formatos: <strong>(PDF, JPG)</strong>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-2 form-group" style="margin-top: 25px;">
                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalDocumento">Incluir</button>
                                        </div>
                                    </div>

                                    <!-- Modal Contato - Inicio -->
                                    <div class="modal" id="modalDocumento" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                        <div class="modal-dialog modal-lg" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="">Editar</h4>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="row" style="margin: 10px;">
                                                        <div class="row-sm-2 form-group">
                                                            <label>Enviar Arquivo</label>
                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                        </div>

                                                        <div class="row-sm-2 form-group">
                                                            <label>Tipo documento</label>
                                                            <asp:DropDownList ID="ddlTipoDoc" CssClass="form-control" runat="server" class="form-control">
                                                                <asp:ListItem Text="Selecione..." />
                                                            </asp:DropDownList>
                                                        </div>

                                                        <div class="row-sm-2 form-group">
                                                            <label>Obs.: </label>
                                                            <asp:TextBox ID="txtObs" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>




                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                                                    <asp:Button Text="Incluir Documento" runat="server" CssClass="btn btn-primary" ID="btnGravaDocumento" OnClick="btnGravaDocumento_Click" />

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Modal Contato - Fim -->


                                    <div id="load_documento" style="padding: 5px"></div>
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">Documentos</h3>
                                        </div>
                                        <div class="panel-body">

                                            <div class="row" style="margin-top: 20px;">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <table id="table-documento" class="table table-striped table-bordered table-hover" style="width: 100%">
                                                            <thead>
                                                                <tr>


                                                                    <th>Data Cadastro</th>
                                                                    <th>Responsável</th>
                                                                    <th>Tipo Documento</th>
                                                                    <th>Nome</th>
                                                                    <th>Obs.</th>
                                                                    <th>Ação</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>

                                            </div>



                                        </div>
                                    </div>
                                    <input id="hidcliente" type="hidden" name="name" value="" runat="server" />
                                    <input id="hidDocumento" type="hidden" name="name" value="" runat="server" />
                                    <asp:Button ID="btnDownloadFile" runat="server" Text="Button" OnClick="btnDownloadFile_Click" Style="height: 0px; width: 0px; background-color: white; border: none;" />

                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="height: 0px; width: 0px; background-color: white; border: none; color: white;">LinkButton</asp:LinkButton>



                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>


    <script>



        $(document).ready(function () {


            // window.document.getElementById('__EVENTARGUMENT').value = '';

            var cliente = geral.GetObjFromWebStorage("_obj");

            document.getElementById("ContentPlaceHolder1_hidcliente").value = cliente.id.toString();

            ConsultaDocumento(cliente.id);

        });

        function downloadFile(id, item) {



            var nome = item.getAttribute("nome-file");
            nome = nome.split('.');
            nome = nome[0];



            __doPostBack('ContentPlaceHolder1_btnDownloadFile', id + ";" + nome);


            theForm.__EVENTARGUMENT.value = '';

        }




        function ConsultaDocumento(id) {

            // Limpas campos do modal:
            // geral.LimpaCamposModal('modalCompromisso');


            $("#load_documento").append("<img src=\"imgs/preloader.gif\" />");
            $.getJSON('requests.aspx?objeto=documento&id= ' + id, function (dados) {
                if (dados.length > 0) {
                    PopulaDocumento(dados);

                }
            });

            $("#load_documento").html("");


            // Abre o modal:
            // geral.AbrirModal('modalCompromisso');
        }


        function PopulaDocumento(dados) {


            var oTable = $('#table-documento').DataTable({
                responsive: true
   , "pageLength": 10,
                //"dom": 'flipt'
                data: dados,

                language: {
                    "decimal": "",
                    "emptyTable": "Nenhum registro cadastrado",
                    "info": "Mostrando _START_ de _END_ do total de _TOTAL_ registros",
                    "infoEmpty": "Exibindo 0 de 0 do total de 0 registros",
                    "infoFiltered": "",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Exibindo _MENU_ registros",
                    "loadingRecords": "Processando...",
                    "processing": "Processando...",
                    "search": "Procurar:",
                    "zeroRecords": "Nenhum registro encontrado",
                    "paginate": {
                        "first": "Primeira",
                        "last": "Última",
                        "next": "Próxima",
                        "previous": "Anterior"
                    },
                    "aria": {
                        "sortAscending": ": activate to sort column ascending",
                        "sortDescending": ": activate to sort column descending"
                    }
                },

                columns: [

               { "data": "datacad" },
               { "data": "nome" },
               { "data": "tipo" },
               { "data": "nome_original" },
               { "data": "obs" },
               { "data": "buttons" }

                ],

                 columnDefs: [
                    { width: 100, targets: 5 }
                ]

            });

        }


    </script>
</asp:Content>
