<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="ActualizarPlato.aspx.cs" Inherits="UI.paginas.Administrador.ActualizarPlato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    
        <h1>Actualizar Plato</h1>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbNombre" class="Label" runat="server" Text="Nombre" Height="22px" Width="54px" Font-Bold="True"></asp:Label>
        &nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNombre" runat="server" Height="16px" Width="140px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Height="41px" Width="90px" />
        <br />
        <br />
        <h2>Datos del Plato</h2>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbDescripcion" class="Label" runat="server" Text="Descripcion" Height="22px" Width="75px" Font-Bold="True"></asp:Label>
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbDescripcion" runat="server" Height="74px" TextMode="MultiLine" Width="245px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbPrecio" class="Label" runat="server" Text="Precio" Height="22px" Width="65px" Font-Bold="True"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="tbPrecio" runat="server" Width="191px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbFoto" class="Label" runat="server" Text="Foto" Height="22px" Width="47px" Font-Bold="True"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbFoto" runat="server" Width="190px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbEstado" class="Label" runat="server" Text="Estado" Height="22px" Width="65px" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEstado" runat="server" Width="188px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" Height="41px" Width="110px" />
    
        <br />
    
        <br />
    
    </div>
</asp:Content>
