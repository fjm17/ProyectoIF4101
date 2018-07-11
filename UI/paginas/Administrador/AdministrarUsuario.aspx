<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuario.aspx.cs" Inherits="UI.AdministrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h1>Usuarios</h1>
        Correo:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCorreoBuscar" runat="server"></asp:TextBox>

        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        <br />
        <br />
        Nombre Completo:
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        Direccion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        <br />
        Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
        <br />
        <br />
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar " Style="background-color:black" OnClick="btnRegresar_Click" />
        <br />
        <br />

    </div>


</asp:Content>
