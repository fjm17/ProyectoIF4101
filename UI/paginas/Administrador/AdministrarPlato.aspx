<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AdministrarPlato.aspx.cs" Inherits="UI.paginas.Administrador.ActualizarPlato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">

            function establecerFoto() {
                var nombre = '<%=Session["nombreFoto"]%>';
                document.getElementById("img").src = nombre;
            }
            

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
        <p>
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
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<img id="img" alt="" style="width:200px; height: 150px;" /><br />
        <br />
        </p>
        <asp:FileUpload ID="FileFoto" runat="server" onchange="actualizarFoto(this)"/>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbEstado" class="Label" runat="server" Text="Estado" Height="22px" Width="65px" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="cbEstado" runat="server" Height="35px" Width="193px">
        </asp:DropDownList>
        <br />
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
