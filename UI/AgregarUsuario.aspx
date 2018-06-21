<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="UI.AgregarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
        Agregar Usuario
    </h1>
        <p>
            <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
    </p>
    </div>
        <asp:TextBox ID="tbNombre" runat="server" Width="185px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbNombre"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lbCorreo" runat="server" Text="Correo Electronico"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbCorreo" runat="server" style="margin-top: 0px" Width="181px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="rvfCorreo" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbCorreo"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Label ID="lbContrasenaCrear" runat="server" Text="Crear una contraseña"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbContrasenaCrear" runat="server" Width="179px" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbContrasenaCrear"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lbContrasenaConfirmar" runat="server" Text="Confirmar Contraseña"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbContrasenaConfirmar" runat="server" Width="178px" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="rfvContrasenaConfirmar" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbContrasenaConfirmar"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Label ID="lbDireccion" runat="server" Text="Direccion de casa Completa"></asp:Label>
        <br />
        <asp:TextBox ID="tbDireccion" runat="server" Height="63px" TextMode="MultiLine" Width="239px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbDireccion"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" style="width: 67px" />
        <br />
        <br />
    </form>
</body>
</html>
