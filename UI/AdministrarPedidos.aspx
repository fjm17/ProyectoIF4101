<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AdministrarPedidos.aspx.cs" Inherits="UI.AdministrarPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pedidos</h1>
    <asp:GridView ID="grdListaPediso" runat="server"></asp:GridView>
</asp:Content>
