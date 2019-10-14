<%@ Page Title="" Language="C#" MasterPageFile="~/Apresentacao/View.Master" AutoEventWireup="true" CodeBehind="cadCliente.aspx.cs" Inherits="WebZSPrev.Apresentacao.cadCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script>
        document.getElementById("itens_menu").getElementsByTagName("li")[1].className = 'active';
    </script>

    <style type="text/css">
        @media print {
            * {
                visibility: hidden;
            }

            .yesprint {
                visibility: visible;
                position: absolute;
                top: 0;
                left: 0;
            }
        }
    </style>

    <div class="row" style="margin-top: 10px;">
        <div class="col-lg-12" style="margin-top: 10px;">
            <div class="panel panel-default">

                <div class="panel-body">
                    <div class="row">


                        <div class="" style="margin-right: 0px; margin-left: 0px;">
                            <div class="col-lg-12">
                                <div class="col-sm-12">


                                    <ul class="nav nav-tabs">

                                        <li role="presentation" class="active"><a href="cadCliente.aspx">Cliente</a></li>
                                        <li role="presentation"><a href="cadCompromisso.aspx">Compromissos</a></li>
                                        <li role="presentation"><a href="cadDocumento.aspx">Documentos</a></li>
                                    </ul>

                                    <div class="row" style="margin: 5px">
                                    </div>




                                      <!-- Modal Cliente - Inicio -->
                                    <div class="modal" id="modalCliente" tabindex="-1" role="dialog" aria-labelledby="modalClienteLabel">
                                        <div class="modal-dialog modal-lg" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="modalClienteLabel">Editar</h4>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="row">
                                                        <div class="col-sm-8 form-group">
                                                            <label>Nome</label>
                                                            <input id="mspanNome" type="text" placeholder="" class="form-control" runat="server" />
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label>Status da pasta</label>
                                                            <select id="mspanStatusPasta" class="form-control">
                                                                <option value="0">Selecione...</option>
                                                            </select>
                                                        </div>
                                                    </div>



                                                    <div class="row">
                                                        <div class="col-sm-4 form-group">
                                                            <label>Número benefício</label>
                                                            <input id="mspanNB" type="text" placeholder="" class="form-control nbeneficio" readonly onfocusout="ConsultaIdEspecie(this.value);" />
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label>CPF</label>
                                                            <input id="mspanCPF" onclick="geral.RemoverPontos(this.id);" type="text" placeholder="" class="form-control cpf" />
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label>Data Nascimento</label>
                                                            <input id="mspanDN" type="text" placeholder="" class="form-control date" />
                                                        </div>
                                                    </div>

                                                    <div class="row">

                                                        <div class="col-sm-4 form-group">
                                                            <label>DER</label>
                                                            <input id="mspanDER" type="text" placeholder="" class="form-control date" />
                                                        </div>

                                                        <div class="col-sm-8 form-group">
                                                            <label>Espécie</label>
                                                            <select id="mspanEspecie" class="form-control" runat="server">
                                                                <option value="0">Selecione...</option>
                                                            </select>
                                                        </div>

                                                    </div>

                                                    <div class="row">



                                                        <div class="col-sm-4 form-group">
                                                            <label>Situação benefício</label>
                                                            <select id="mspanSituacaoBeneficio" class="form-control">
                                                                <option value="0">Selecione...</option>
                                                            </select>
                                                        </div>

                                                        <div class="col-sm-8 form-group">
                                                            <label>Motivo</label>
                                                            <select id="mspanMotivo" class="form-control">
                                                                <option value="0">Selecione...</option>
                                                            </select>
                                                        </div>





                                                        <div class="col-sm-4 form-group" style="display: none;">
                                                            <label>Tipo</label>
                                                            <select id="mspanTipo" class="form-control">
                                                                <option value="0">Selecione...</option>
                                                            </select>
                                                        </div>








                                                    </div>

                                                    <div class="row">



                                                        <div class="col-sm-4 form-group">

                                                            <label>APS de origem</label>
                                                            <select id="mspanAps" class="form-control" runat="server">
                                                                <option value="0">Selecione...</option>
                                                            </select>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label>Status</label>
                                                            <select id="mspanStatus" class="form-control">
                                                                <option value="0">Selecione...</option>
                                                            </select>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label>Responsável</label>
                                                            <select id="mspanResponsavel" class="form-control" runat="server">
                                                                <option value="0">Selecione...</option>
                                                            </select>
                                                        </div>


                                                    </div>

                                                    <div class="row" style="padding: 15px;">
                                                        <button type="button" class="btn btn-info" onclick="ir('inss_beneficio');" style="color: #444; background-color: #d0d3d6; border-color: #ffffff; font-size: 12px;">Situação do beneficio</button>
                                                        <button type="button" class="btn btn-info" onclick="ir('inss_concessao');" style="color: #444; background-color: #d0d3d6; border-color: #ffffff; font-size: 12px;">Carta de concessão</button>
                                                        <button type="button" class="btn btn-info" onclick="ir('inss_revisao');" style="color: #444; background-color: #d0d3d6; border-color: #ffffff; font-size: 12px;">Situação em revisão</button>
                                                        <button type="button" class="btn btn-info" onclick="ir('inss_pagamento');" style="color: #444; background-color: #d0d3d6; border-color: #ffffff; font-size: 12px;">Extrato de pagamento</button>
                                                        <button type="button" class="btn btn-info" onclick="ir('jefsp');" style="color: #444; background-color: #d0d3d6; border-color: #ffffff; font-size: 12px;">JEFSP</button>
                                                        <button type="button" class="btn btn-info" onclick="ir('esaj');" style="color: #444; background-color: #d0d3d6; border-color: #ffffff; font-size: 12px;">ESAJ</button>

                                                    </div>

                                                </div>
                                                <div class="modal-footer">


                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                                                    <button id="btnGravaCliente" type="button" class="btn btn-primary" onclick="inserir_cliente();">Gravar</button>


                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Modal Cliente - Fim -->


                                    <!--INICIO CLIENTE-->

                                    <div id="load_cliente"></div>

                                    <div id="pnlImpressao1">
                                        <div class="panel panel-primary" style="margin-bottom: 5px;">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">Dados do cliente</h3>
                                            </div>
                                            <div class="panel-body">


                                                <div id="row_cliente" class="row">
                                                    <div id="div_cliente" class="col-sm-12 form-group" style="margin-top: 10px;">

                                                        <!--essa-->

                                                        <%-- <div class="row">
                                                        <div class="col-sm-8 form-group">
                                                            <label>Nome</label>
                                                            <span id="spanNome"></span>
                                                        </div>

                                                      
                                                    </div>



                                                    <div class="row">
                                                        <div class="col-sm-4 form-group">
                                                            <label>Número benefício</label>
                                                          <span id="spanNB"></span>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label>CPF</label>
                                                           <span id="spanCPF"></span>
                                                        </div>
                                                      
                                                    </div>

                                                    <div class="row">

                                                        <div class="col-sm-4 form-group">
                                                            <label>DER</label>
                                                             <span id="spanDER"></span>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label>Espécie</label>
                                                        <span id="spanEspecie"></span>
                                                        </div>

                                                          <div class="col-sm-4 form-group">
                                                            <label>Status da pasta</label>
                                                                 <span id="spanStatusPasta"></span>
                                                        </div>

                                                    </div>

                                                    <div class="row">



                                                        <div class="col-sm-4 form-group">
                                                            <label>Situação benefício</label>
                                                             <span id="spanSituacaoBeneficio"></span>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label>Motivo</label>
                                                             <span id="spanMotivo"></span>
                                                        </div>

                                                          <div class="col-sm-4 form-group">
                                                            <label>Data Nascimento</label>
                                                          <span id="spanDN"></span>
                                                        </div>





                                                        <div class="col-sm-4 form-group" style="display: none;">
                                                            <label>Tipo</label>
                                                           <span id="spanTipo"></span>
                                                        </div>








                                                    </div>

                                                    <div class="row">



                                                        <div class="col-sm-4 form-group">

                                                            <label>APS de origem</label>
                                                           <span id="spanAps"></span>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label>Status</label>
                                                                <span id="spanStatus"></span>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label>Responsável</label>
                                                                 <span id="spanResponsavel"></span>
                                                        </div>


                                                    </div>--%>



                                                        <!--fimessa-->


                                                        <!-- inicio tentando arrumar a tela... -->

                                                        <div class="col-sm-6 form-group">
                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label class="">Nome: </label>
                                                                    <span class="" id="spanNome"></span>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>Número beneficio: </label>
                                                                    <span id="spanNB"></span>
                                                                </div>
                                                            </div>


                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>CPF: </label>
                                                                    <span id="spanCPF"></span>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>Data Nascimento: </label>
                                                                    <span id="spanDN"></span>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>DER:</label>
                                                                    <span id="spanDER"></span>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-sm-12 form-group" style="display: none;">
                                                                    <label>Tipo:</label>
                                                                    <span id="spanTipo"></span>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>Situação Beneficio:</label>
                                                                    <span id="spanSituacaoBeneficio"></span>
                                                                </div>
                                                            </div>



                                                        </div>

                                                        <div class="col-sm-6 form-group">



                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>Motivo:</label>
                                                                    <span id="spanMotivo"></span>
                                                                </div>
                                                            </div>



                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>Status:</label>
                                                                    <span id="spanStatus"></span>
                                                                </div>
                                                            </div>




                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>Status da pasta:</label>
                                                                    <span id="spanStatusPasta"></span>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>Espécie:</label>
                                                                    <span id="spanEspecie"></span>
                                                                </div>
                                                            </div>


                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>Aps:</label>
                                                                    <span id="spanAps"></span>
                                                                </div>
                                                            </div>


                                                            <div class="row">
                                                                <div class="col-sm-12 form-group">
                                                                    <label>Responsável:</label>
                                                                    <span id="spanResponsavel"></span>
                                                                </div>
                                                            </div>

                                                        </div>


                                                        <!--final tentenado arrumar a tela-->
                                                    </div>

                                                    <button id="btnIncluirCliente" style="margin-left: 18px;" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalCliente" onclick="">Incluir</button>
                                                    <button id="btnAlterarCliente" style="margin-left: 18px;" type="button" class="btn btn-primary" onclick="atualiza_modal();">Alterar</button>

                                                    <button id="btnImprimir" style="margin-left: 2px;" type="button" class="btn btn-default" onclick="imprimir();" runat="server">Imprimir</button>
                                                    <button id="btnArquivarCliente" style="margin-left: 2px;" type="button" class="btn btn-default" onclick="" runat="server">Arquivar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!--FIM CLIENTE-->















                                    <!--EXIBINDO ENDERECOS - INICIO -->
                                    <div id="load_endereco"></div>
                                    <div id="pnlImpressao2">
                                        <div class="panel panel-primary" style="margin-bottom: 5px;">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">Endereço</h3>
                                            </div>
                                            <div class="panel-body">

                                                <div class="row" style="margin-top: 20px;">
                                                    <div class="col-lg-12">
                                                        <div class="table-responsive">
                                                            <table id="table-enderecos" class="table table-striped table-bordered table-hover" style="width: 100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Logradouro</th>
                                                                        <th>Bairro</th>
                                                                        <th>Complemento</th>
                                                                        <th>Número</th>
                                                                        <th>Cep</th>
                                                                        <th>UF</th>
                                                                        <th>Cidade</th>
                                                                        <th>Ações</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>

                                                </div>


                                                <div class="row">
                                                    <div class="col-sm-2 form-group" style="margin-top: 10px;">
                                                        <button id="btn_IncluirEndereco" type="button" onclick="geral.AbrirModal('modalEndereco'); geral.LimpaCamposModal('modalEndereco');" class="btn btn-primary">Incluir</button>
                                                    </div>
                                                </div>



                                            </div>
                                        </div>
                                    </div>
                                    <!--EXIBINDO ENDERECOS - FIM -->


                                    <!-- Modal Endereço - Inicio -->
                                    <div class="modal" id="modalEndereco" tabindex="-1" role="dialog" aria-labelledby="modalEnderecoLabel">
                                        <div class="modal-dialog modal-lg" role="document" style="max-width: 600px;">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="modalEnderecoLabel">Editar</h4>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="row">
                                                        <div class="col-sm-3 form-group">
                                                            <label>CEP</label>
                                                            <asp:TextBox ID="txtCep" runat="server" CssClass="form-control cep"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-5 form-group" style="margin-top: 23px;">
                                                            <button type="button" onclick="ConsultarCep();" class="btn btn-info">Consultar CEP</button>
                                                        </div>


                                                    </div>

                                                    <div class="row">

                                                        <div class="col-sm-2 form-group">
                                                            <label>UF</label>
                                                            <asp:TextBox ID="txtUF" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-6 form-group">
                                                            <label>Cidade</label>

                                                            <asp:TextBox ID="txtComarca" runat="server" CssClass="form-control"></asp:TextBox>


                                                        </div>




                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6 form-group">
                                                            <label>Logradouro</label>
                                                            <asp:TextBox ID="txtLogradouro" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                        <div class="col-sm-2 form-group">
                                                            <label>Número</label>
                                                            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>






                                                    </div>

                                                    <div class="row">

                                                        <div class="col-sm-6 form-group">
                                                            <label>Bairro</label>
                                                            <asp:TextBox ID="txtBairro" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                        <div class="col-sm-6 form-group">
                                                            <label>Complemento</label>
                                                            <asp:TextBox ID="txtComplemento" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                                                    <asp:Button Text="GRAVAR" runat="server" CssClass="btn btn-primary" ID="btnGravaEnd" OnClick="btnGravaEnd_Click" />
                                                    <input id="hidendereco" type="hidden" name="name" value="" runat="server" />
                                                    <input id="hidContato" type="hidden" name="name" value="" runat="server" />
                                                    <input id="hidMovimentacao" type="hidden" name="name" value="" runat="server" />




                                                </div>
                                            </div>

                                        </div>
                                    </div>


                                    <!-- Modal Endereço - Fim -->







                                    <div id="load_contato"></div>

                                    <div id="pnlImpressao3">
                                        <div class="panel panel-primary" style="margin-bottom: 5px;">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">Contato</h3>
                                            </div>
                                            <div class="panel-body">

                                                <div class="row" style="margin-top: 20px;">
                                                    <div class="col-lg-12">
                                                        <div class="table-responsive">
                                                            <table id="table-contato" class="table table-striped table-bordered table-hover" style="width: 100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th>DDD</th>
                                                                        <th>Número</th>
                                                                        <th>Principal</th>
                                                                        <th>Observação</th>
                                                                        <th>Ações</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-2 form-group" style="margin-top: 25px;">

                                                        <button id="btn_IncluirContato" type="button" onclick="geral.AbrirModal('modalContato'); geral.LimpaCamposModal('modalContato');" class="btn btn-primary">Incluir</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <!-- Modal Contato - Inicio -->
                                    <div class="modal" id="modalContato" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                        <div class="modal-dialog modal-sm" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="">Editar</h4>
                                                </div>
                                                <div class="modal-body">

                                                    <div class="row">
                                                        <div class="col-sm-3 form-group">
                                                            <label>DDD</label>
                                                            <asp:TextBox ID="txtDDD" runat="server" CssClass="form-control" MaxLength="2" />

                                                        </div>
                                                        <div class="col-sm-9 form-group">
                                                            <label>Telefone</label>
                                                            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control telefone" />


                                                            <label style="margin-top: 10px" class="checkbox-inline">
                                                                <asp:CheckBox ID="checkPrincipal" Text="Principal" runat="server" />

                                                            </label>
                                                        </div>


                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-12 form-group">
                                                            <label>Observações</label>


                                                            <asp:DropDownList ID="obs_contato" runat="server" CssClass="form-control">
                                                                <asp:ListItem Text="Selecione..." />
                                                            </asp:DropDownList>

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                                                    <asp:Button Text="GRAVAR" runat="server" CssClass="btn btn-primary" ID="btnGravaContato" OnClick="btnGravaContato_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Modal Contato - Fim -->






                                    <div id="load_movimentacao"></div>
                                    <div id="pnlImpressao4">
                                        <div class="panel panel-primary" style="margin-bottom: 5px;">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">Movimentações</h3>
                                            </div>
                                            <div class="panel-body">

                                                <div class="row" style="margin-top: 20px;">
                                                    <div class="col-lg-12">
                                                        <div class="table-responsive">
                                                            <table id="table-movimentacao" class="table table-striped table-bordered table-hover" style="width: 100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Tipo</th>
                                                                        <th>Texto</th>
                                                                        <th>Data</th>
                                                                        <th>Responsável</th>
                                                                        <th>Data cad.</th>
                                                                        <th>Ações</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-2 form-group" style="margin-top: 25px;">

                                                        <button id="btn_IncluirMovimentacao" type="button" onclick="geral.AbrirModal('modalMovimentacao'); geral.LimpaCamposModal('modalMovimentacao'); dataAtualFormatada();" class="btn btn-primary">Incluir</button>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <!-- Modal Movimentacao - Inicio -->
                                    <div class="modal" id="modalMovimentacao" tabindex="-1" role="dialog" aria-labelledby="modalMovmentacaoLabel">
                                        <div class="modal-dialog modal-lg" role="document" style="max-width: 550px;">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="modalMovimentacaoLabel">Incluir movimentação</h4>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="row">
                                                        <div class="col-sm-9 form-group">
                                                            <label>Tipo Movimentação</label>

                                                            <asp:DropDownList ID="ddlTipoMovimentacao" runat="server" CssClass="form-control">
                                                                <asp:ListItem Text="Selecione..." />
                                                            </asp:DropDownList>


                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label>Data</label>
                                                            <asp:TextBox ID="txtDataMovimentacao" runat="server" CssClass="form-control date"></asp:TextBox>

                                                        </div>


                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-12 form-group">
                                                            <label>Texto</label>
                                                            <br />

                                                            <asp:TextBox ID="txtTextoMovimentacao" runat="server" Height="72px" TextMode="MultiLine" Width="100%" />



                                                        </div>

                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                                                        <asp:Button ID="btnGravaMovimentacao" runat="server" class="btn btn-primary" Text="GRAVAR" OnClick="btnGravaMovimentacao_Click" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <!-- Modal Movimentacao - Fim -->



                                    </div>


                                    <!--fechar antes desse mamolengo->
                                </div>
                            </div>
                            <!--->




                                    <!--fmendes: já cadastradas-->




                                    <!-- /.panel-body -->
                                </div>
                                <!-- /.panel -->
                            </div>
                            <!-- /.col-lg-12 -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /#page-wrapper -->
                </div>
            </div>

            <input id="hidcliente" type="hidden" name="name" value="" runat="server" />
        </div>
    </div>
    <script>

        var gId = null;
        var acao = '';
        var obj;

        $(document).ready(function () {


            // NB:
            document.getElementById("mspanNB").onclick = function () {
                document.execCommand('copy');
            }

            document.getElementById("mspanNB").addEventListener('copy', function (e) {

                e.preventDefault();
                if (e.clipboardData) {
                    e.clipboardData.setData('text/plain', geral.RemoverPontos("mspanNB"));
                } else if (window.clipboardData) {
                    window.clipboardData.setData('Text', geral.RemoverPontos("mspanNB"));
                }

            });

            // CPF:

            document.getElementById("mspanCPF").onclick = function () {
                document.execCommand('copy');
            }

            document.getElementById("mspanCPF").addEventListener('copy', function (e) {

                e.preventDefault();
                if (e.clipboardData) {
                    e.clipboardData.setData('text/plain', geral.RemoverPontos("mspanCPF"));
                } else if (window.clipboardData) {
                    window.clipboardData.setData('Text', geral.RemoverPontos("mspanCPF"));
                }

            });




            // cliente
            geral.CarregaCombo('aps_origem', 'ContentPlaceHolder1_mspanAps');
            geral.CarregaCombo('status_cli', 'mspanStatus');
            geral.CarregaCombo('user', 'ContentPlaceHolder1_mspanResponsavel');
            geral.CarregaCombo('motivo_cli', 'mspanMotivo');
            geral.CarregaCombo('especie', 'ContentPlaceHolder1_mspanEspecie');
            geral.CarregaCombo('situacao_benficio_cli', 'mspanSituacaoBeneficio');
            //geral.CarregaCombo('tipo_cli', 'mspanTipo');
            geral.CarregaCombo('status_pasta', 'mspanStatusPasta');
            geral.CarregaCombo('obs_contato', 'ContentPlaceHolder1_obs_contato');
            geral.CarregaCombo('tipo_mov', 'ContentPlaceHolder1_ddlTipoMovimentacao');


            // endereco
            //carregaCombo('cidade', 'ContentPlaceHolder1_ddl_cidade');
            //carregaCombo('uf', 'ContentPlaceHolder1_ddl_uf');
            //carregaCombo('tipo_endereco', 'dll_tipo');


            // preenche combos

            obj = geral.GetObjFromWebStorage('_obj');

           


            //obj = localStorage.getItem('_obj');
            // if (!obj) return false;

            if (!obj) {
                //eh inclusao
                $('#div_cliente').hide();
                $('#btnIncluirCliente').show();
                $('#btnAlterarCliente').hide();
                $("#btnGravaCliente").attr("onclick", "inserir_cliente()");
                $("#mspanNB").prop('readonly', false);
                $('#ContentPlaceHolder1_mspanEspecie option:not(:selected)').prop('disabled', true);
                acao = 'ins';
            }
            else {
                //alteração
                $('#div_cliente').show(); //  é a div que mostra os dados do cliente na pagina 
                $('#btnIncluirCliente').hide();
                $('#btnAlterarCliente').show();
                $("#btnGravaCliente").attr("onclick", "alterar_cliente()");
                $("#mspanNB").prop('readonly', true);

                acao = 'alt';

                gId = obj.id;


                // consultar dados
                consultaCliente(gId);
                consultaEndereco(gId);
                consultaContato(gId);
                consultaMovimentacao(gId);

                // seta campos como disable, que o rodrigo nao quer que muda:

                //disabled="disabled"
                //document.getElementById('mspanEspecie').disabled = true;
                //document.getElementById('mspanAps').disabled = true;

            }
        });

        function MontaCliente(id) {


            var cliente = {};

            if (id != null) {
                cliente.id = id;
            }

            try {
                cliente.nome = $('#ContentPlaceHolder1_mspanNome').val();
                cliente.nb = $('#mspanNB').val();
                cliente.data_nascimento_aux = $('#mspanDN').val();
                cliente.cpf = $('#mspanCPF').val();
                cliente.id_status = $('#mspanStatus').val() == "Selecione..." ? null : $('#mspanStatus').val();
                cliente.id_status_pasta = $('#mspanStatusPasta').val() == "Selecione..." ? null : $('#mspanStatusPasta').val();
                cliente.id_responsavel = $('#ContentPlaceHolder1_mspanResponsavel').val() == "Selecione..." ? null : $('#ContentPlaceHolder1_mspanResponsavel').val();
                //cliente.id_status_pasta = $('#mspanStatusPasta').val() == "Selecione..." ? null : $('#mspanStatusPasta').val();
                //cliente.id_tipo = $('#mspanTipo').val() == "Selecione..." ? null : $('#mspanTipo').val();
                cliente.id_motivo = $('#mspanMotivo').val() == "Selecione..." ? null : $('#mspanMotivo').val();
                cliente.der_aux = $('#mspanDER').val();
                cliente.id_especie = $('#ContentPlaceHolder1_mspanEspecie').val() == "Selecione..." ? null : $('#ContentPlaceHolder1_mspanEspecie').val();
                cliente.id_aps = $('#ContentPlaceHolder1_mspanAps').val() == "Selecione..." ? null : $('#ContentPlaceHolder1_mspanAps').val();
                cliente.id_situacao_beneficio = $('#mspanSituacaoBeneficio').val() == "Selecione..." ? null : $('#mspanSituacaoBeneficio').val();
                //cliente.id_comarca = 
            }
            catch (e) {
                alert("falha ao montar cliente, motivo: " + e.toString())
            }



            return cliente;


        }

        function inserir_cliente() {

            $("#btnGravaCliente").addClass('disabled');


            var cliente = MontaCliente(null);

            // exemplo de data "{ endereco : " + JSON.stringify(endereco) + "}",
            $.ajax({
                async: true,   // this will solve the problem
                type: "POST",
                url: "cadCliente.aspx/inserir_cliente",
                data: "{ cliente : " + JSON.stringify(cliente) + "}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (!isNaN(data.d)) {

                        alert('Inserido com sucesso!');
                        $("#modalCliente").modal('hide');


                        var obj = {
                            id: data.d
                        };

                        geral.SetObjWebStorage('_obj', obj);
                        //obj = JSON.stringify(obj);
                        //obj = btoa(obj);
                        //localStorage.setItem('_obj', obj);

                        //window.location.href = 'cadCliente.aspx';

                        $('#div_cliente').show();
                        $('#btnIncluirCliente').hide();
                        $('#btnAlterarCliente').show();
                        $("#btnGravaCliente").attr("onclick", "alterar_cliente()");
                        $("#btnGravaCliente").removeClass('disabled');



                        consultaCliente(data.d);
                    }




                },
                error: function (result) {
                    alert("Falha ao tentar inserir, motivo: " + result.toString());
                    $("#btnGravaCliente").attr('class', 'btn btn-primary');
                }
            });
        }

        function alterar_cliente() {

            $("#btnGravaCliente").addClass('disabled');

            // CAPTURANDO VALOR DA STORAGE:
            var obj = geral.GetObjFromWebStorage('_obj');
            gId = obj.id;

            var cliente = MontaCliente(gId);

            $.ajax({
                async: true,   // this will solve the problem
                type: "POST",
                url: "cadCliente.aspx/alterar_cliente",
                data: "{ cliente : " + JSON.stringify(cliente) + "}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    alert("Alterado com sucesso!");
                    $("#modalCliente").modal('hide');
                    $("#btnGravaCliente").removeClass('disabled');
                    consultaCliente(data.d);


                },
                error: function (result) {
                    alert("Falha ao tentar editar");
                    $("#btnGravaCliente").attr('class', 'btn btn-primary');
                }
            });

        }

        function consultaCliente(id) {

            $("#load_cliente").append("<img src=\"imgs/preloader.gif\" />");

            var retorno = null;
            $.getJSON('requests.aspx?objeto=cli_id&id= ' + id, function (dados) {

                if (dados.length > 0) {
                    retorno = dados;



                    document.getElementById("spanNome").innerText = retorno[0].nome;
                    document.getElementById("spanNB").innerText = retorno[0].nb;
                    document.getElementById("spanDN").innerText = retorno[0].data_nascimento == null ? '' : retorno[0].data_nascimento.toString() + " (Idade: " + idade(retorno[0].data_nascimento) + ")";
                    document.getElementById("spanCPF").innerText = retorno[0].cpf;
                    document.getElementById("spanStatus").innerText = retorno[0].status;
                    document.getElementById("spanStatusPasta").innerText = retorno[0].status_pasta;
                    document.getElementById("spanResponsavel").innerText = retorno[0].responsavel;
                    document.getElementById("spanTipo").innerText = retorno[0].tipo;
                    document.getElementById("spanMotivo").innerText = retorno[0].motivo;
                    document.getElementById("spanDER").innerText = retorno[0].der;
                    document.getElementById("spanAps").innerText = retorno[0].aps;
                    document.getElementById("spanEspecie").innerText = retorno[0].especie;
                    document.getElementById("spanSituacaoBeneficio").innerText = retorno[0].situacao_beneficio;
                    $("#load_cliente").html("");

                } else {
                    retorno = false;
                }
            });
        }

        function consultaEndereco(id) {
            $("#load_endereco").append("<img src=\"imgs/preloader.gif\" />");
            $.getJSON('requests.aspx?objeto=endereco&id= ' + id, function (dados) {
                if (dados.length > 0) {
                    PopulaEndereco(dados);

                }
            });

            $("#load_endereco").html("");
        }

        function consultaContato(id) {
            $("#load_contato").append("<img src=\"imgs/preloader.gif\" />");
            $.getJSON('requests.aspx?objeto=contato&id= ' + id, function (dados) {
                if (dados.length > 0) {
                    PopulaContato(dados);

                }
            });

            $("#load_contato").html("");
        }

        function consultaMovimentacao(id) {
            $("#load_movimentacao").append("<img src=\"imgs/preloader.gif\" />");
            $.getJSON('requests.aspx?objeto=movimentacao&id= ' + id, function (dados) {
                if (dados.length > 0) {
                    PopulaMovimentacao(dados);

                }
            });

            $("#load_movimentacao").html("");
        }

        function idade(dtniver) {

            if (dtniver.indexOf("/") > -1) {
                dtniver = dtniver.split("/");

                var ano_aniversario = dtniver[2];
                var mes_aniversario = dtniver[1];
                var dia_aniversario = dtniver[0];

                var d = new Date,
                    ano_atual = d.getFullYear(),
                    mes_atual = d.getMonth() + 1,
                    dia_atual = d.getDate(),

                    ano_aniversario = +ano_aniversario,
                    mes_aniversario = +mes_aniversario,
                    dia_aniversario = +dia_aniversario,

                    quantos_anos = ano_atual - ano_aniversario;

                if (mes_atual < mes_aniversario || mes_atual == mes_aniversario && dia_atual < dia_aniversario) {
                    quantos_anos--;
                }

                return quantos_anos < 0 ? 0 : quantos_anos;

            }


        }

        function wait() {
            setTimeout(function () { }, 500);
        }

        function atualiza_modal() {

            // CAPTURANDO VALOR DA STORAGE:





            var qtd1 = $("#mspanStatusPasta option").length;
            var qtd2 = $("#ContentPlaceHolder1_mspanEspecie option").length;
            var qtd3 = $("#mspanStatus option").length;
            var qtd4 = $("#ContentPlaceHolder1_mspanAps option").length;
            var qtd5 = $("#ContentPlaceHolder1_mspanResponsavel option").length;
            var qtd6 = $("#mspanMotivo option").length;
            var qtd7 = $("#mspanSituacaoBeneficio option").length;





            if (qtd1 <= 1 || qtd2 <= 1 || qtd3 <= 1 || qtd4 <= 1 || qtd5 <= 1 || qtd6 <= 1 || qtd7 <= 1) {
                //atualiza_modal();

            }

            else {
                $("#load_cliente").append("<img src=\"imgs/preloader.gif\" />");

                var _obj = geral.GetObjFromWebStorage("_obj")
                gId = _obj.id;


                geral.LimpaCamposModal('modalCliente');

                var retorno = null;
                $.getJSON('requests.aspx?objeto=cli_id_codigos&id= ' + gId, function (dados) {

                    if (dados.length > 0) {
                        retorno = dados;
                        document.getElementById("ContentPlaceHolder1_mspanNome").value = retorno[0].nome;
                        document.getElementById("mspanNB").value = retorno[0].nb;
                        document.getElementById("mspanDN").value = retorno[0].data_nascimento;
                        document.getElementById("mspanCPF").value = retorno[0].cpf;
                        retorno[0].id_status == null ? $("#mspanStatus option:contains('Selecione')").attr('selected', 'selected') : $("#mspanStatus").val(retorno[0].id_status);
                        retorno[0].id_status_pasta == null ? $("#mspanStatusPasta option:contains('Selecione')").attr('selected', 'selected') : $("#mspanStatusPasta").val(retorno[0].id_status_pasta);
                        retorno[0].id_responsavel == null ? $("#ContentPlaceHolder1_mspanResponsavel option:contains('Selecione')").attr('selected', 'selected') : $("#ContentPlaceHolder1_mspanResponsavel").val(retorno[0].id_responsavel);
                        //retorno[0].id_tipo == null ? $("#mspanTipo option:contains('Selecione')").attr('selected', 'selected') : $("#mspanTipo").val(retorno[0].id_tipo);
                        retorno[0].id_motivo == null ? $("#mspanMotivo option:contains('Selecione')").attr('selected', 'selected') : $("#mspanMotivo").val(retorno[0].id_motivo);
                        document.getElementById("mspanDER").value = retorno[0].der;
                        retorno[0].id_aps == null ? $("#ContentPlaceHolder1_mspanAps option:contains('Selecione')").attr('selected', 'selected') : $("#ContentPlaceHolder1_mspanAps").val(retorno[0].id_aps);
                        retorno[0].id_especie == null ? $("#ContentPlaceHolder1_mspanEspecie option:contains('Selecione')").attr('selected', 'selected') : $("#ContentPlaceHolder1_mspanEspecie").val(retorno[0].id_especie);
                        retorno[0].id_situacao_beneficio == null ? $("#mspanSituacaoBeneficio option:contains('Selecione')").attr('selected', 'selected') : $("#mspanSituacaoBeneficio").val(retorno[0].id_situacao_beneficio);
                        // Abre o modal:
                        geral.AbrirModal('modalCliente');
                        $("#load_cliente").html("");

                    } else {
                        retorno = false;
                        alert("Falha, no metodo js atualiza_modal do cliente");
                        $("#load_cliente").html("");
                    }
                });
            }
        }

        function imprimir() {


            var printContent = document.getElementById("pnlImpressao1");
            var printContent2 = document.getElementById("pnlImpressao2");
            var printContent3 = document.getElementById("pnlImpressao3");
            var printContent4 = document.getElementById("pnlImpressao4");
            var windowUrl = 'about:blank';
            var uniqueName = dataAtualFormatada();
            var windowName = 'Cliente - ' + uniqueName;
            var printWindow = window.open(windowUrl, windowName, 'left=50000,top=50000,width=0,height=0');

            var htmlToPrint = '' +
                '<style type="text/css">' +
                'table th, table td {' +
                'border:1px solid #000;' +
                'padding;0.5em;' +
                '}' +
                '</style>';


            try {

                document.getElementById("table-movimentacao_info").style.display = "none";
                document.getElementById("table-movimentacao_filter").style.display = "none";
                document.getElementById("table-movimentacao_paginate").style.display = "none";
                document.getElementById("table-movimentacao_length").style.display = "none";
                document.getElementById("btnAlterarCliente").style.display = "none";
                document.getElementById("ContentPlaceHolder1_btnArquivarCliente").style.display = "none";

                //$("#table-movimentacao_info").remove();
                //$("#table-movimentacao_filter").remove();
                //$("#table-movimentacao_paginate").remove();
                //$("#table-movimentacao_length").remove();
                //$("#btnAlterarCliente").remove();
                //$("#ContentPlaceHolder1_btnArquivarCliente").remove();



            } catch (e) {

            }

            try {
                document.getElementById("table-enderecos_info").style.display = "none";
                document.getElementById("table-enderecos_filter").style.display = "none";
                document.getElementById("table-enderecos_paginate").style.display = "none";
                document.getElementById("table-enderecos_length").style.display = "none";

                //$("#table-enderecos_info").remove();
                //$("#table-enderecos_filter").remove();
                //$("#table-enderecos_paginate").remove();
                //$("#table-enderecos_length").remove();

            } catch (e) {

            }

            try {

                document.getElementById("table-contato_info").style.display = "none";
                document.getElementById("table-contato_filter").style.display = "none";
                document.getElementById("table-contato_paginate").style.display = "none";
                document.getElementById("table-contato_length").style.display = "none";


                //$("#table-contato_info").remove();
                //$("#table-contato_filter").remove();
                //$("#table-contato_paginate").remove();
                //$("#table-contato_length").remove();

            } catch (e) {

            }

            try {
                document.getElementById("btn_IncluirMovimentacao").style.display = "none";
                document.getElementById("btn_IncluirEndereco").style.display = "none";
                document.getElementById("btn_IncluirContato").style.display = "none";
                document.getElementById("ContentPlaceHolder1_btnImprimir").style.display = "none";
                document.getElementById("ContentPlaceHolder1_btnArquivarCliente").style.display = "none";

                //$("#btn_IncluirMovimentacao").remove();
                //$("#btn_IncluirEndereco").remove();
                //$("#btn_IncluirContato").remove();
                //$("#ContentPlaceHolder1_btnImprimir").remove();
                //$("#ContentPlaceHolder1_btnImprimir").remove();

                //document.getElementById("ContentPlaceHolder1_btnArquivarCliente").style.visibility = "visible";



            } catch (e) {

            }





            printWindow.document.write(htmlToPrint += printContent.outerHTML + printContent2.outerHTML + printContent3.outerHTML + printContent4.outerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();




            try {

                document.getElementById("table-movimentacao_info").style.display = "";
                document.getElementById("table-movimentacao_filter").style.display = "";
                document.getElementById("table-movimentacao_paginate").style.display = "";
                document.getElementById("table-movimentacao_length").style.display = "";
                document.getElementById("btnAlterarCliente").style.display = "";
                document.getElementById("ContentPlaceHolder1_btnArquivarCliente").style.display = "";

                //$("#table-movimentacao_info").remove();
                //$("#table-movimentacao_filter").remove();
                //$("#table-movimentacao_paginate").remove();
                //$("#table-movimentacao_length").remove();
                //$("#btnAlterarCliente").remove();
                //$("#ContentPlaceHolder1_btnArquivarCliente").remove();



            } catch (e) {

            }

            try {
                document.getElementById("table-enderecos_info").style.display = "";
                document.getElementById("table-enderecos_filter").style.display = "";
                document.getElementById("table-enderecos_paginate").style.display = "";
                document.getElementById("table-enderecos_length").style.display = "";

                //$("#table-enderecos_info").remove();
                //$("#table-enderecos_filter").remove();
                //$("#table-enderecos_paginate").remove();
                //$("#table-enderecos_length").remove();

            } catch (e) {

            }

            try {

                document.getElementById("table-contato_info").style.display = "";
                document.getElementById("table-contato_filter").style.display = "";
                document.getElementById("table-contato_paginate").style.display = "";
                document.getElementById("table-contato_length").style.display = "";


                //$("#table-contato_info").remove();
                //$("#table-contato_filter").remove();
                //$("#table-contato_paginate").remove();
                //$("#table-contato_length").remove();

            } catch (e) {

            }

            try {
                document.getElementById("btn_IncluirMovimentacao").style.display = "";
                document.getElementById("btn_IncluirEndereco").style.display = "";
                document.getElementById("btn_IncluirContato").style.display = "";
                document.getElementById("ContentPlaceHolder1_btnImprimir").style.display = "";
                document.getElementById("ContentPlaceHolder1_btnArquivarCliente").style.display = "";

                //$("#btn_IncluirMovimentacao").remove();
                //$("#btn_IncluirEndereco").remove();
                //$("#btn_IncluirContato").remove();
                //$("#ContentPlaceHolder1_btnImprimir").remove();
                //$("#ContentPlaceHolder1_btnImprimir").remove();

                //document.getElementById("ContentPlaceHolder1_btnArquivarCliente").style.visibility = "visible";



            } catch (e) {

            }




        }

        function ConsultaIdEndereco(id) {



            // Limpas campos do modal:
            geral.LimpaCamposModal('modalEndereco');


            // Consulta id do que o cara quer editar e preenche modal com as informações

            $.getJSON('requests.aspx?objeto=endereco_id&id= ' + id, function (dados) {

                if (dados.length > 0) {
                    dados[0].id_comarca == null ? $("#ContentPlaceHolder1_ddl_cidade option:contains('Selecione')").attr('selected', 'selected') : $("#ContentPlaceHolder1_ddl_cidade").val(dados[0].id_comarca);
                    // uf: dados[0].id_comarca == null ? $("#ddl_cidade option:contains('Selecione')").attr('selected', 'selected') : $("#ddl_cidade").val(retorno[0].id_comarca);
                    document.getElementById("ContentPlaceHolder1_txtLogradouro").value = dados[0].logradouro;
                    document.getElementById("ContentPlaceHolder1_txtBairro").value = dados[0].bairro;
                    document.getElementById("ContentPlaceHolder1_txtComplemento").value = dados[0].complemento;
                    document.getElementById("ContentPlaceHolder1_txtNumero").value = dados[0].numero;
                    document.getElementById("ContentPlaceHolder1_txtCep").value = dados[0].cep;
                    document.getElementById("ContentPlaceHolder1_txtUF").value = dados[0].uf;
                    document.getElementById("ContentPlaceHolder1_txtComarca").value = dados[0].comarca;
                    document.getElementById("ContentPlaceHolder1_hidendereco").value = dados[0].id;

                    // Abre o modal:
                    geral.AbrirModal('modalEndereco');
                }
                else {

                    alert("Falha, no metodo js ConsultaIdEndereco, id: " + id.toString());
                }

            });


        }

        function ConsultaIdContato(id) {

            // Limpas campos do modal:
            geral.LimpaCamposModal('modalContato');

            var retorno = null;
            $.getJSON('requests.aspx?objeto=contato_id&id= ' + id, function (dados) {

                if (dados.length > 0) {
                    document.getElementById("ContentPlaceHolder1_txtDDD").value = dados[0].ddd;
                    document.getElementById("ContentPlaceHolder1_txtTelefone").value = dados[0].telefone;
                    document.getElementById("ContentPlaceHolder1_hidContato").value = dados[0].id;
                    dados[0].id_obs == null ? $("#ContentPlaceHolder1_obs_contato option:contains('Selecione')").attr('selected', 'selected') : $("#ContentPlaceHolder1_obs_contato").val(dados[0].id_obs);


                    var principal = dados[0].principal;

                    if (principal == 1) {
                        document.getElementById("ContentPlaceHolder1_checkPrincipal").checked = true;
                    }
                    else {
                        document.getElementById("ContentPlaceHolder1_checkPrincipal").checked = false;
                    }


                    // Abre o modal:
                    geral.AbrirModal('modalContato');


                }
                else {
                    alert("Falha, no metodo js ConsultaIdContato, id: " + id.toString());
                }

            });


        }

        function ConsultaIdMovimentacao(id) {

            // Limpas campos do modal:
            geral.LimpaCamposModal('modalMovimentacao');

            var retorno = null;
            $.getJSON('requests.aspx?objeto=movimentacao_id&id= ' + id, function (dados) {

                if (dados.length > 0) {

                    //ContentPlaceHolder1_ddlTipoMovimentacao
                    dados[0].id_tipo == null ? $("#ContentPlaceHolder1_ddlTipoMovimentacao option:contains('Selecione')").attr('selected', 'selected') : $("#ContentPlaceHolder1_ddlTipoMovimentacao").val(dados[0].id_tipo);
                    document.getElementById("ContentPlaceHolder1_txtDataMovimentacao").value = dados[0].data;
                    document.getElementById("ContentPlaceHolder1_txtTextoMovimentacao").value = dados[0].texto;
                    document.getElementById("ContentPlaceHolder1_hidMovimentacao").value = dados[0].id;

                    // Abre o modal:
                    geral.AbrirModal('modalMovimentacao');

                }
                else {
                    alert("Falha, no metodo js ConsultaIdMovimentacao, id: " + id.toString());
                }

            });


        }

        function PopulaEndereco(dados) {


            var oTable = $('#table-enderecos').DataTable({
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

                    { "data": "logradouro" },
                    { "data": "bairro" },
                    { "data": "complemento" },
                    { "data": "numero" },
                    { "data": "cep" },
                    { "data": "uf" },
                    { "data": "comarca" },
                    { "data": "buttons" }



                ]

            });

        }

        function PopulaContato(dados) {


            var oTable = $('#table-contato').DataTable({
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

                    { "data": "ddd" },
                    { "data": "telefone" },
                    { "data": "principal" },
                    { "data": "obs" },
                    { "data": "buttons" }


                ]

            });

        }

        function PopulaMovimentacao(dados) {


            var oTable = $('#table-movimentacao').DataTable({
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

                    { "data": "tipo" },
                    { "data": "texto" },
                    { "data": "data" },
                    { "data": "nome" },
                    { "data": "datacad" },
                    { "data": "buttons" }
                ],

                columnDefs: [
                    { width: 100, targets: 5 }
                ]

            });

        }

        function limpa_formulario_cep() {
            // Limpa valores do formulário de cep.
            $("#ContentPlaceHolder1_txtLogradouro").val("");
            $("#ContentPlaceHolder1_txtBairro").val("");
            $("#ContentPlaceHolder1_txtComplemento").val("");
            $("#ContentPlaceHolder1_txtComarca").val("");
            $("#ContentPlaceHolder1_txtUF").val("");
        }

        function testefocus() {
            alert("it works fine!!");
        }

        function ConsultarCep() {
            var cep = $("#ContentPlaceHolder1_txtCep").val().replace(/\D/g, '');

            if (cep != "") {

                //Expressão regular para validar o CEP.
                var validacep = /^[0-9]{8}$/;

                //Valida o formato do CEP.
                if (validacep.test(cep)) {

                    $("#ContentPlaceHolder1_txtLogradouro").val("...");
                    $("#ContentPlaceHolder1_txtBairro").val("...");
                    $("#ContentPlaceHolder1_txtComarca").val("...");
                    $("#ContentPlaceHolder1_txtUF").val("...");


                    //Consulta o webservice viacep.com.br/
                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/unicode/", function (dados) {
                        if (!("erro" in dados)) {
                            //Atualiza os campos com os valores da consulta.
                            $("#ContentPlaceHolder1_txtLogradouro").val(dados.logradouro);
                            $("#ContentPlaceHolder1_txtBairro").val(dados.bairro);
                            $("#ContentPlaceHolder1_txtComarca").val(dados.localidade);
                            $("#ContentPlaceHolder1_txtUF").val(dados.uf);
                        } //end if.
                        else {
                            //CEP pesquisado não foi encontrado.
                            limpa_formulario_cep();
                            alert("CEP não encontrado.");
                        }
                    });
                }
                else {
                    //cep é inválido.
                    limpa_formulario_cep();
                    alert("Formato de CEP inválido.");
                }

            } else {
                //cep é inválido.
                limpa_formulario_cep();
                alert("Formato de CEP inválido.");
            }
        }

        function ir(tipo) {

            try {
                geral.DeleteObjFromWebStorage("CliPesqExterna");
            }
            catch (ex) {

            }

            try {
                var CliPesqExterna = {};
                CliPesqExterna.nome = $('#ContentPlaceHolder1_mspanNome').val();
                CliPesqExterna.nb = $('#mspanNB').val();
                CliPesqExterna.data_nascimento = $('#mspanDN').val();
                CliPesqExterna.cpf = $('#mspanCPF').val();

                geral.SetObjWebStorage("CliPesqExterna", CliPesqExterna);

                if (tipo.indexOf("inss_beneficio") > -1) {
                    window.open("https://sipa.inss.gov.br/SipaINSS/pages/consit/consitInicio.xhtml", '_blank');
                }
                else if (tipo.indexOf("inss_concessao") > -1) {
                    window.open("https://sipa.inss.gov.br/SipaINSS/pages/concal/concalInicio.xhtml", '_blank');
                }
                else if (tipo.indexOf("inss_revisao") > -1) {
                    window.open("https://sipa.inss.gov.br/SipaINSS/pages/consit02/consit02Inicio.xhtml", '_blank');
                }
                else if (tipo.indexOf("inss_pagamento") > -1) {
                    window.open("https://sipa.inss.gov.br/SipaINSS/pages/hiscre/hiscreInicio.xhtml", '_blank');
                }
                else if (tipo.indexOf("esaj") > -1) {
                    window.open("https://esaj.tjsp.jus.br/cpopg/open.do", '_blank');
                }
                else if (tipo.indexOf("jefsp") > -1) {
                    window.open("http://www.jfsp.jus.br/jef/", '_blank');
                }



            }
            catch (ex) {
                alert("Houve alguma falha: " + ex.toString());
            }
        }

        function dataAtualFormatada() {
            var data = new Date();
            var dia = data.getDate();
            if (dia.toString().length == 1)
                dia = "0" + dia;
            var mes = data.getMonth() + 1;
            if (mes.toString().length == 1)
                mes = "0" + mes;
            var ano = data.getFullYear();
            var result = dia + "/" + mes + "/" + ano;

            document.getElementById("ContentPlaceHolder1_txtDataMovimentacao").value = result;
        }

        function ExcluirIdContato(id) {
            var r = confirm('Deseja realmente excluir?');
            if (r) {


                $.ajax({
                    async: true,
                    type: "POST",
                    url: "cadCliente.aspx/ExcluirIdContato",
                    data: "{ id : " + JSON.stringify(id) + "}",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        alert(data.d);
                        window.location.href = window.location.href;
                    },
                    error: function (result) {
                        alert("Erro: " + result);
                    }
                });
            }
        }

        function ExcluirIdEndereco(id) {
            var r = confirm('Deseja realmente excluir?');
            if (r) {


                $.ajax({
                    async: true,
                    type: "POST",
                    url: "cadCliente.aspx/ExcluirIdEndereco",
                    data: "{ id : " + JSON.stringify(id) + "}",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        alert(data.d);
                        window.location.href = window.location.href;

                    },
                    error: function (result) {
                        alert("Erro: " + result);
                    }
                });
            }
        }

        function ExcluirIdMovimentacao(id) {
            var r = confirm('Deseja realmente excluir?');
            if (r) {


                $.ajax({
                    async: true,
                    type: "POST",
                    url: "cadCliente.aspx/ExcluirIdMovimentacao",
                    data: "{ id : " + JSON.stringify(id) + "}",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        alert(data.d);
                        window.location.href = window.location.href;

                    },
                    error: function (result) {
                        alert("Erro: " + result);
                    }
                });
            }
        }

        function ConsultaEspecieViaNumBeneficio(value) {
            var DoisPrimeirosDigitos = value.substring(1, 2);

             $.ajax({
                    async: true,
                    type: "POST",
                    url: "cadCliente.aspx/ExcluirIdMovimentacao",
                    data: "{ id : " + JSON.stringify(id) + "}",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        alert(data.d);
                        window.location.href = window.location.href;

                    },
                    error: function (result) {
                        alert("Erro: " + result);
                    }
                });
        }

        function ConsultaIdEspecie(id) {

            // Limpas campos do modal:
            id = id.substring(0, 2);

            if (id == "" || id == null) {
                alert("Número benefício invalido!");
                return
            }

            $.getJSON('requests.aspx?objeto=especie_id&id= ' + id, function (dados) {

                if (dados.length > 0)
                {
                    
                    dados[0].id == null ? $("#ContentPlaceHolder1_mspanEspecie option:contains('Selecione')").attr('selected', 'selected') : $("#ContentPlaceHolder1_mspanEspecie").val(dados[0].id);
                    $('#ContentPlaceHolder1_mspanEspecie option:not(:selected)').prop('disabled', true);
                }
                else
                {
                    alert("Os dois primeiros digitos '" + id.toString() + "'  não correspondem a uma espécie existente! ");
                    // com o codigo abaixo fica dando alert toda hora e nao deixar o user corrigir.
                    //document.getElementById("mspanNB").select();
                    //return;
                }
            });
        }

    </script>
</asp:Content>


