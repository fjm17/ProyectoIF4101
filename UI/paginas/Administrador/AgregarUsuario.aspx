<%@ Page Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="UI.AgregarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h1>
        Agregar Usuario
    </h1>
        <p>
    </p>
    </div>
    <div class="container">
            <asp:Label ID="lbNombre" runat="server" Text="Nombre" Font-Bold="True"></asp:Label>
            <br />
        <asp:TextBox ID="tbNombre" runat="server" Width="185px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbNombre" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lbCorreo" runat="server" Text="Correo Electronico" Font-Bold="True"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbCorreo" runat="server" style="margin-top: 0px" Width="181px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:RequiredFieldValidator ID="rvfCorreo" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbCorreo" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lbContrasenaCrear" runat="server" Text="Crear una contraseña" Font-Bold="True"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbContrasenaCrear" runat="server" Width="179px" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbContrasenaCrear" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lbContrasenaConfirmar" runat="server" Text="Confirmar Contraseña" Font-Bold="True"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbContrasenaConfirmar" runat="server" Width="178px" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:RequiredFieldValidator ID="rfvContrasenaConfirmar" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbContrasenaConfirmar" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lbDireccion" runat="server" Text="Direccion de casa Completa" Font-Bold="True"></asp:Label>
        <br />
        <asp:TextBox ID="tbDireccion" runat="server" Height="63px" TextMode="MultiLine" Width="239px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Este campo es necesario" ControlToValidate="tbDireccion" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lbTipo" runat="server" Text="Tipo" Font-Bold="True"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="ddlTipo" runat="server">
            <asp:ListItem>Administrador</asp:ListItem>
            <asp:ListItem>Cliente</asp:ListItem>
            <asp:ListItem>Cocina</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" Height="45px" Width="93px" />
        <br />
        <br />

    </div>
        
</asp:Content>
