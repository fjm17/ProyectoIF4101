<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicio.aspx.cs" Inherits="UI.PaginaInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagina de Inicio</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
        ¡Bienvenido!
    </h1>
    </div>
        <asp:Label ID="lbCorreo" runat="server" Text="Correo: "></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbCorreo" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="tbCorreo" ErrorMessage="Este campo es necesario"></asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="lbContrasena" runat="server" Text="Contraseña: "></asp:Label>
        </p>
        <asp:TextBox ID="tbContrasena" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvContrasenna" runat="server" ControlToValidate="tbContrasena" ErrorMessage="Este campo es necesario"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar " />
    </form>
</body>
</html>
