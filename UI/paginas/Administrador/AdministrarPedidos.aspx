<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AdministrarPedidos.aspx.cs" Inherits="UI.AdministrarPedidos" %>

<%@ Import Namespace="BL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pedidos</h1>

    Filtrar:&nbsp;&nbsp;&nbsp;&nbsp;   
    <asp:DropDownList ID="ddlFiltrar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFiltrar_SelectedIndexChanged"></asp:DropDownList>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblXCliente" runat="server" Text="Ingrese el Cliente:"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnBuscarCliente" runat="server" OnClick="btnBuscarCliente_Click" Text="Buscar" />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblFecha1" runat="server" Text="Ingrese Fecha 1:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtFecha1" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblFecha2" runat="server" Text="Ingrese Fecha 2:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtFecha2" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnBuscarFecha" runat="server" OnClick="btnBuscarFecha_Click" Text="Buscar" />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblFormato" runat="server" Font-Bold="False" Font-Italic="True" Text="Formato: 2018-07-11 08:38:07.023"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:RegularExpressionValidator ID="revFecha1" runat="server" ControlToValidate="txtFecha1" ErrorMessage="Error en la Estructura de la Fecha Ingresada" ValidationExpression="^([\+-]?\d{4}(?!\d{2}\b))((-?)((0[1-9]|1[0-2])(\3([12]\d|0[1-9]|3[01]))?|W([0-4]\d|5[0-2])(-?[1-7])?|(00[1-9]|0[1-9]\d|[12]\d{2}|3([0-5]\d|6[1-6])))([T\s]((([01]\d|2[0-3])((:?)[0-5]\d)?|24\:?00)([\.,]\d+(?!:))?)?(\17[0-5]\d([\.,]\d+)?)?([zZ]|([\+-])([01]\d|2[0-3]):?([0-5]\d)?)?)?)?$"></asp:RegularExpressionValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RegularExpressionValidator ID="revFecha2" runat="server" ControlToValidate="txtFecha2" ErrorMessage="Error en la Estructura de la Fecha Ingresada" ValidationExpression="^([\+-]?\d{4}(?!\d{2}\b))((-?)((0[1-9]|1[0-2])(\3([12]\d|0[1-9]|3[01]))?|W([0-4]\d|5[0-2])(-?[1-7])?|(00[1-9]|0[1-9]\d|[12]\d{2}|3([0-5]\d|6[1-6])))([T\s]((([01]\d|2[0-3])((:?)[0-5]\d)?|24\:?00)([\.,]\d+(?!:))?)?(\17[0-5]\d([\.,]\d+)?)?([zZ]|([\+-])([01]\d|2[0-3]):?([0-5]\d)?)?)?)?$"></asp:RegularExpressionValidator>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblXEstado" runat="server" Text="Seleccione el Estado: "></asp:Label>
    &nbsp;
    <asp:DropDownList ID="ddlEstados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged">
    </asp:DropDownList>
    &nbsp;<div class="container">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                <% List<BL_Pedido> manejador = (List<BL_Pedido>)Session["manejador"];

                    foreach (BL_Pedido pedido in manejador)
                    {
                        int numero = pedido.Numero;
                        string estado = "";
                        string cliente = pedido.CorreoCliente;
                        DateTime fecha = pedido.Fecha;

                        switch (int.Parse(pedido.CodigoEstado))
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

    <h2>Modificar Estado de Pedido</h2>
    <h4>Ingrese el Numero del Pedido:
        <asp:TextBox ID="txtModificar" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;</h4>

    <h4>Seleccione el Nuevo Estado:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlEstadosModificar" runat="server" OnSelectedIndexChanged="ddlEstadosModificar_SelectedIndexChanged"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />


    </h4>
    &nbsp;&nbsp;&nbsp;   
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;


    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" Style="background-color: black" OnClick="btnRegresar_Click" />
</asp:Content>
