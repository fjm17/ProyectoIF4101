<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPlato.aspx.cs" Inherits="UI.AgregarPlato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Agregar Plato</h1>
        Nombre:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
        <br />
        <br />
        Descripción:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbDescripcion" runat="server"></asp:TextBox>
        <br />
        <br />
        Precio:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbPrecio" runat="server"></asp:TextBox>
        <br />
        <br />
        Foto:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbFoto" runat="server"></asp:TextBox>
        <br />
        <br />
        Estado:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEstado" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    
    </div>
    </form>
</body>
</html>
