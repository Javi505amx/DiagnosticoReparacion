<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DiagnosticoReparacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="Resources/Images/inventronics icon.ico" rel="icon" />
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous"/>    
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet"/>
<link rel="stylesheet" href="Resources/CSS/Styles.css" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
<script src="Resources/JS/script.js"></script>
        <title>Diagnostico/Reparacion</title>
<script type="text/javascript">
    function preventBack() { window.history.forward(); }
    setTimeout("preventBack()", 0);
    window.onunload = function () { null };
</script>

   
    <script src="script.js"></script>
   <!-- kfvñdfhvdfv -->

</head>
<body class="body-menu">
     <div class="header-menu">
         <div class="nav-logo">
               <asp:Image ImageUrl="~/Resources/Images/inv.png" runat="server" Height="50px" Width="150px"/>
        </div>
        <h1>Diagnóstico & Reparación</h1><br /><br />
        <div class="nav-user">
               <asp:Label id="user" runat="server" Text=""></asp:Label>
        </div>

    </div>

    <div class="container" >
        <br />
        <h2>Iniciar Sesión</h2>
        <form runat="server">
           <div class="form-control">
               <asp:Label ID="lblUser" Text="Usuario"  Font-Bold="true" CssClass="label" runat="server"></asp:Label><br />
               <asp:TextBox ID="txtUsuario" cssClass="text" runat="server"   visible="true" AutoCompleteType="Disabled" Font-Bold="true" ToolTip="Escanear Usuario"  OnTextChanged="txtUsuario_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
           <div class="form-control">
                 <asp:Label id="lblPassword"  Font-Bold="true" CssClass="label" Text="Contraseña"  runat="server"></asp:Label><br />
                 <asp:TextBox id="txtPassword" type="input" cssClass="text" runat="server" TextMode="Password" AutoCompleteType="Disabled" Font-Bold="true"></asp:TextBox><br />
            <asp:Label id="labelwrong" CssClass="Wrong" runat="server" Visible="true" Font-Bold="true"  Font-Size="110%"> </asp:Label>
           </div>
            <asp:Button id="Button1"  CssClass="btn" Text="Iniciar Sesión" runat="server" OnClick="Button1_Click" Font-Bold="true" />
            
        </form>
    </div>


</body>
</html>
