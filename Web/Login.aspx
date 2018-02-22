<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Cadastro</title>
    <style>
        .container {
            width: 450px;
            margin: 0 auto;
        }

        .campo {
            padding: 5px;
        }

        .container h1 {
            text-align: center;
        }

        .campo input[type="text"] {
            float: right;
            margin: 0px;
            width: 350px;
        }

        .campo input[type="submit"] {
            float: right;
            padding: 5px;
        }

        .campo #btnCadastrar {
            margin-right: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Login  de Usuario</h1>
            <div class="campo">

                <asp:Label runat="server" AssociatedControlID="txtNome">Nome: </asp:Label>
                <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>

            </div>

            <div class="campo">
                <asp:Label runat="server" AssociatedControlID="txtSen">Senha: </asp:Label>
                <asp:TextBox runat="server" ID="txtSen"></asp:TextBox>

            </div>
            <p>
                <asp:Literal runat="server" ID="lt"></asp:Literal></p>
            <div class="campo">

                <asp:Button runat="server" Text="Acessar" ID="btnAcessar" OnClick="btnCadastrar_Click" />
                <asp:Button runat="server" Text="Cadastrar" ID="btnCadastrar" OnClick="btnCadastrar_Click" />
            </div>

        </div>

    </form>
</body>
</html>
