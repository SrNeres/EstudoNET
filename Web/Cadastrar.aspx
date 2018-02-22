<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="Web.Cadastrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastrar</title>
    <style>
        .cadastrar {
            width: 450px;
            height: 300px;
            margin: 0 auto;
            border-style: solid;
            margin-top: 100px;
        }

        .campo {
            padding: 5px;
        }

            .campo label {
            }

        .cadastrar h1 {
            text-align: center;
        }

        .campo input[type="text"] {
            float: right;
            margin: 0px;
            width: 370px;
        }

        .campo input[type="submit"] {
            float: right;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="cadastrar">
            <h1>Cadastrar</h1>
            <div class="campo">
                <asp:Label runat="server" AssociatedControlID="txtLog">Login: </asp:Label>
                <asp:TextBox runat="server" ID="txtLog"></asp:TextBox>

            </div>
            <div class="campo">
                <asp:Label runat="server" AssociatedControlID="txtSen">Senha: </asp:Label>
                <asp:TextBox runat="server" ID="txtSen"></asp:TextBox>

            </div>
            <div class="campo">
                <asp:Label runat="server" AssociatedControlID="txtEmail">Email: </asp:Label>
                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>

            </div>
            <div class="campo">
                <asp:Label runat="server" AssociatedControlID="txtTelefone">Telefone: </asp:Label>
                <asp:TextBox runat="server" ID="txtTelefone"></asp:TextBox>

            </div>
            <p>
                <asp:Literal runat="server" ID="lt"></asp:Literal>
            </p>
            <div class="campo">
                <asp:Button runat="server" Text="Cadastrar" ID="btnCadastrar" OnClick="btnCadastrar_Click" />

            </div>

        </div>
        <br />

        <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" Width="464px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" HorizontalAlign="Center" Height="398px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <Columns>
                <asp:BoundField DataField="usuarioid" HeaderText="Id" />
                <asp:BoundField DataField="login" HeaderText="Login" />
                <asp:BoundField DataField="senha" HeaderText="Senha" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="telefone" HeaderText="Telefone" />

                <asp:CommandField ShowEditButton="True" />

                <asp:CommandField ShowDeleteButton="True" />

            </Columns>
        </asp:GridView>

    </form>

</body>
</html>
