<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AdministrarEstados.aspx.cs" Inherits="UI.AdministrarEstados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Modificar los Tiempos de los Estados</h1>
    <h3>&nbsp;</h3>
    <h4>Seleccione el Estado: <asp:DropDownList ID="ddlEstados" runat="server" OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged"></asp:DropDownList></h4>
    <br />
    <br />
    <h4>Ingrese el nuevo tiempo en segundos: <asp:TextBox ID="txtTiempo" runat="server"></asp:TextBox></h4>
    <asp:Button ID="btnActualizar" runat="server" Text="Modificar" OnClick="btnActualizar_Click"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" Style="background-color:black" OnClick="btnRegresar_Click" />
    <br />
    <br />
</asp:Content>
