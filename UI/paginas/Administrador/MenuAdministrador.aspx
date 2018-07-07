<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="UI.paginas.Administrador.MenuAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="dropdown">
    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
        style="background-color:red;color:white;border-color:yellow">
      Gestionar Usuarios
    </button>
            <br />
    <div class="dropdown-menu container">
      <a class="dropdown-it" href="AgregarUsuario.aspx">Agregar Usuario</a>
             <br />
      <a class="dropdown-item" href="#.aspx">Actualizar datos de Usuario</a>
    </div>
  </div>

    <br />
    <div class="dropdown">
        <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
            style="background-color:red;color:white;border-color:yellow">
          Gestionar Platos
        </button>
         <div class="dropdown-menu container">
          <a class="dropdown-it" href="AgregarPlato.aspx">Agregar Plato</a>
             <br />
          <a class="dropdown-item" href="ActualizarPlato.aspx">Actualizar datos de Plato</a>
        </div>
    </div>
    </div>

    <p>
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

    <br />

</asp:Content>
