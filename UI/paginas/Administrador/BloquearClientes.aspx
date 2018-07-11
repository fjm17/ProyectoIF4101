<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="BloquearClientes.aspx.cs" Inherits="UI.BlquearClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Modicar Estado de Cuenta</h1>

    Correo: <asp:TextBox ID="txtCorreoBuscar" runat="server"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />

    <br />
    <br />

    Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <br />
    Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
    <br />
    Direccion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
    <br />
    Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
    <br />
    Estado Actual: <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
  
    <br />
    <br />
    <br />
    <asp:Label ID="lblModificar" runat="server" Text="Modificar Estado de la Cuenta"></asp:Label>
    <br />
    <br />
    <asp:RadioButton ID="rdbHabilitar" runat="server" Checked="True" GroupName="Estados" Text="Habilitar" />
    <br />
    <asp:RadioButton ID="rdbInhabilitar" runat="server" Checked="True" GroupName="Estados" Text="Inhabilitar" />
    <br />
    <br />
    <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
    <br />
    <br />
    <br />
    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" Style="background-color:black" OnClick="btnRegresar_Click"/>
    <br />
    <br />
  
</asp:Content>
