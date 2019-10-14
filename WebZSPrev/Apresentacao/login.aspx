<%@ Page Title="" Language="C#" MasterPageFile="~/Apresentacao/View.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebZSPrev.Apresentacao.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>

        geral.DeleteObjFromWebStorage("_obj");
    </script>


    <div class="container">
        <div class="row">

            
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading" style="background-color: rgb(43, 79, 111);color:white; border-color: #183b4c; ">
                        <h3 class="panel-title">Login</h3>
             
                    </div>
                    <div class="panel-body">
                        <form role="form">
                            <fieldset>
                                <div class="form-group">
                                              <asp:TextBox ID="txtuser" runat="server" class="form-control" type="text" />
                                </div>
                                <div class="form-group">
                              
                                    <asp:TextBox ID="txtsenha" runat="server" class="form-control" type="password" />
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input name="remember" type="checkbox" value="Remember Me">Lembrar-me
                                   
                                    </label>
                                </div>
                                <!-- Change this to a button or input when using this as a form -->


                                <asp:Button  class="btn btn-sm btn-info" Text="ENTRAR" style="float: right; background-color: rgb(43, 79, 111); border-color:  #183b4c; " runat="server" OnClick="Unnamed1_Click"  />
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
