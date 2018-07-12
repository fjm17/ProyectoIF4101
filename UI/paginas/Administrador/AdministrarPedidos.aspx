<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="AdministrarPedidos.aspx.cs" Inherits="UI.AdministrarPedidos" %>

<%@ Import Namespace="BL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pedidos</h1>

    Filtrar:&nbsp;&nbsp;&nbsp;&nbsp;    <asp:DropDownList ID="ddlFiltrar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFiltrar_SelectedIndexChanged"></asp:DropDownList>

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
&nbsp;<asp:RegularExpressionValidator ID="validarFecha1" runat="server" ControlToValidate="txtFecha1" ErrorMessage="No escrbio correctamente la fecha" ValidationExpression="^((((([13578])|(1[0-2]))[\-\/\s]?(([1-9])|([1-2][0-9])|(3[01])))|((([469])|(11))[\-\/\s]?(([1-9])|([1-2][0-9])|(30)))|(2[\-\/\s]?(([1-9])|([1-2][0-9]))))[\-\/\s]?\d{4})(\s((([1-9])|(1[02]))\:([0-5][0-9])((\s)|(\:([0-5][0-9])\s))([AM|PM|am|pm]{2,2})))?$"></asp:RegularExpressionValidator>
&nbsp;&nbsp;
    <asp:Label ID="lblFecha2" runat="server" Text="Ingrese Fecha 2:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtFecha2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnBuscarFecha" runat="server" OnClick="btnBuscarFecha_Click" Text="Buscar" />
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

    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" Style="background-color: black" OnClick="btnRegresar_Click" />
</asp:Content>
