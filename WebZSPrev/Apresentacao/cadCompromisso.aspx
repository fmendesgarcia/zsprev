<%@ Page Title="" Language="C#" MasterPageFile="~/Apresentacao/View.Master" AutoEventWireup="true" CodeBehind="cadCompromisso.aspx.cs" Inherits="WebZSPrev.Apresentacao.compromisso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row" style="margin-top: 10px;">
        <div class="col-lg-12" style="margin-top: 10px;">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <div style="margin-right: 0px; margin-left: 0px;">
                            <div class="col-lg-12">
                                <div class="col-sm-12">
                                    <ul class="nav nav-tabs">
                                        <li role="presentation"><a href="cadCliente.aspx">Cliente</a></li>
                                        <li role="presentation" class="active"><a href="cadCompromisso.aspx">Compromissos</a></li>
                                        <li role="presentation"><a href="cadDocumento.aspx">Documentos</a></li>
                                    </ul>

                                    <div class="row">
                                        <div class="col-sm-2 form-group" style="margin-top: 25px;">
                                            <button type="button" class="btn btn-primary" onclick="geral.AbrirModal('modalCompromisso'); LimpaCamposModal('modalCompromisso');">Incluir</button>
                                        </div>
                                    </div>


                                    <div id="load_compromisso"></div>
                                    <!-- Modal Compromisso - Inicio -->
                                    <div class="modal" id="modalCompromisso" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                        <div class="modal-dialog modal-lg" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="">Editar</h4>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="row" style="margin: 10px;">
                                                        <div class="row">

                                                            <div class="col-sm-3 form-group">
                                                                <label>Agendar para a data:</label>
                                                                <asp:TextBox ID="txtData" CssClass="form-control date" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row-sm-2 form-group">
                                                            <label>Responsável</label>
                                                            <asp:DropDownList ID="ddlResponsavel" CssClass="form-control" runat="server" class="form-control">
                                                                <asp:ListItem Text="Selecione..." />
                                                            </asp:DropDownList>
                                                        </div>


                                                        <div class="row-sm-2 form-group">
                                                            <label>Tipo do compromisso</label>

                                                            <asp:DropDownList ID="ddlTipoCompromisso" CssClass="form-control" runat="server" class="form-control">
                                                                <asp:ListItem Text="Selecione..." />
                                                            </asp:DropDownList>

                                                        </div>

                                                        <div class="form-group">
                                                            <label>Texto do compromisso</label>
                                                            <asp:TextBox ID="txtCompromisso" runat="server" Height="72px" TextMode="MultiLine" Width="100%" />
                                                        </div>



                                                        <div class="form-group">
                                                            <label>Status do compromisso</label>


                 


                                                            <div class="radio">
                                                                <label>
                                                                    <input id="radio_pendente" runat="server" type="radio" name="optradio" />Pendente
                                                                </label>
                                                            </div>
                                                            <div class="radio">
                                                                <label>
                                                                    <input id="radio_concluido" runat="server" type="radio" name="optradio" />Concluído
                                                                </label>
                                                            </div>




                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                                                            <asp:Button Text="GRAVAR" runat="server" class="btn btn-primary" ID="btnGravaCompromisso" OnClick="btnGravaCompromisso_Click" />
                                                        </div>

                                                    </div>
                                                </div>


                                            </div>

                                        </div>
                                    </div>

                                    <!-- Modal Compromisso - Fim -->


                                    <!-- CONSULTA DE COMPROMISSOS -->

                                    <div id="load_movimentacao" style="padding: 5px"></div>
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">Compromissos</h3>
                                        </div>
                                        <div class="panel-body">

                                            <div class="row" style="margin-top: 20px;">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <table id="table-compromisso" class="table table-striped table-bordered table-hover" style="width: 100%">
                                                            <thead>
                                                                <tr>
                                                                    <th>Data Agendado</th>
                                                                    <th>Responsável</th>
                                                                    <th>Tipo</th>
                                                                    <th>Texto</th>
                                                                    <th>Status</th>
                                                                    <th>Data Cad.</th>
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


                                    <!-- FIM:  CONSULTA DE COMPROMISSOS -->
                                </div>
                                <input id="hidcliente" type="hidden" name="name" value="" runat="server" />
                                <input id="hidCompromisso" type="hidden" name="name" value="" runat="server" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {

            var cliente = geral.GetObjFromWebStorage("_obj");

            document.getElementById("ContentPlaceHolder1_hidcliente").value = cliente.id.toString();

            ConsultaCompromisso(cliente.id);

            //geral.CarregaCombo('tipo_comp', 'ContentPlaceHolder1_ddlTipoCompromisso');
            //geral.CarregaCombo('user', 'ContentPlaceHolder1_ddlResponsavel');

        });


        function ConsultaIdCompromisso(id) {

            // Limpas campos do modal:
            geral.LimpaCamposModal('modalCompromisso');

            var retorno = null;
            $.getJSON('requests.aspx?objeto=compromisso_id&id= ' + id, function (dados) {

                if (dados.length > 0) {
                    document.getElementById("ContentPlaceHolder1_txtData").value = dados[0].data_compromisso;
                    dados[0].id_responsavel == null ? $("#ContentPlaceHolder1_ddlResponsavel option:contains('Selecione')").attr('selected', 'selected') : $("#ContentPlaceHolder1_ddlResponsavel").val(dados[0].id_responsavel);
                    dados[0].id_tipo == null ? $("#ContentPlaceHolder1_ddlTipoCompromisso option:contains('Selecione')").attr('selected', 'selected') : $("#ContentPlaceHolder1_ddlTipoCompromisso").val(dados[0].id_tipo);
                    document.getElementById("ContentPlaceHolder1_txtCompromisso").value = dados[0].texto;
                    document.getElementById("ContentPlaceHolder1_hidCompromisso").value = dados[0].id;

                    var status = dados[0].status_compromisso; // receber o pendente

            

                    if (status == 1) {
                        // pendente
                        document.getElementById("ContentPlaceHolder1_radio_pendente").checked = true;
                    }
                    else if (status == 2) {
                        // concluído
                        document.getElementById("ContentPlaceHolder1_radio_concluido").checked = true;
                    }

                    // Abre o modal:
                    geral.AbrirModal('modalCompromisso');
  


                }
                else {
                    alert("Falha, no metodo js ConsultaIdCompromisso, id: " + id.toString());
                }

            });

           
        }

        function ConsultaCompromisso(id) {

            // Limpas campos do modal:
            // geral.LimpaCamposModal('modalCompromisso');


            $("#load_compromisso").append("<img src=\"imgs/preloader.gif\" />");
            $.getJSON('requests.aspx?objeto=compromisso&id= ' + id, function (dados) {
                if (dados.length > 0) {
                    PopulaCompromisso(dados);

                }
            });

            $("#load_compromisso").html("");


            // Abre o modal:
            // geral.AbrirModal('modalCompromisso');
        }


        function PopulaCompromisso(dados) {


            var oTable = $('#table-compromisso').DataTable({
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

               { "data": "data" },
               { "data": "nome" },
               { "data": "tipo" },
               { "data": "texto" },
               { "data": "status" },
               { "data": "buttons" }

                ]

            });

        }


    </script>



</asp:Content>
