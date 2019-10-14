<%@ Page Title="" Language="C#" MasterPageFile="~/Apresentacao/View.Master" AutoEventWireup="true" CodeBehind="administracaoMenu.aspx.cs" Inherits="WebZSPrev.Apresentacao.administracao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
  
        document.getElementById("itens_menu").getElementsByTagName("li")[3].className = 'active';


        function popupwindow(url, title, w, h, parametros) {
            var left = (screen.width / 2) - (w / 2);
            var top = (screen.height / 2) - (h / 2);
            return window.open(url + '?' + parametros, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }

    </script>

    <div class="row" style="margin-top: 10px;">
        <div class="col-lg-5" style="margin-top: 10px;">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Administração geral do sistema
                </div>

                <div class="panel-body">
                    <h4>Usuário</h4>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsultaUser.aspx', 'Administração', 800, 550, 'item=usuario');">USUÁRIO</button>

                    <h4>Cliente</h4>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=motivo_cli');">MOTIVO</button>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=situacao_benficio_cli');">SITUAÇÃO DO BENEFÍCIO</button>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=status_cli');">STATUS</button>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=tipo_cli');">TIPO</button>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=aps_origem');">APS DE ORIGEM</button>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=especie');">ESPÉCIE</button>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=status_pasta');">STATUS PASTA</button>
                     <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=obs_contato');">OBSERVAÇÃO CONTATO</button>


                    <h4>Documento</h4>
                    <button type="button" class="btn btn-primary btn-lg btn-block"  onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=tipo_doc');">TIPO</button>
                    <h4>Compromisso</h4>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=tipo_comp');">TIPO</button>
                    <h4>Movimentação</h4>
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="popupwindow('administracaoConsulta.aspx', 'Administração', 800, 500, 'item=tipo_mov');">TIPO</button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
