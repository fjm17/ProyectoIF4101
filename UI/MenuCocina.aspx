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
        
        <asp:UpdatePanel ID="upPedidos" runat="server">
            <ContentTemplate>

                <%if (!IsPostBack)
                    {
                        Label l2;
                        Button b1;
                        PlaceHolder PH_NombrePedido;
                        string[] vec = (string[])Session["Array"];
                        foreach (string var in vec)
                        { %>
                <div class="col-sm-4" style="width: 230px; top: 0px; left: 0px; height: 262px;" id="div1">
                    <div class="panel panel-primary" style="border-color: gold;">

                        <%  PH_NombrePedido = new PlaceHolder();                            
                            l2 = new Label();
                            l2.ID = "lb" + var;
                            l2.Text = var;
                            Panel1.Controls.Add(PH_NombrePedido);

                            PH_NombrePedido.Controls.Add(l2); %>

                        <div id="dad" class="panel-heading" style="background-color: red; border-bottom-color: red">
                            <asp:Panel ID="Panel1" runat="server" EnableViewState="False"></asp:Panel>
                            <!--<asp:PlaceHolder ID="PH_NombrePedido" runat="server"></asp:PlaceHolder>-->
                          
                        </div>
                  
                        <div class="panel-body">
                            <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width: 100%" alt="Image" />
                        </div>
                        <%  b1 = new Button();
                            b1.ID = "btn" + var;
                            b1.Text = var;
                            PH_ButtonPedido.Controls.Add(b1);
                            %>
                        <div class="panel-footer">
                            <asp:PlaceHolder ID="PH_ButtonPedido" runat="server"></asp:PlaceHolder>
                            <!--<asp:Button ID="btnPedido1" runat="server" Height="43px" Text="Finalizar" 
                                Width="102px" OnClick="Pedido1_Click" />-->
                        </div>
                        

                    </div>
                </div>
                <%}
                    } %>
            </ContentTemplate>

        </asp:UpdatePanel>

    </div>
    <div class="container">
        <div class="row">
        </div>

    </div>
    &nbsp;<asp:UpdatePanel ID="upParteInferior" runat="server">
        <ContentTemplate>
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDeshacer" runat="server" Height="43px" Style="background-color: red" Text="Deshacer" Width="102px" OnClick="btnDeshacer_Click1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>
