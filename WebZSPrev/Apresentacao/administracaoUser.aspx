<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administracaoUser.aspx.cs" Inherits="WebZSPrev.Apresentacao.administracaoUser1" %>


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
                                        <div class="col-sm-6 form-group">
                                            <label>Nome (completo)</label>
                                            <input id="nome" type="text" placeholder="" class="form-control"" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label>Usuario</label>
                                            <input id="usuario" type="text" placeholder="" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label>Senha</label>
                                            <input id="senha" type="text" placeholder="" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label>Email</label>
                                            <input id="email" type="text" placeholder="" class="form-control" />
                                        </div>
                                    </div>


                                    <br />

                                    <div class="form-group" id="div_permissoes">
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

                consulta();

            });

            function voltar() {
                var arrObj = parametrosUrl();
                location.href = 'administracaoConsultaUser.aspx?item=usuario';
            }

            function gera_div_permissao() {

                var html_permissao = '  <label>Permissão:</label>  ' +
                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                        '<input type=\"radio\" name="optionsRadios" id=\"optionsRadios1\" value=\"adm\" checked=\"\">Administrador (acesso total a todas as partes do sistema). ' +
                                                    '</label>' +
                                                '</div>' +
                                                '<hr />' +
                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                        '<input type=\"radio\" name=\"optionsRadios\" id=\"optionsRadios2" value="p1">' +
                                                        'Parceiro nivel 1 (inclui edita e visualiza apenas os itens em que ele é o reponsável).' +
                                                    '</label>' +
                                                '</div>' +
                                                '<hr />' +
                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                        '<input type=\"radio\" name=\"optionsRadios\" id=\"optionsRadios3\" value=\"p2\">Parceiro nivel 2 (inclui edita e visualiza apenas os itens em que ele é o reponsável, porem, consegue visualizar itens de outros usuários).' +
                                                   '</label>' +
                                                '</div>' +
                                                '<hr />' +

                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                        '<input type=\"radio\" name=\"optionsRadios\" id=\"optionsRadios4\" value=\"p3\">Parceiro nivel 3 (inclui edita e visualiza os itens seus e dos demais usuários).' +
                                                    '</label>' +
                                                '</div>' +

                                                '<hr />' +

                                                '<div class=\"radio\">' +
                                                    '<label>' +
                                                       ' <input type=\"radio\" name=\"optionsRadios\" id="optionsRadios5" value=\"acessa\">Acesso negado ao sistema.' +
                                                    '</label>' +
                                                '</div>';

                var item = getFromUrl('item');

                if (item.indexOf('usuario') > -1)
                    $("#div_permissoes").append(html_permissao);


            }

            function getFromUrl(parametro) {
                var retorno = null;
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


                var nome = $('#nome').val();
                var usuario = $('#usuario').val();
                var senha = $('#senha').val();
                var email = $('#email').val();
                var permissao = $("#form1 input[type='radio']:checked").val();

                if (nome == null || nome == '') {
                    alert('Valor invalido!');
                    $('#nome').focus();
                    return;
                }
                if (usuario == null || usuario == '') {
                    alert('Valor invalido!');
                    $('#usuario').focus();
                    return;
                }
                if (senha == null || senha == '') {
                    alert('Valor invalido!');
                    $('#senha').focus();
                    return;
                }
                if (email == null || email == '') {
                    alert('Valor invalido!');
                    $('#email').focus();
                    return;
                }

                var obj = {
                    nome: nome,
                    usuario: usuario,
                    senha: senha,
                    email: email,
                    permissao: permissao
                }

                var strfy = JSON.stringify(obj);


                $.ajax({
                    async: true,   // this will solve the problem
                    type: "POST",
                    url: "administracaoUser.aspx/inserir",
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

                var id = getFromUrl('id');
                var nome = $('#nome').val();
                var usuario = $('#usuario').val();
                var senha = $('#senha').val();
                var email = $('#email').val();
                var permissao = $("#form1 input[type='radio']:checked").val();


                if (nome == null || nome == '') {
                    alert('Valor invalido!');
                    $('#nome').focus();
                    return;
                }
                if (usuario == null || usuario == '') {
                    alert('Valor invalido!');
                    $('#usuario').focus();
                    return;
                }
                if (senha == null || senha == '') {
                    alert('Valor invalido!');
                    $('#senha').focus();
                    return;
                }
                if (email == null || email == '') {
                    alert('Valor invalido!');
                    $('#email').focus();
                    return;
                }

                var obj = {
                    id: id,
                    nome: nome,
                    usuario: usuario,
                    senha: senha,
                    email: email,
                    permissao: permissao
                }

                var strfy = JSON.stringify(obj);


                $.ajax({
                    async: true,   // this will solve the problem
                    type: "POST",
                    url: "administracaoUser.aspx/alterar",
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

            function consulta() {

                var id = getFromUrl('id');

                if (id != null) {


                    var obj = {
                        id: id
                    }

                    strfy = JSON.stringify(obj);


                    $.ajax({
                        async: true,   // this will solve the problem
                        type: "POST",
                        url: "administracaoUser.aspx/consultar",
                        data: strfy,
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            var obj = JSON.parse(data.d);
                            // preencher formulario:


                            $('#nome').val(obj[0].nome);
                            $('#usuario').val(obj[0].usuario);
                            $('#senha').val(obj[0].senha);
                            $('#email').val(obj[0].email);
                            var permissao = obj[0].permissao;
                            $('input:radio[name="optionsRadios"]').filter('[value=' + permissao +']').prop('checked', true);
                            //attr('checked', true);

  

                      





                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }


            }

        </script>

    </form>
</body>
</html>
