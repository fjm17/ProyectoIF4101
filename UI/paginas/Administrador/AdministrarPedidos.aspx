<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AdministrarPedidos.aspx.cs" Inherits="UI.AdministrarPedidos" %>

<%@ Import Namespace="BL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pedidos</h1>
    <asp:GridView ID="grdListaPedidos" runat="server"></asp:GridView>

    <div class="container">

        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Numero</th>
                    <th>Estado</th>
                    <th>Cliente</th>
                    <th>Fecha de Creacion</th>
                    <th>Detalle de Pedido</th>
                </tr>
            </thead>
            <tbody>
                <% Manejador_Lista_Pedidos manejador = new Manejador_Lista_Pedidos();
                    manejador.MostrarTodosPedidos();
                    Manejador_Pedido manePedido = new Manejador_Pedido();

                    foreach (BL_Pedido pedido in manejador.Pedidos)
                    {
                        int numero = pedido.Numero;
                        string estado = "";
                        string cliente = pedido.CorreoCliente;
                        DateTime fecha = pedido.Fecha;

                        switch (numero)
                        {
                            case 1:
                                estado = "Entregado";
                                break;

                            case 2:
                                estado = "Anulado";
                                break;

                            case 3:
                                estado = "A Tiempo";
                                break;

                            case 4:
                                estado = "Sobre Tiempo";
                                break;

                            case 5:
                                estado = "Demorado";
                                break;
                        }
                %>

                <tr>
                    <td><%= numero %></td>
                    <td><%= estado %></td>
                    <td><%= cliente %></td>
                    <td><%= fecha %></td>
                    <td>
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th>Nombre de Comida</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (BL_Detalle_Pedido detalle in pedido.Detalles)
                                    {%>
                                <tr>
                                    <td>
                                        <%=detalle.NombrePlato%>
                                    </td>
                                </tr>
                                   <% } %>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <%}%>
            </tbody>
        </table>
    </div>

    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" style="background-color:black" OnClick="btnRegresar_Click"/>
</asp:Content>
