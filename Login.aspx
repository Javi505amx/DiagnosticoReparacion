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
   

</head>
<body>

    <div class="container" >
        <h1>Iniciar Sesion</h1>
        <form runat="server">
           <div class="form-control">
                 <asp:Label ID="lblUser" Text="Usuario"  CssClass="label" runat="server"></asp:Label>
               <asp:TextBox ID="txtWorkOrder" cssClass="text" runat="server"   visible="true"  ></asp:TextBox>
            </div>
           <div class="form-control">
                 <asp:Label id="lblPassword"  CssClass="label" Text="Contraseña"  runat="server"></asp:Label>
                 <asp:TextBox id="txtPassword" type="input" cssClass="text" runat="server" TextMode="Password" ></asp:TextBox>
            </div>
            <asp:Button id="Button1"  CssClass="btn" Text="Iniciar Sesión" runat="server" />
            <asp:Label ID="Wrong"  runat="server" Visible="true"> </asp:Label>
        </form>
    </div>


</body>
</html>
