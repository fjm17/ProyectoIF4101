<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuCocina.aspx.cs" Inherits="UI.MenuCocina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cocina</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" type="text/css" href="styles/generic_style.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1>Pedidos disponibles</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:UpdatePanel ID="upPedidos" runat="server">
            <ContentTemplate>
       <% for (int i = 0; i < 5; i++)
       { %>
                <div class="col-sm-4" style="width:230px">
                    <div class="panel panel-primary" style="border-color:gold;">
                        <div class="panel-heading" style="background-color:red; border-bottom-color:red">
                            Pedido <%=(i + 1)%>
                        </div>
                        <div class="panel-body">
                <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width:100%" alt="Image"/>
                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="Button1" runat="server" Height="43px" Text="Finalizar" Width="102px" />
                        </div>
                    </div>
                </div>
       <% } %>
      
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
                <asp:Button ID="btnDeshacer" runat="server" Height="43px" style="background-color:red" Text="Deshacer" Width="102px" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
    </form>
</body>
</html>
