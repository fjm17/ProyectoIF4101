<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarUsuarios.aspx.cs" Inherits="UI.MostrarUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
        Gestionar Usuarios
    </h1>
    </div>
        <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbBusqueda" runat="server"></asp:TextBox>
        <br />
        <br />
    <div>
    
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        <br />
        <br />
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateSelectButton="True" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <br />
        <h4>Datos</h4>
        <br />
        Correo:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbCorreo" runat="server" Width="168px"></asp:TextBox>
        <br />
        <br />
        Nombre:&nbsp;&nbsp;
        <asp:TextBox ID="tbNombre" runat="server" Width="162px"></asp:TextBox>
        <br />
        <br />
        Direccion:&nbsp; <asp:TextBox ID="tbDescripcion" runat="server" Height="46px" Width="152px"></asp:TextBox>
        <br />
        <br />
        Tipo:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbTipo" runat="server"></asp:TextBox>
        <br />
    
    </div>
    </form>
</body>
</html>
