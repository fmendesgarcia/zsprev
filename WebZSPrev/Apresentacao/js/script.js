if (window.location.href.indexOf("login") > -1 || window.location.href.indexOf("LOGIN") > -1) {
    $("#menu_horizontal").remove();
}

function insere_titulo_administracao(id, acao) {

    var href = location.href;

    var titulo = acao;

    if (href.indexOf("usuario") > -1) {
        titulo += 'Usuário';
    }
    else if (href.indexOf("motivo_cli") > -1) {
        titulo += 'Motivo';
    }
    else if (href.indexOf("situacao_benficio_cli") > -1) {
        titulo += 'Situação benefício';
    }
    else if (href.indexOf("status_cli") > -1) {
        titulo += 'Status cliente';
    }
    else if (href.indexOf("tipo_cli") > -1) {
        titulo += 'Tipo cliente';
    }
    else if (href.indexOf("tipo_doc") > -1) {
        titulo += 'Tipo documento';
    }
    else if (href.indexOf("tipo_comp") > -1) {
        titulo += 'Tipo compromisso';
    }
    else if (href.indexOf("tipo_mov") > -1) {
        titulo += 'Tipo movimentação';
    }
    else if (href.indexOf("especie") > -1) {
        titulo += 'Espécie';
    }
    else if (href.indexOf("status_pasta") > -1) {
        titulo += 'Status da pasta';
    }
    else if (href.indexOf("obs_contato") > -1) {
        titulo += 'Observações do contato';
    }



    $('#' + id).text(titulo);
}

var geral = {

    consultaItem: function (item) {
        $.getJSON('requests.aspx?objeto=' + item, function (dados) {

            var oTable = $('#dataTables-example-projeto').DataTable({
                responsive: true
   , "pageLength": 100,
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

               { "data": "id" },
               { "data": "nome" },
               { "data": "apagado" }

                ]

            });


        });

    },

    consultaUser: function () {
        $.getJSON('requests.aspx?objeto=user', function (dados) {

            var oTable = $('#dataTables-example-projeto').DataTable({
                responsive: true
   , "pageLength": 100,
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

               { "data": "id" },
               { "data": "nome" },
               { "data": "permissao" },
               { "data": "buttons" }

                ]

            });


        });
    },

    AbrirModal: function (idModal) {
        try {
            var obj = geral.GetObjFromWebStorage('_obj');
            document.getElementById("ContentPlaceHolder1_hidcliente").value = obj.id.toString();

            $("#" + idModal).modal('show');

        } catch (e) {
            alert("Primeiro é necessário cadastrar o cliente.");
            return;
        }

    },

    GetParamUrlByName: function (name, url) {
        if (!url) {
            url = window.location.href;
        }
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));

    },

    GetObjFromWebStorage: function (name) {
        var objTemp = null;
        objTemp = localStorage.getItem(name);
        //objTemp = atob(objTemp);
        objTemp = JSON.parse(objTemp);
        return objTemp;
    },

    SetObjWebStorage: function (name, obj) {
        obj = JSON.stringify(obj);
        //obj = btoa(obj);
        localStorage.setItem(name, obj);
    },

    DeleteObjFromWebStorage: function (name) {
        try {
            localStorage.removeItem(name);
        } catch (e) {

        }
    },


    CarregaCombo1: function (obj, combo) {
        $.ajax({
            url: 'requests.aspx?objeto=' + obj,
            dataType: 'json',
            data: null,
            async: false,
            success: function (dados) {

                if (dados.length > 0) {
                    var option = '<option>Selecione...</option>';
                    $.each(dados, function (i, obj) {
                        option += '<option value="' + obj.id + '">' + obj.nome + '</option>';
                    })
                    $('#' + combo).html(option).show();
                } else {

                }
            }
        });
    },

    CarregaCombo: function (obj, combo) {
        $.getJSON('requests.aspx?objeto=' + obj, function (dados) {
            if (dados.length > 0) {
                var option = '<option>Selecione...</option>';
                $.each(dados, function (i, obj) {
                    option += '<option value="' + obj.id + '">' + obj.nome + '</option>';
                })
                $('#' + combo).html(option).show();
            } else {

            }
        });
    },

    LimpaCamposModal: function (idModal) {

        // reseta os inputs
        var inputs = document.getElementById(idModal).getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            var tipo = inputs[i].getAttribute("type");
            if (tipo == "text" || tipo == "hidden") {
                inputs[i].value = '';
            }
        }

        var inputs = document.getElementById(idModal).getElementsByTagName("textarea");
        for (var i = 0; i < inputs.length; i++) {
            inputs[i].value = '';
        }

        //reseta os combos
        var elementos = document.getElementById(idModal).getElementsByTagName("select");
        for (var i = 0; i < elementos.length; i++) {
            elementos[i].value = '0';
        }

    },

    copyToClipboard: function (text) {
        if (window.clipboardData && window.clipboardData.setData) {
            // IE specific code path to prevent textarea being shown while dialog is visible.
            return clipboardData.setData("Text", text);

        } else if (document.queryCommandSupported && document.queryCommandSupported("copy")) {
            var textarea = document.createElement("textarea");
            textarea.textContent = text;
            textarea.style.position = "fixed";  // Prevent scrolling to bottom of page in MS Edge.
            document.body.appendChild(textarea);
            textarea.select();
            try {
                return document.execCommand("copy");  // Security exception may be thrown by some browsers.
            } catch (ex) {
                console.warn("Copy to clipboard failed.", ex);
                return false;
            } finally {
                document.body.removeChild(textarea);
            }
        }
    },

    RemoverPontos: function (id) {

        var valor = document.getElementById(id).value;


        //var valor = null;

        if (id.indexOf("mspanCPF") > -1) {
            valor = valor.replace(/\./g, "").replace(/\//g, "").replace(/-/g, "");
        }
        else {

            var nb_barra_pra_frente = valor.split("/")[1];
            valor = nb_barra_pra_frente.replace(/\./g, "").replace(/\//g, "").replace(/-/g, "");

        }

        return valor;
     



        




    }




};







