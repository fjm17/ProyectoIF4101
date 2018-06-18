<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarPlato.aspx.cs" Inherits="UI.EliminarPlato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Eliminar Plato</h1>
        Nombre:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnBuscar_Click" Text="Eliminar" />
    
    </div>
    </form>
</body>
</html>
