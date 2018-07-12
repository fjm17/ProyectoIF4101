<%@ Page Language="C#" MasterPageFile="~/BarraNavegacion.Master" AutoEventWireup="true" CodeBehind="MenuCocina.aspx.cs" Inherits="UI.MenuCocina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1>Pedidos disponibles</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!--<spg:SafeScriptManager ID="SafeScriptManager" EnableUpdatePanelSupport = “True”/>-->
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
       <!-- <asp:UpdatePanel ID="upPedidos" runat="server">
            <ContentTemplate>-->

                <%
                    List<BL.BL_Pedido> vec = (List<BL.BL_Pedido>)Session["Array"];

                    for (int i = 0; i < vec.Count; i++)
                    {
                        pe = vec[i];
                        pruebas();
                        %>
                <div class="col-sm-4" style="width: 230px; top: 0px; left: 0px; height: 262px;" id="div1">
                    <div class="panel panel-primary" style="border-color: gold;">

                        <% //crearLabel(var); %>

                        <div class="panel-heading" style="background-color: red; border-bottom-color: red">
                            <asp:Panel ID="PanelNombres" runat="server"></asp:Panel>

                        </div>
                        <% //crearPedidos(var); %>
                        <div class="panel-body">
                            <asp:Panel ID="PanelDetallesPedidos" runat="server"></asp:Panel>
                        </div>

                        <% //crearButton(var);
                            asignarBoton(i); %>

                        <div class="panel-footer">
                            <asp:Panel ID="PanelBotones" runat="server"></asp:Panel>
                        </div>
                        
                    </div>
                </div>
                <% //limpiarPaneles();
                    } %>
           <!-- </ContentTemplate>

        </asp:UpdatePanel>-->

    </div>
    <div class="container">
        <div class="row">
        </div>

    </div>
    <asp:Button ID="btnDeshacer" runat="server" Height="43px" Style="background-color: red" 
                    Text="Deshacer" Width="102px" OnClick="btnDeshacer_Click1" />
    &nbsp;<asp:UpdatePanel ID="upParteInferior" runat="server">
        <ContentTemplate>
            &nbsp;&nbsp;&nbsp;&nbsp;
                
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>
