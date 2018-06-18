<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarPlato.aspx.cs" Inherits="UI.MostrarPlato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Mostrar Plato</h1>
        Nombre:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
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
    
    </div>
    </form>
</body>
</html>
