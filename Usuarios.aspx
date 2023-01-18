<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="DiagnosticoReparacion.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Resources/Images/inventronics icon.ico" rel="icon" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Resources/CSS/Styles.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
    <script src="Resources/JS/script.js"></script>

    <title>USUARIOS</title>
</head>
<body class="body-menu">

    <div class="header-menu">
        <div class="nav-logo">
            <asp:Image ImageUrl="~/Resources/Images/inv.png" runat="server" Height="50px" Width="150px" />
        </div>
        <h1>USUARIOS</h1>
    </div>

    <form id="form1" runat="server">
        <div class="container2">
            <div  class="form-group row">
                <asp:Label  class="col-2 col-form-label" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox id="aa" Text="11" class="col-10" runat="server"></asp:TextBox><br />
                <asp:Label  class="col-2 col-form-label" runat="server" Text="Nombre completo"></asp:Label>
                <asp:TextBox id="TextBox5" Text="22" class="col-10" runat="server"></asp:TextBox><br />
                <asp:Label  class="col-2 col-form-label" runat="server" Text="Numero de Empleado"></asp:Label>
                <asp:TextBox id="TextBox6" Text="11" class="col-10" runat="server"></asp:TextBox><br />
                <asp:Label  class="col-2 col-form-label" runat="server" Text="Area"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="" Text="Seleccione..."></asp:ListItem>
                    <asp:ListItem Value="MFG" Text="MFG"></asp:ListItem>
                    <asp:ListItem Value="QA" Text="QA"></asp:ListItem>
                    <asp:ListItem Value="IT" Text="IT"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox id="TextBox7" Text="11" class="col-10" runat="server"></asp:TextBox><br />
                <asp:Label  class="col-2 col-form-label" runat="server" Text="Administrador:"></asp:Label>
                <asp:CheckBox ID="CheckBox1" class="form-check-label" runat="server" />
            </div>
        </div>




        <div class="botones">
            <asp:LinkButton runat="server" CssClass="btnuser">
                <span class="fas fa-user-plus"></span>&nbsp;&nbsp;NUEVO
            </asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="btnuser">
                <span class="fas fa-save" ></span>&nbsp;&nbsp;GUARDAR
            </asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="btnuser">
                <span class="fas fa-trash"></span>&nbsp;&nbsp;ELIMINAR
            </asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="btnuser">
                <span class="fas fa-user-edit"></span>MODIFICAR
                <%--<span class="fas fa-users" aria-hidden="true"></span>&nbsp;&nbsp;MODIFICAR--%>
            </asp:LinkButton>

        </div>
        <asp:LinkButton CssClass="btnLogout" Text="REGRESAR" runat="server" PostBackUrl="~/Menu.aspx">
            <span class="fas fa-backspace" aria-hidden="true"></span> &nbsp;Regresar
        </asp:LinkButton>

    </form>
</body>
</html>
