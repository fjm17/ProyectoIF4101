<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="PedidosEnCocina.aspx.cs" Inherits="UI.paginas.Cocina.PedidosEnCocina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="15"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Pedidos disponibles</h1>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>

    </div>
    <asp:Button ID="btnDeshacer" runat="server" Height="43px" Style="background-color: red"
        Text="Deshacer" Width="102px" OnClick="btnDeshacer_Click1" />
</asp:Content>
