<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicio.aspx.cs" Inherits="UI.PaginaInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagina de Inicio</title>
    <link rel="stylesheet" type="text/css" href="styles/generic_style.css"/>
</head>
<body>
    <form id="form1" runat="server" style="width= 500px">
        <div class="imgcontainer">
            <img src="images/if_key_309058.png" alt="Avatar" class="avatar"/>
        </div>
    <div>
    
    </div>
    <!-- <div class="container">
        <label for="uname"><b>Username</b></label>
        <input type="text" placeholder="Enter Username" name="uname" required>

        <label for="psw"><b>Password</b></label>
        <input type="password" placeholder="Enter Password" name="psw" required>
        
        <button type="submit">Login</button>
        <label>
        <br />
        <br />
      <input type="checkbox" checked="checked" name="remember"> Remember me
    </label>
  </div> -->

   <div class="container">
       <h1>¡Bienvenido!</h1>
        <asp:Label ID="lbCorreo" runat="server" Text="Correo: "></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbCorreo" runat="server" Width="352px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="tbCorreo" 
            ErrorMessage="Este campo es necesario"></asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="lbContrasena" runat="server" Text="Contraseña: "></asp:Label>
        </p>
        <asp:TextBox ID="tbContrasena" runat="server" TextMode="Password" Width="356px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvContrasenna" runat="server" ControlToValidate="tbContrasena" 
            ErrorMessage="Este campo es necesario"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" 
            Text="Ingresar " Height="42px" Width="96px"/>
    </div> 
    </form>
</body>
</html>
