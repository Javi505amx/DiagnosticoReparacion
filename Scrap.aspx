<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scrap.aspx.cs" Inherits="DiagnosticoReparacion.Scrap" %>

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
    <title>SCRAP</title>

</head>
<body class="body-menu">
    <form  id="form1" runat="server">
     <div class="header-menu">
         <div class="nav-logo">
               <asp:Image ImageUrl="~/Resources/Images/inv.png" runat="server" Height="50px" Width="150px"/>
         </div><h1>INGRESO SCRAP</h1>
     </div>
 <div class="form-repa">
             <asp:Label ID="lblScan"   runat="server" Text="ESCANEAR SERIAL" Font-Size="150%" Font-Bold="true" ></asp:Label><br />
            <asp:TextBox ID="txtSerial" runat="server" ToolTip="escanear serial" ForeColor="#0079bc" AutoPostBack="true" Font-Size="150%" Style="text-transform:uppercase" AutoCompleteType="Disabled"  OnTextChanged="txtSerial_TextChanged"></asp:TextBox><br />
            <%--<asp:Label ID="lblCodeDefect" runat="server" Text="CODIGO DEFECTO:" Font-Size="150%" Font-Bold="true" ></asp:Label><br />
            <asp:TextBox ID="txtCodeDefect" runat="server" Enable="false" Text="" ForeColor="#0079bc" AutoPostBack="true" Font-Size="150%" Style="text-transform: uppercase" AutoCompleteType="Disabled"  Enabled="false" > </asp:TextBox>--%>
            </div>
        <div class="container4">
            
            <div id="labels" class="labels">
                <asp:Label ID="data1" runat="server" Text="Numero de Serie:" Visible="false"></asp:Label><br />
                <asp:Label ID="data2" runat="server" Text="Work Order:" Visible="false"></asp:Label><br />
                <asp:Label ID="data3" runat="server" Text="Modelo:" Visible="false"></asp:Label><br />
                <asp:Label ID="data4" runat="server" Text="Ingresó:" Visible="false"></asp:Label><br />
                <asp:Label ID="data5" runat="server" Text="Fecha Ingreso:" Visible="false"></asp:Label><br />
            </div>
            <div id="labelr" class="labelr">
                &nbsp;&nbsp;<asp:Label ID="lblSN" runat="server" Text="" ></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblWO" runat="server" Text=""></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblMOD" runat="server" Text=""></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblUSER" runat="server" Text="" Visible="false" ></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblDATE" runat="server" Text="" Visible="false" ></asp:Label><br />

            </div>
        </div>

       <div class="result">
           <asp:Label runat="server" Text="" id="res"></asp:Label>
       </div>

     <div id="nav-user" class="mx-auto" style="width: 1100px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label id="userlbl" runat="server" Text="Usuario:"></asp:Label>
            <asp:Label id="userlabel" runat="server" text=""></asp:Label>
     </div>
               

        <asp:LinkButton CssClass="btnLogout" runat="server" PostBackUrl="~/Menu.aspx">
                <span class="fas fa-backspace" aria-hidden="true"></span> &nbsp;Menú
            </asp:LinkButton>
        
        <asp:LinkButton CssClass="btnLogout2" runat="server" PostBackUrl="~/Login.aspx">
                <span class="fas fa-sign-out-alt" aria-hidden="true"></span> &nbsp;
            </asp:LinkButton>
    </form>
</body>
</html>
