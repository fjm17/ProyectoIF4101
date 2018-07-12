<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaCocina.aspx.cs" Inherits="UI.paginas.Cocina.ListaCocina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%  string[] vec = (string[])Session["Array"];
            foreach (string var in vec)
            {
                pruebas(); %>
    <div>
        
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        
    </div>
        <%} %>
    </form>
</body>
</html>
