<%@ Page Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="EliminarPlato.aspx.cs" Inherits="UI.EliminarPlato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    
        <h1>Eliminar Plato</h1>
        Nombre:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Eliminar" />
    
    </div>
</asp:Content>

