<%@ Page Title="" Language="C#" MasterPageFile="~/Apresentacao/View.Master" AutoEventWireup="true" CodeBehind="consultaCliente.aspx.cs" Inherits="WebZSPrev.Apresentacao.consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        document.getElementById("itens_menu").getElementsByTagName("li")[0].className = 'active';



        function LimparCombosmMultFilter() {
            var selects = document.getElementById("table-classificacao").getElementsByTagName("select");
            var orderBy = "";

            for (var i = 0; i < selects.length; i++) {
                var cbo = selects[i];
                cbo.options[cbo.selectedIndex].value = 0;
            }

             orderBy = orderBy.substring(0, (orderBy.length - 1));

            var order = {
                value: orderBy
            };


            geral.SetObjWebStorage('_orderBy', order);
        }

        function OrderBy() {
            var selects = document.getElementById("table-classificacao").getElementsByTagName("select");
            var orderBy = "order by ";


            for (var i = 0; i < selects.length; i++) {
                var valueAnterior = "";
                var valueProx = "";
                var cbo = selects[i];
                var value = cbo.options[cbo.selectedIndex].value;


                // se o valor atual é um "asc" ou desc" o anterior tem q ser um campo_
                // se o valor for um campo o valor anteriro tem q ser um "desc" ou "asc" exceto se for o primeiro caso.

                // obter o valor anterior
                var iMenosUm = (i - 1);
                if (iMenosUm > -1) {
                    var cboAnterior = selects[iMenosUm];
                    valueAnterior = cboAnterior.options[cboAnterior.selectedIndex].value;

                }

                // obter o proximo valor
                var iMaisUm = (i + 1);
                if (iMaisUm <= (selects.length - 1)) {
                    var cboProx = selects[iMaisUm];
                    valueProx = cboProx.options[cboProx.selectedIndex].value;

                }

                if (i > 0) { // ou seja, se nao for o primeiro item, começa a validação o combo anterior.
                    // valor atual asc ou desc e valor anterior não é um campo.
                    if (value == "asc" || value == "desc") {
                        if (valueAnterior.indexOf(".") < 0) {
                            alert("Preencha corretamente a tabela!");
                            return false;
                        }
                    }

                    // valor atual é um campo e valor anterior não é desc e nem asc.
                    if (value.indexOf(".") >= 0) {
                        if (valueAnterior != "asc" && valueAnterior != "desc") {
                            alert("Preencha corretamente a tabela!");
                            return false;
                        }
                    }


                }
                else if (i == 0) {
                    if (value.indexOf(".") < 0) {
                        alert("Preencha corretamente a tabela!");
                        return false;
                    }
                }

                if (value.indexOf(".") >= 0) {
                    if (valueProx == 0) {
                        alert("Preencha corretamente a tabela!");
                        return false;
                    }
                }


                if (value != 0) {
                    orderBy += " " + value + " " + (value.indexOf(".") < 0 ? "," : "");
                }
            }

            orderBy = orderBy.substring(0, (orderBy.length - 1));

            var order = {
                value: orderBy
            };


            geral.SetObjWebStorage('_orderBy', order);

            return true;
        }


    </script>

    <!-- /.row -->



    <div class="row" style="margin-top: 10px;">

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
                                <input id="mspanNB" type="text" placeholder="" class="form-control nbeneficio" readonly />
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
                        <button id="btnGravaCliente" type="button" class="btn btn-primary" onclick="alterar_cliente();">Gravar</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal Cliente - Fim -->

        <!-- Modal Contato - Inicio -->
        <div class="modal" id="modalAlteracaoMassa" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="">Alterar itens selecionados</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-12 form-group">
                                <label>Status</label>
                                <select id="dropStatusMassa" class="form-control" runat="server">
                                    <option value="0">Selecione...</option>
                                </select>
                                <%--<asp:DropDownList ID="dropResponsavelMassa" runat="server" CssClass="form-control"></asp:DropDownList>--%>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 form-group">
                                <label>Responsável</label>
                                <select id="dropResponsavelMassa" class="form-control" runat="server">
                                    <option value="0">Selecione...</option>
                                </select>
                                <%--<button id="btnClassificar" runat="server" type="button" class="btn btn-primary" data-dismiss="modal" onclick="OrderBy();">Classificar</button>--%>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                        <button id="btnaltmassa" type="button" class="btn btn-primary" data-dismiss="modal" onclick="alterar_em_massa();">ALTERAR</button>

                    </div>

                </div>
            </div>
        </div>


        <!-- Modal Classificar (igual excel) -->

        <div class="modal" id="ModalClassificar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="">Classificar</h4>
                    </div>
                    <div class="modal-body">

                        <div class="row">
                            <table class="table" id="table-classificacao">
                                <thead class="thead-dark">
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Coluna</th>
                                        <th scope="col">Ordem</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th scope="row">1</th>
                                        <td>
                                            <select id="Select3" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="c.nome">Nome</option>
                                                <option value="tblEspecie.nome">Espécie</option>
                                                <option value="tblApsOrigem.nome">APS</option>
                                                <option value="c.der">DER</option>
                                                <option value="c.cpf">CPF</option>
                                                <option value=".idade">IDADE</option>
                                                <option value="tblStatus.nome">STATUS</option>
                                                <option value="tblResponsavel.nome">RESPONSÁVEL</option>
                                            </select>

                                        </td>
                                        <td>
                                            <select id="Select4" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="asc">De A a Z</option>
                                                <option value="desc">De Z a A</option>
                                            </select></td>

                                    </tr>
                                    <tr>
                                        <th scope="row">2</th>
                                        <td>
                                            <select id="Select1" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="c.nome">Nome</option>
                                                <option value="tblEspecie.nome">Espécie</option>
                                                <option value="tblApsOrigem.nome">APS</option>
                                                <option value="c.der">DER</option>
                                                <option value="c.cpf">CPF</option>
                                                <option value=".idade">IDADE</option>
                                                <option value="tblStatus.nome">STATUS</option>
                                                <option value="tblResponsavel.nome">RESPONSÁVEL</option>
                                            </select>

                                        </td>
                                        <td>
                                            <select id="Select2" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="asc">De A a Z</option>
                                                <option value="desc">De Z a A</option>
                                            </select></td>

                                    </tr>

                                    <tr>
                                        <th scope="row">3</th>
                                        <td>
                                            <select id="Select5" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="c.nome">Nome</option>
                                                <option value="tblEspecie.nome">Espécie</option>
                                                <option value="tblApsOrigem.nome">APS</option>
                                                <option value="c.der">DER</option>
                                                <option value="c.cpf">CPF</option>
                                                <option value=".idade">IDADE</option>
                                                <option value="tblStatus.nome">STATUS</option>
                                                <option value="tblResponsavel.nome">RESPONSÁVEL</option>
                                            </select>

                                        </td>
                                        <td>
                                            <select id="Select6" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="asc">De A a Z</option>
                                                <option value="desc">De Z a A</option>
                                            </select></td>

                                    </tr>

                                    <tr>
                                        <th scope="row">4</th>
                                        <td>
                                            <select id="Select7" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="c.nome">Nome</option>
                                                <option value="tblEspecie.nome">Espécie</option>
                                                <option value="tblApsOrigem.nome">APS</option>
                                                <option value="c.der">DER</option>
                                                <option value="c.cpf">CPF</option>
                                                <option value=".idade">IDADE</option>
                                                <option value="tblStatus.nome">STATUS</option>
                                                <option value="tblResponsavel.nome">RESPONSÁVEL</option>
                                            </select>

                                        </td>
                                        <td>
                                            <select id="Select8" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="asc">De A a Z</option>
                                                <option value="desc">De Z a A</option>
                                            </select></td>

                                    </tr>

                                    <tr>
                                        <th scope="row">5</th>
                                        <td>
                                            <select id="Select9" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="c.nome">Nome</option>
                                                <option value="tblEspecie.nome">Espécie</option>
                                                <option value="tblApsOrigem.nome">APS</option>
                                                <option value="c.der">DER</option>
                                                <option value="c.cpf">CPF</option>
                                                <option value=".idade">IDADE</option>
                                                <option value="tblStatus.nome">STATUS</option>
                                                <option value="tblResponsavel.nome">RESPONSÁVEL</option>
                                            </select>

                                        </td>
                                        <td>
                                            <select id="Select10" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="asc">De A a Z</option>
                                                <option value="desc">De Z a A</option>
                                            </select></td>

                                    </tr>

                                    <tr>
                                        <th scope="row">6</th>
                                        <td>
                                            <select id="Select11" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="c.nome">Nome</option>
                                                <option value="tblEspecie.nome">Espécie</option>
                                                <option value="tblApsOrigem.nome">APS</option>
                                                <option value="c.der">DER</option>
                                                <option value="c.cpf">CPF</option>
                                                <option value=".idade">IDADE</option>
                                                <option value="tblStatus.nome">STATUS</option>
                                                <option value="tblResponsavel.nome">RESPONSÁVEL</option>
                                            </select>

                                        </td>
                                        <td>
                                            <select id="Select12" class="form-control" runat="server">
                                                <option value="0">Selecione...</option>
                                                <option value="asc">De A a Z</option>
                                                <option value="desc">De Z a A</option>
                                            </select></td>

                                    </tr>
                                </tbody>
                            </table>
                        </div>

                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal" style="margin-top: 23px;">Fechar</button>
                        <asp:Button id="btnLimparMultFilter" CssClass="btn btn-primary" Style="margin-top: 24px;" runat="server" Text="Limpar" OnClientClick="LimparCombosmMultFilter();" />          
                        <asp:Button ID="btnClassificar" CssClass="btn btn-primary" Style="margin-top: 24px;" runat="server" Text="Classificar" OnClientClick="return OrderBy();"  />                        <%--<asp:Button Text="ALTERAR" runat="server" CssClass="btn btn-primary" ID="btnAlterarEmMassa" />--%>
                    </div>

                </div>
            </div>
        </div>
        <!--FIM CLASSIFICAR -->


    </div>
    <%--<asp:Button Text="Limpar Filtro" CssClass="btn btn-default" runat="server" ID="btnlimpafiltro" OnClick="btnlimpafiltro_Click" />--%>
    <!-- Modal Contato - Fim -->


    <div class="col-lg-12" style="margin-top: 10px;">
        <div class="panel panel-default">
            <div class=" panel-heading">Consulta</div>
            <div class="panel-body">
                <div class="row">

                    <div class="col-lg-2">
                        <label>APS de origem</label>
                        <asp:DropDownList ID="dropAps" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropAps_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-lg-2">

                        <label>Epécie</label>
                        <asp:DropDownList ID="dropEspecie" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropEspecie_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <label>Status</label>
                        <asp:DropDownList ID="dropStatus" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropStatus_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-lg-2">
                        <label>Responsável</label>
                        <asp:DropDownList ID="dropResponsavel" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropResponsavel_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-lg-2">
                        <label></label>
                        <%--<asp:Button Text="Limpar Filtro" CssClass="btn btn-default" runat="server" ID="btnlimpafiltro" OnClick="btnlimpafiltro_Click" />--%>
                        <asp:Button ID="btnLimpaFiltros" CssClass="btn btn-default" Style="margin-top: 24px;" runat="server" Text="Limpar Filtros" OnClientClick="LimparCombosmMultFilter();" OnClick="btnLimpaFiltros_Click" />
                    </div>
                </div>

                <div style="margin: 10px;" id="load_cliente"></div>
                <div class="row" style="margin-top: 20px;">
                    <div class="col-lg-12">
                        <div class="table-responsive">
                            <table style="width: 100%;" id="table-cliente" class="table table-striped table-bordered table-hover">
                                <thead style="font-size: 12px;">
                                    <tr>
                                        <th>Nome</th>
                                        <th>NB</th>
                                        <th>Espécie</th>
                                        <th>APS</th>
                                        <th>DER</th>
                                        <th>CPF</th>
                                        <th>Idade</th>
                                        <th>Status</th>
                                        <th>Responsável</th>
                                        <th>Ação</th>

                                    </tr>
                                </thead>
                                <tbody style="font-size: 12px;">
                                </tbody>
                            </table>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- /.panel -->
    </div>
    <!-- /.col-lg-12 -->

    <input id="hiduser" type="hidden" name="name" value="" runat="server" />
    <input id="hid_ordenar" type="hidden" name="name" value="" runat="server" myvalue="" enableviewstate="true" />




    <script>


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

                if (document.getElementById("mspanCPF").innerText.length > 2) // achei q 2 era um bom numero para ver se é vazio
                {
                    document.execCommand('copy');
                }
            }

            document.getElementById("mspanCPF").addEventListener('copy', function (e) {

                e.preventDefault();
                if (e.clipboardData) {
                    e.clipboardData.setData('text/plain', geral.RemoverPontos("mspanCPF"));
                } else if (window.clipboardData) {
                    window.clipboardData.setData('Text', geral.RemoverPontos("mspanCPF"));
                }

            });



            // alteração 17/04/2018:
            /*
            var tds = document.getElementsByTagName("td");
            for (var i = 0; i < tds.length; i++) {

                tds[i].onclick = function () { document.execCommand("copy"); }


                tds[i].addEventListener('copy', function (e) {

                    var r = e.target;
                    r = r.innerText.replace(/\./g, "").replace(/\//g, "").replace(/-/g, "");



                    e.preventDefault();
                    if (e.clipboardData) {
                        e.clipboardData.setData('text/plain', r);
                    } else if (window.clipboardData) {
                        window.clipboardData.setData('Text', r);
                    }


                });
            }

            */


            var pressedCtrl = false;
            $(document).keyup(function (e) {
                if (e.which == 17)
                    pressedCtrl = false;
            })

            $(document).keydown(function (e) {
                if (e.which == 17)
                    pressedCtrl = true;

                if (e.which == 81 && pressedCtrl == true) {
                    //Aqui vai o código e chamadas de funções para o ctrl+s
                    $("#modalAlteracaoMassa").modal('show');
                }
            });



            jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                "date-br-pre": function (a) {
                    if (a == null || a == "") {
                        return 0;
                    }
                    var brDatea = a.split('/');
                    return (brDatea[2] + brDatea[1] + brDatea[0]) * 1;
                },

                "date-br-asc": function (a, b) {
                    return ((a < b) ? -1 : ((a > b) ? 1 : 0));
                },

                "date-br-desc": function (a, b) {
                    return ((a < b) ? 1 : ((a > b) ? -1 : 0));
                }
            });


            // get values dropdown:
            var _apsVal;
            var _especieVal;
            var _statusVal;
            var _respVal;
            var _orderBy = 0;

            _apsVal = document.getElementById("ContentPlaceHolder1_dropAps").value;
            _especieVal = document.getElementById("ContentPlaceHolder1_dropEspecie").value;
            _statusVal = document.getElementById("ContentPlaceHolder1_dropStatus").value;

            var temResp = false;
            try {
                _respVal = document.getElementById("ContentPlaceHolder1_dropResponsavel").value;
                temResp = true;
            } catch (e) {
                temResp = false;
            }

            // order by.:

            try {
                var _ret = geral.GetObjFromWebStorage('_orderBy');
                _orderBy = _ret.value.toString();
                geral.DeleteObjFromWebStorage('_orderBy');
            }
            catch (e) {

            }



            //var obj = geral.GetObjFromWebStorage('_obj');
            //document.getElementById("ContentPlaceHolder1_hidcliente").value = obj.id.toString();

            var strParametros = "_apsVal=" + _apsVal + "&_especieVal=" + _especieVal + "&_statusVal=" + _statusVal + (temResp ? ("&_respVal=" + _respVal) : "&_respVal=0") + "&_orderBy=" + _orderBy;

            //alert(strParametros);


            var tabelaCliente = $('#table-cliente').DataTable({
                stateSave: true,
                responsive: true,
                "processing": true,
                "pageLength": 100,
                sServerMethod: 'GET',
                dom: 'Bfrtip',
                select: true,
                //"dom": 'flipt'
                //data: dados,

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

                buttons: [
                    {
                        text: 'Selecionar todos',
                        action: function () {
                            tabelaCliente.rows().select();
                        }
                    },
                    {
                        text: 'Selecionar nenhum',
                        action: function () {
                            tabelaCliente.rows().deselect();
                        }
                    },
                    {
                        text: 'Alterar Selecionados',
                        action: function () {
                            $("#modalAlteracaoMassa").modal('show');
                        }
                    },
                    {
                        text: 'Classificar',
                        action: function () {
                            $("#ModalClassificar").modal('show');
                        }
                    }
                ],

                columns: [

                    { "data": "nome" },
                    { "data": "nb" },
                    { "data": "especie" },
                    { "data": "aps" },
                    { "data": "der" },
                    { "data": "cpf" },
                    { "data": "idade" },
                    { "data": "status" },
                    { "data": "responsavel" },
                    { "data": "buttons" }
                ],

                columnDefs: [
                    { width: 200, targets: 0 },
                    { type: 'date-br', targets: [4, 5] }
                ],
                bServerSide: true,
                sAjaxSource: 'ClientesDataHandler.ashx?' + strParametros
            });



            // cliente
            geral.CarregaCombo('aps_origem', 'ContentPlaceHolder1_mspanAps');
            geral.CarregaCombo('status_cli', 'mspanStatus');
            geral.CarregaCombo('user', 'ContentPlaceHolder1_mspanResponsavel');
            geral.CarregaCombo('motivo_cli', 'mspanMotivo');
            geral.CarregaCombo('especie', 'ContentPlaceHolder1_mspanEspecie');
            geral.CarregaCombo('situacao_benficio_cli', 'mspanSituacaoBeneficio');
            geral.CarregaCombo('status_pasta', 'mspanStatusPasta');
            geral.CarregaCombo('obs_contato', 'ContentPlaceHolder1_obs_contato');
            geral.CarregaCombo('tipo_mov', 'ContentPlaceHolder1_ddlTipoMovimentacao');
            //geral.CarregaCombo('tipo_cli', 'mspanTipo');


            // Combos da alteração em massa:

            geral.CarregaCombo('status_cli', 'ContentPlaceHolder1_dropStatusMassa');
            geral.CarregaCombo('user', 'ContentPlaceHolder1_dropResponsavelMassa');




            // timer out verificacao se tem algo selecionado na pagina...:


            ligarTimer();
        });

        var timmer = null;
        function ligarTimer() {
            var timmer = setInterval(verifica_selecionados, 100);

        }









        var botao_criado = false;
        function verifica_selecionados() {
            var selecionados = obterSelecionados();

            var adm = false;
            try {
                document.getElementById("div_adm").innerText;
                adm = true;
            }
            catch (ex) {
                adm = false;
            }

            //alert("registros selecionados1: " + selecionados);


            if (selecionados != "" && botao_criado == false && (adm)) {
                criar_botao();
                botao_criado = true;
            }
            else if (selecionados == "" && botao_criado == true) {
                try {
                    document.getElementById("btnConsultaInfoqualy").remove();
                    botao_criado = false;
                }
                catch (ex) {

                }

            }

        }

        function criar_botao() {

            var button = document.createElement("Button");
            button.innerHTML = "Consultar WebService";
            button.style = "top:0;right:0;position:fixed;";
            button.className = "btn btn-primary";
            button.id = "btnConsultaInfoqualy";

            button.onclick = function () {

                var ids = obterSelecionados();






                $.ajax({
                    async: true,   // this will solve the problem
                    type: "POST",
                    url: "consultaCliente.aspx/consultar_web_service",
                    data: "{ ids : '" + ids + "'}",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        alert(data.d);
                        window.location.href = window.location.href;

                        //$("#modalCliente").modal('hide');
                        //$("#btnGravaCliente").removeClass('disabled');
                        //consultaCliente(data.d);
                        //document.getElementById("form1").submit();


                    },
                    error: function (result) {
                        alert("Falha.: " + result);

                        //alert("Falha ao tentar editar");
                        //$("#btnGravaCliente").attr('class', 'btn btn-primary');
                    }
                });


            }

            document.body.appendChild(button);


            /*
            var imagem = document.createElement("img");
            imagem.setAttribute('src', "imgs/robot-3.png");
            imagem.style = "top:0;right:0;position:fixed;";
            imagem.id = "btnConsultaInfoqualy";
            imagem.style.width = "5%";
            imagem.style.height = "10%";

            document.body.appendChild(imagem);
            */
        }



        //var cliente = geral.GetObjFromWebStorage("_obj");


        //ConsultaCliente();


        //document.getElementById("ContentPlaceHolder1_hidcliente").value = cliente.id.toString();

        //ConsultaCompromisso(cliente.id);

        //geral.CarregaCombo('tipo_comp', 'ContentPlaceHolder1_ddlTipoCompromisso');
        //geral.CarregaCombo('user', 'ContentPlaceHolder1_ddlResponsavel');


        var G_ID;
        function alterar(id) {

            var obj = {
                id: id
            };

            geral.SetObjWebStorage('_obj', obj);
            window.location.href = 'cadCliente.aspx';
        }

        // funcoes novas (alterar principais dados do cliente na propria tela de consulta):

        function alterar_cliente() {

            var cliente = MontaCliente(G_ID);

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
                    //consultaCliente(data.d);
                    document.getElementById("form1").submit();


                },
                error: function (result) {
                    alert("Falha ao tentar editar");
                    $("#btnGravaCliente").attr('class', 'btn btn-primary');
                }
            });

        }

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

        function alterar_aqui(id) {





            // inicio teste se todos os combos foram carregados.
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
                geral.LimpaCamposModal('modalCliente');

                G_ID = id;
                var retorno = null;
                $.getJSON('requests.aspx?objeto=cli_id_codigos&id= ' + id, function (dados) {

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
                        $("#modalCliente").modal('show');
                        //geral.AbrirModal('modalCliente');
                        $("#load_cliente").html("");

                    } else {
                        retorno = false;
                        alert("Falha, no metodo js atualiza_modal do cliente");
                        $("#load_cliente").html("");
                    }
                });
            }

        }

        // fim das novas atualizações.

        function ConsultaCliente() {

            // Limpas campos do modal:
            // geral.LimpaCamposModal('modalCompromisso');


            //$("#load_cliente").append("<img src=\"imgs/preloader.gif\" />");
            //$.getJSON('requests.aspx?objeto=cli', function (dados) {

            //    if (dados.length > 0) {
            //        PopulaCliente(dados);
            //        $("#load_cliente").html("");

            //    }
            //});




            // Abre o modal:
            // geral.AbrirModal('modalCompromisso');
        }


        function PopulaCliente(dados) {

            jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                "date-br-pre": function (a) {
                    if (a == null || a == "") {
                        return 0;
                    }
                    var brDatea = a.split('/');
                    return (brDatea[2] + brDatea[1] + brDatea[0]) * 1;
                },

                "date-br-asc": function (a, b) {
                    return ((a < b) ? -1 : ((a > b) ? 1 : 0));
                },

                "date-br-desc": function (a, b) {
                    return ((a < b) ? 1 : ((a > b) ? -1 : 0));
                }
            });





            var oTable = $('#table-cliente').DataTable({
                //stateSave: true,
                responsive: true,
                "pageLength": 100,
                //"dom": 'flipt'
                //data: dados,

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

                    { "data": "nome" },
                    { "data": "nb" },
                    { "data": "especie" },
                    { "data": "aps" },
                    { "data": "der" },
                    { "data": "cpf" },
                    { "data": "idade" },
                    { "data": "status" },
                    { "data": "responsavel" },
                    { "data": "buttons" }
                ],

                columnDefs: [
                    { width: 200, targets: 0 },
                    { type: 'date-br', targets: [4, 5] }
                ]

            });


        }



        function obterSelecionados() {
            var selecionados = $('tr[class*="selected"] a');
            var result = "";

            try {
                for (var i = 0; i < selecionados.length; i++) {
                    var selecionado = selecionados[i];
                    result += selecionado.getAttribute("onclick").replace("alterar_aqui(", "").replace(");", "") + ",";
                }

                result = result.substr(0, (result.length - 1));

            }
            catch (erro) {

            }

            return result;
        }

        function alterar_em_massa() {

            var id_status = $('#ContentPlaceHolder1_dropStatusMassa').val() == "Selecione..." ? 0 : $('#ContentPlaceHolder1_dropStatusMassa').val();
            var id_responsavel = $('#ContentPlaceHolder1_dropResponsavelMassa').val() == "Selecione..." ? 0 : $('#ContentPlaceHolder1_dropResponsavelMassa').val();
            var id_clientes = obterSelecionados();

            var cli = {}
            cli.id_status = id_status;
            cli.id_responsavel = id_responsavel;
            cli.id_clientes = id_clientes;



            $.ajax({
                async: true,   // this will solve the problem
                type: "POST",
                url: "consultaCliente.aspx/alterar_em_massa",
                data: JSON.stringify(cli),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    alert("Alterado com sucesso!");
                    $("#modalAlteracaoMassa").modal('hide');
                    document.getElementById("form1").submit();


                },
                error: function (result) {
                    alert("Falha ao tentar editar");
                }
            });

        }









    </script>
</asp:Content>
