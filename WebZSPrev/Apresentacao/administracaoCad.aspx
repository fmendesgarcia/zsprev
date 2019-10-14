<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administracaoCad.aspx.cs" Inherits="WebZSPrev.Apresentacao.administracaoParametros" %>

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
                                            <input type="text" runat="server" name="name" value="" class="form-control" id="valor" />
                                            <br />

                                            <div class="form-group" id="div_permissoes"">
                                              
                                            </div>


                                            <br />
                                            <button id="manda" type="button" class="btn btn-primary btn-sm">INCLUIR</button>
                                            <button type="button" class="btn btn-danger btn-sm" onclick="voltar();">VOLTAR</button>
                                        </div>
                                    </div>
                                </div>
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

                var titulo = '';

                if (location.href.indexOf('id') > -1) {
                    titulo = 'Alterar: ';
                    document.getElementById('manda').innerText = 'SALVAR';
                    $("#manda").attr("onclick", "alterar()");
                }

                else {
                    titulo = 'Incluir: ';
                    document.getElementById('manda').innerText = 'INCLUIR';
                    $("#manda").attr("onclick", "inserir()");
                }



                insere_titulo_administracao('titulo-pagina', titulo);
                gera_div_permissao();

            });

            function voltar() {
                var arrObj = parametrosUrl();
                location.href = 'administracaoConsulta.aspx?item=' + arrObj[0].valor;
            }

            function gera_div_permissao() {

                var html_permissao = '  <label>Permissão:</label>  ' +
                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                        '<input type=\"radio\" name="optionsRadios" id=\"optionsRadios1\" value=\"option1\" checked=\"\">Administrador (acesso total a todas as partes do sistema). ' +
                                                    '</label>' +
                                                '</div>' +
                                                '<hr />' +
                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                        '<input type=\"radio\" name=\"optionsRadios\" id=\"optionsRadios2" value="option2">' +
                                                        'Parceiro nivel 1 (inclui edita e visualiza apenas os itens em que ele é o reponsável).' +
                                                    '</label>' +
                                                '</div>' +
                                                '<hr />' +
                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                        '<input type=\"radio\" name=\"optionsRadios\" id=\"optionsRadios3\" value=\"option3\">Parceiro nivel 2 (inclui edita e visualiza apenas os itens em que ele é o reponsável, porem, consegue visualizar itens de outros usuários).' +
                                                   '</label>' +
                                                '</div>' +
                                                '<hr />' +

                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                        '<input type=\"radio\" name=\"optionsRadios\" id=\"optionsRadios4\" value=\"option3\">Parceiro nivel 3 (inclui edita e visualiza os itens seus e dos demais usuários).' +
                                                    '</label>' +
                                                '</div>' +

                                                '<hr />' +

                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                       ' <input type=\"radio\" name=\"optionsRadios\" id="optionsRadios5" value=\"option3\">Acesso negado ao sistema.' +
                                                    '</label>' +
                                                '</div>';

                var item  = getFromUrl('item');

                if (item.indexOf('usuario') > -1)
                    $("#div_permissoes").append(html_permissao);


            }

            function getFromUrl(parametro)
            {
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
                            alert('Falha na funcao getFromUrl, motivo: ' + e.toString());
                        }
                    }
                }

                return retorno;

            }

            function parametrosUrl() {
                var objParametros = [];
                var url = location.href;
                var url_parametros = url.split('?')[1];
                var parametros = url_parametros.split(/&/g);
                for (var i = 0; i < parametros.length; i++) {

                    var valor = parametros[i].split('=');
                    var objParametro = {
                        propriedade: valor[0],
                        valor: valor[1]
                    }

                    objParametros.push(objParametro);
                }

                return objParametros;
            }

            function popupwindow(url, title, w, h, parametros) {
                var left = (screen.width / 2) - (w / 2);
                var top = (screen.height / 2) - (h / 2);
                return window.open(url + '?' + parametros, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
            }

            function inserir() {

                var item = getFromUrl('item');

                var valor = $('#valor').val();

                if (valor == null || valor == '') {
                    alert('Valor invalido!');
                    return;
                }

                var obj = {
                    valor: valor,
                    item: item
                }

                var strfy = JSON.stringify(obj);
               

                $.ajax({
                    async: true,   // this will solve the problem
                    type: "POST",
                    url: "administracaoCad.aspx/inserir",
                    data: strfy,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        alert(data.d);
                        voltar();


                        
                    },
                    error: function (result) {
                        alert("Error");
                    }
                });
            }

            function alterar() {

                var item = getFromUrl('item');
                var id = getFromUrl('id');
           
                var valor = $('#valor').val();

                if (valor == null || valor == '') {
                    alert('Valor invalido!');
                    return;
                }

                var obj = {
                    valor: valor,
                    item: item,
                    id: id
                }

                var strfy = JSON.stringify(obj);


                $.ajax({
                    async: true,   // this will solve the problem
                    type: "POST",
                    url: "administracaoCad.aspx/alterar",
                    data: strfy,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        alert(data.d);
                        voltar();

                        // your code
                    },
                    error: function (msg) {
                        alert(msg);
                    }
                });

            }

        </script>

    </form>
</body>
</html>
