<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AgregarPlato.aspx.cs" Inherits="UI.paginas.Administrador.AgregarPlato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">

        function actualizarFoto(entrada) {

            if (entrada.files && entrada.files[0]) {
                var lector = new FileReader();
                lector.onload = function (e) {

                    document.getElementsByTagName("img")[0].setAttribute("src", e.target.result);
                }
                lector.readAsDataURL(entrada.files[0]);
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Agregar Plato</h1>
        &nbsp;&nbsp;
        <br />
        <asp:Label ID="lbNombre" runat="server" Text="Nombre" Font-Bold="True"></asp:Label>
        <br />
        <asp:TextBox ID="tbNombre" runat="server" Height="16px" Width="213px"></asp:TextBox>
        &nbsp;
        <br />
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbNombre" Display="Dynamic" ErrorMessage="Este campo no puede faltar"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lbDescripcion" runat="server" Text="Descripcion" Font-Bold="True"></asp:Label>
        <br />
        <asp:TextBox ID="tbDescripcion" runat="server" Height="69px" TextMode="MultiLine" Width="236px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="tbDescripcion" Display="Dynamic" ErrorMessage="Este campo no puede faltar"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbPrecio" runat="server" Text="Precio" Font-Bold="True"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbPrecio" runat="server" Height="16px" Width="180px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <br />
        <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="tbPrecio" Display="Dynamic" ErrorMessage="Este campo no puede faltar"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbFoto" runat="server" Text="Foto" Font-Bold="True"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <img id="img" alt="" style="width:200px; height: 150px;" />
        <br />
        <br />
        <asp:FileUpload ID="fileFoto" runat="server" onchange="actualizarFoto(this)"/>
        <asp:RequiredFieldValidator ID="rfvFoto" runat="server" ControlToValidate="fileFoto" Display="Dynamic" ErrorMessage="Se debe seleccionar una imagen"></asp:RequiredFieldValidator>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbEstado" runat="server" Text="Estado" Font-Bold="True"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEstado" runat="server" Height="16px" Width="180px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="tbEstado" Display="Dynamic" ErrorMessage="Este campo no puede faltar"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        
        
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" BackColor="Black" CausesValidation="False"/>
        
        
    </div>
</asp:Content>
