<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="DiagnosticoReparacion.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="Resources/Images/inventronics icon.ico" rel="icon" />
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous"/>    
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet"/>
<link rel="stylesheet" href="Resources/CSS/Styles.css" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
<script src="Resources/JS/script.js"></script>

    <title>MENÚ</title>
    
</head>
    
<body class="body-menu">
    <div class="header-menu">
         <div class="nav-logo">
               <asp:Image ImageUrl="~/Resources/Images/inv.png" runat="server" Height="50px" Width="150px"/>
        </div>
        <h1>MENÚ</h1><br /><br />
       
    </div>



    
        
        <form  runat="server">
            
      <div class="container2 mx-auto">
        <div class="form-control-menu">
            <asp:LinkButton id="btnUsuarios" CssClass="btn-menu" runat="server" Visible="false" PostBackUrl="~/Usuarios.aspx" >
                <span class="fas fa-users" aria-hidden="true"></span>&nbsp;&nbsp;&nbsp;Usuarios
            </asp:LinkButton><br /><br /> <br /> 
             <asp:LinkButton  id="btnConsulta" CssClass="btn-menu" runat="server"  Visible="false" PostBackUrl="~/MenuConsultas.aspx">
                <span class="fas fa-search" aria-hidden="true"></span>&nbsp;&nbsp;&nbsp;Consulta 
            </asp:LinkButton><br /><br /> <br />
            <asp:LinkButton ID="btnDiagnostico" CssClass="btn-menu" runat="server"  Visible="false" PostBackUrl="~/Reparacion.aspx">
                <span class="fas fa-barcode" aria-hidden="true"></span>&nbsp;&nbsp;&nbsp;Ingreso Diagnóstico
            </asp:LinkButton><br /><br /> <br />
            <asp:LinkButton ID="btnDiagnostico2" CssClass="btn-menu" runat="server" Visible="false" PostBackUrl="~/Diagnostico.aspx">
                <span class="fas fa-diagnoses" aria-hidden="true"></span>&nbsp;&nbsp;&nbsp;Diagnóstico
            </asp:LinkButton><br /><br /> <br />
             <asp:LinkButton ID="btnReparacion" CssClass="btn-menu" runat="server" Visible="false" PostBackUrl="~/ReparacionSalida.aspx" >
                <span class="fas fa-microchip" aria-hidden="true"></span>&nbsp;&nbsp;&nbsp;Reparacion
            </asp:LinkButton><br /><br /> <br />
            <asp:LinkButton ID="btnScrap" CssClass="btn-menu" runat="server" Visible="false" PostBackUrl="~/Scrap.aspx" >
                <span class="fas fa-trash" aria-hidden="true"></span>&nbsp;&nbsp;&nbsp;Ingreso Scrap
            </asp:LinkButton><br /><br /> <br />
                        <asp:LinkButton ID="btnScrapSalida" CssClass="btn-menu" runat="server" Visible="false" PostBackUrl="~/SalidaScrap.aspx" >
                <span class="fas fa-trash-restore" aria-hidden="true"></span>&nbsp;&nbsp;&nbsp;Salida Scrap
            </asp:LinkButton><br />
          
         </div> 
         </div>   
            <div id="nav-user" class="mx-auto" style="width: 1100px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label id="userlbl" runat="server" Text="Usuario:"></asp:Label>
             <asp:Label id="userlabel" runat="server" text=""></asp:Label>
         </div>
            <asp:LinkButton CssClass="btnLogout2" runat="server" PostBackUrl="~/Login.aspx">
                <span class="fas fa-sign-out-alt" aria-hidden="true"></span>
            </asp:LinkButton>

        </form>
        
  
    
</body>
</html>
