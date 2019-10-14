<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administracaoConsulta.aspx.cs" Inherits="WebZSPrev.Apresentacao.administracaoConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/metisMenu.min.css" rel="stylesheet" />
    <link href="css/sb-admin-2.css" rel="stylesheet" />
    <link href="css/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="css/dataTables.responsive.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />
</head>
<body style="margin: 15px;">
    <form id="form1" runat="server">
        <div id="wrapper">
            <div class="row" style="margin-top: 2px;">
                <div class="col-lg-12" style="margin-top: 10px;">
                    <div class="panel panel-default">
                        <div class=" panel-heading" id="titulo-pagina">Administração</div>
                        <div class="panel-body">

                            <div class="col-lg-12">
                                <div class="col-lg-6">
                                    <div class="row">
                                        <div class="row-sm-2 form-group">
                                            <button type="button" class="btn btn-primary btn-sm" onclick="
                                                redirect(this.getAttribute('code'), this);">
                                                Incluir</button>

                                        </div>
                                    </div>
                                </div>
                                <hr />
                            </div>


                            <div class="col-lg-6">


                                <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example-projeto">
                                    <thead>
                                        <tr>
                                            <th>Código</th>
                                            <th>Descrição</th>
                                            <th>Ação</th>
                                        </tr>
                                    </thead>
                                </table>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.js"></script>
        <script src="js/jquery.dataTables.min.js"></script>
        <script src="js/dataTables.bootstrap.js"></script>
        <script src="js/dataTables.responsive.js"></script>
        <script src="js/sb-admin-2.js"></script>
        <script src="js/metisMenu.min.js"></script>
        <script src="js/raphael.js"></script>
        <script src="js/script.js"></script>

        <script>

            $(document).ready(function () {

                var item = getFromUrl('item');

                insere_titulo_administracao('titulo-pagina', 'Administração: ');

                geral.consultaItem(item);
            });

            function getFromUrl(parametro) {
                var retorno = '';
                var url = location.href;
                var url_parametros = url.split('?')[1];
                var parametros = url_parametros.split(/&/g);
                for (var i = 0; i < parametros.length; i++) {

                    if (parametros[i].indexOf(parametro) > -1) {
                        try {
                            var arr = parametros[i].split('=');
                            retorno = arr[1];
                            break;

                        } catch (e) {
                            retorno = null;
                        }
                    }
                }

                return retorno;

            }

            function excluir(id) {

                var r = confirm('Deseja realmente excluir?');
                if (r) {
                    var item = getFromUrl('item');
                    var parametros = {
                        id: id,
                        item: item
                    }

                    var strParametros = JSON.stringify(parametros);

                    $.ajax({
                        async: true,   // this will solve the problem
                        type: "POST",
                        url: "administracaoCad.aspx/excluir",
                        data: strParametros,
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            alert(data.d);
                            window.location.href = window.location.href;

                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            }

            function redirect(id, obj) {

                var item = getFromUrl('item');
                var acao = null;
                acao = obj.innerText;

                if (id == null || id === 'undefined') {
                    if (item == 'usuario')
                    {
                        location.href = 'administracaoUser.aspx?item=' + item + '&acao=' + acao;
                    }
                    else {
                        location.href = 'administracaoCad.aspx?item=' + item + '&acao=' + acao;
                    }
                   
                }
                else {
                    location.href = 'administracaoCad.aspx?item=' + item + '&id=' + id + '&acao=' + acao;

                }

            }


        </script>

    </form>
</body>
</html>
