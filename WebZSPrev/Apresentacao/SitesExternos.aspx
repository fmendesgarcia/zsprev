<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SitesExternos.aspx.cs" Inherits="WebZSPrev.Apresentacao.SitesExternos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.min.js"></script>
    <script src="js/script.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <iframe id="myframe" name="freminho" style="border: 0;" src="https://sipa.inss.gov.br/SipaINSS/pages/consit/consitInicio.xhtml" width="900" height="900" frameborder="0" scrolling="no"></iframe>


    <div>
    
    </div>

       <script>

           $(document).ready(function () {

               try {
                   var Cli = geral.GetObjFromWebStorage("CliPesqExterna");
                   //alert(Cli.nome);
               }
               catch (e) {

               }



               var _url = location.href;

               if (_url.indexOf("inss_beneficio") > 1) {
                   document.getElementById("myframe").src = "https://sipa.inss.gov.br/SipaINSS/pages/consit/consitInicio.xhtml";
               }
               else if (_url.indexOf("inss_concessao") > -1) {
                   document.getElementById("myframe").src = "https://sipa.inss.gov.br/SipaINSS/pages/concal/concalInicio.xhtml";
               }
               else if (_url.indexOf("inss_revisao") > -1) {
                   document.getElementById("myframe").src = "https://sipa.inss.gov.br/SipaINSS/pages/consit02/consit02Inicio.xhtml";
               }
               else if (_url.indexOf("inss_pagamento") > -1) {
                   document.getElementById("myframe").src = "https://sipa.inss.gov.br/SipaINSS/pages/hiscre/hiscreInicio.xhtml";
               }


               //var Timer = setInterval(function () { PreencheCampos() }, 1000);

               //function PreencheCampos() {
               //    try {
               //        alert("entrou preenche campos com: " + Cli.nome);
               //        window.frames["freminho"].document.getElementById("nome").value = Cli.nome;
               //        PararTimer();
               //    } catch (e) {
               //        alert(e);
               //    }

               //}

               //function PararTimer() {
               //    clearInterval(Timer);
               //}

           });

       </script>
    </form>
</body>
</html>
