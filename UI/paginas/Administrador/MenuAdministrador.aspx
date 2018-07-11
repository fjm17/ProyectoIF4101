<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="UI.paginas.Administrador.MenuAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <!-- 
        <div class="dropdown">
    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
        style="background-color:#DD392E;color:white;border-color:white">
      Gestionar Usuarios
    </button>
            <br />
    <div class="dropdown-menu container" style="background-color:yellow; color:black">
      <a class="dropdown-it" href="AgregarUsuario.aspx">Agregar Usuario</a>
             <br />
      <a class="dropdown-item" href="#.aspx">Actualizar datos de Usuario</a>
    </div>
  </div>
  -->

   <div class="dropdown btn-group">
      <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown" 
          style="background-color:#DD392E;color:white;border-color:white">
          Gestionar Usuarios
        <span class="caret"></span>
      </button>
      
      <ul class="dropdown-menu" style="background-color:yellow; color:black">
        <li><a class="dropdown-it" href="AgregarUsuario.aspx">Agregar Usuario</a></li>
        <li><a class="dropdown-it" href="#.aspx">Actualizar datos de Usuario</a></li>
      </ul>

    </div>
    <br />
        <br />
    <br />
  <div class="dropdown btn-group">
      <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown" 
          style="background-color:#DD392E;color:white;border-color:white">
          Gestionar Platos
        <span class="caret"></span>
      </button>

      <ul class="dropdown-menu" style="background-color:yellow; color:black">
        <li><a class="dropdown-it" href="AgregarPlato.aspx">Agregar Plato</a></li>
        <li><a class="dropdown-item" href="AdministrarPlato.aspx">Administrar Plato</a></li>
      </ul>

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
