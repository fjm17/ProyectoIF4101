<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AdministrarPlato.aspx.cs" Inherits="UI.paginas.Administrador.ActualizarPlato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function showimagepreview(input) {

            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {

                    document.getElementsByTagName("foto")[0].setAttribute("ImageUrl", e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    
        <h1>Administrar Plato</h1>
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
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:FileUpload ID="FileFoto" runat="server" onchange="showimagepreview(this)"/>
        &nbsp;&nbsp;
        <asp:Image ID="foto" runat="server" Height="93px" Width="150px" />
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
    
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Height="41px" Width="110px" />
    
        &nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" Height="41px" Width="110px" BackColor="Black"/>
    
        <br />
    
        <br />
    
    </div>
</asp:Content>
