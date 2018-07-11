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
                
                <%if (true)
                    {
                        Label l2;
                        Button b1;
                        PlaceHolder PH_NombrePedido;
                        PlaceHolder PH_ButtonPedido;
                        string[] vec = (string[])Session["Array"];
                        foreach (string var in vec)
                        {
                              %>
                <div class="col-sm-4" style="width: 230px; top: 0px; left: 0px; height: 262px;" id="div1">
                    <div class="panel panel-primary" style="border-color: gold;">

                        <%  PH_NombrePedido = new PlaceHolder();
                            l2 = new Label();
                            l2.ID = "lb"; //+ var;
                            l2.Text = var;
                            PanelNombres.Controls.Add(PH_NombrePedido);
                            PH_NombrePedido.Controls.Add(l2); %>

                        <div id="dad" class="panel-heading" style="background-color: red; border-bottom-color: red">
                            <asp:Panel ID="PanelNombres" runat="server" EnableViewState="False"></asp:Panel>
                            
                        </div>
                  
                        <div class="panel-body">
                            <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width: 100%" alt="Image" />
                        </div>
                        <%  PH_ButtonPedido = new PlaceHolder();
                            b1 = new Button();
                            b1.ID = "btn" + var;
                            b1.Text = var;
                            b1.Click += new System.EventHandler(Button1_Click);
                            PanelBotones.Controls.Add(PH_ButtonPedido);
                            PH_ButtonPedido.Controls.Add(b1);
                            %>
                        <div class="panel-footer">
                            <asp:Panel ID="PanelBotones" runat="server" EnableViewState="False"></asp:Panel>
                            
                        </div>
                        

                    </div>
                </div>
                <%          PanelNombres.Controls.Remove(PH_NombrePedido);  
                            PanelBotones.Controls.Remove(PH_ButtonPedido);                      
                        }
                    } %>
                    
            </ContentTemplate>

        </asp:UpdatePanel>

    </div>
    <div class="container">
        <div class="row">
            <asp:Label ID="lb" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="btnDeshacer" runat="server" Height="43px" Style="background-color: red" Text="Deshacer" Width="102px" OnClick="btnDeshacer_Click1" />
        </div>

    </div>
    &nbsp;<asp:UpdatePanel ID="upParteInferior" runat="server">
        <ContentTemplate>
            &nbsp;&nbsp;&nbsp;&nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>
