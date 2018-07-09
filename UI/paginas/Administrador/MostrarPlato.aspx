<%@ Page Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="MostrarPlato.aspx.cs" Inherits="UI.MostrarPlato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>
