<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reparacion.aspx.cs" Inherits="DiagnosticoReparacion.Reparacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Resources/Images/inventronics icon.ico" rel="icon" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Resources/CSS/Styles.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
    <script src="Resources/JS/script.js"></script>
    <title>INGRESO DIAGNÓSTICO</title>

</head>

<body class="body-menu">
    <form id="form1" runat="server">
        <div class="header-menu">
            <div class="nav-logo">
                <asp:Image ImageUrl="~/Resources/Images/inv.png" runat="server" Height="50px" Width="150px" />
            </div>

            <h1>INGRESO DIAGNÓSTICO</h1>


        </div>


        <%--         <div id="divOptions" class="form-group">
            <asp:RadioButton ID="rbPanel" Text=" Panel Validation" GroupName="rgOptions" runat="server" Font-Size="150%"/><br />
            <asp:RadioButton ID="rbMain" Text=" Main Validation" GroupName="rgOptions" runat="server" Font-Size="150%"/>
            <hr />
        </div>--%>

        <div class="form-repa">
            <asp:Label ID="lblScan" runat="server" Text="ESCANEAR SERIAL" Font-Size="150%" Font-Bold="true"></asp:Label><br />
            <asp:TextBox ID="txtSerial" runat="server" ToolTip="escanear serial" ForeColor="#0079bc" AutoPostBack="true" Font-Size="150%" Style="text-transform: uppercase" AutoCompleteType="Disabled" OnTextChanged="txtSerial_TextChanged"></asp:TextBox><br />
            <%--<asp:Label ID="lblCodeDefect" runat="server" Text="CODIGO DEFECTO:" Font-Size="150%" Font-Bold="true" ></asp:Label><br />
            <asp:TextBox ID="txtCodeDefect" runat="server" Enable="false" Text="" ForeColor="#0079bc" AutoPostBack="true" Font-Size="150%" Style="text-transform: uppercase" AutoCompleteType="Disabled"  Enabled="false" > </asp:TextBox>--%>
        </div>
        <div class="container4 mx-auto">

            <div id="labels" class="labels">
                <asp:Label ID="data1" runat="server" Text="Numero de Serie:" Visible="false"></asp:Label><br />
                <asp:Label ID="data2" runat="server" Text="Work Order:" Visible="false"></asp:Label><br />
                <asp:Label ID="data3" runat="server" Text="Modelo:" Visible="false"></asp:Label><br />
                <asp:Label ID="data4" runat="server" Text="Falla:" Visible="false"></asp:Label><br />
                <asp:Label ID="data5" runat="server" Text="Valor:" Visible="false"></asp:Label>
                <%--<asp:Label ID="Label1" runat="server" Text="Diagnosticos:" Visible="true"></asp:Label>--%>
            </div>
            <div id="labelr" class="labelr">
                &nbsp;&nbsp;<asp:Label ID="lblSN" runat="server" Text=""></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblWO" runat="server" Text=""></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblMOD" runat="server" Text=""></asp:Label><br />
                &nbsp;&nbsp;<asp:DropDownList runat="server" ID="ListValue" Visible="false" CssClass="mydropdownlist" AutoPostBack="true" Font-Size="Small">
                    <asp:ListItem Value="0" Text="">Falla</asp:ListItem>
                    <asp:ListItem Value="FF0001-Falso Rechazo de equipo" Text="FF0001-Falso Rechazo de equipo"></asp:ListItem>
                    <asp:ListItem Value="FF0002-Debugeo de fixture nuevo" Text="FF0002-Debugeo de fixture nuevo"></asp:ListItem>
                    <asp:ListItem Value="FF0002-Residuos de potting en cables" Text="FF0003-Residuos de potting en cables"></asp:ListItem>
                    <asp:ListItem Value="FF0004-Falla en el equipo de diagnostico" Text="FF0004-Falla en el equipo de diagnostico"></asp:ListItem>
                    <asp:ListItem Value="FF0005-Falso Rechazo operación" Text="FF0005-Falso Rechazo operación"></asp:ListItem>
                    <asp:ListItem Value="FF0006-Falta de prueba OTP" Text="FF0006-Falta de prueba OTP"></asp:ListItem>
                    <asp:ListItem Value="FFR001-Falso Rechazo de Equipo Output Current" Text="FF0005-Falso Rechazo de Equipo Output Current"></asp:ListItem>
                    <asp:ListItem Value="FF0008-Residuos de potting en conector" Text="FF0008-Residuos de potting en conector"></asp:ListItem>
                    <asp:ListItem Value="FF0009-Falso Rechazo por conexión" Text="FF0009-Falso Rechazo por conexión"></asp:ListItem>
                    <asp:ListItem Value="FF0010-Falla de dimmimg" Text="FF0010-Falla de dimmimg"></asp:ListItem>
                    <asp:ListItem Value="FF0011-Programación de SCARD" Text="FF0011-Programación de SCARD"></asp:ListItem>
                    <asp:ListItem Value="FR0012-Write current (corriente de escritura)" Text="FR0012-Write current (corriente de escritura)"></asp:ListItem>
                    <asp:ListItem Value="FR0013-Turn on time (Tiempo de encendido )" Text="FR0013-Turn on time (Tiempo de encendido)"></asp:ListItem>
                    <asp:ListItem Value="FR0014-Read and write information" Text="FR0014-Read and write information"></asp:ListItem>
                    <asp:ListItem Value="FR0015-Clean calibration value" Text="FR0015-Clean calibration value"></asp:ListItem>
                    <asp:ListItem Value="FR0016-Calibrate 10% current" Text="FR0016-Calibrate 10% current"></asp:ListItem>
                    <asp:ListItem Value="FR0017-Calibrate current" Text="FR0017-Calibrate current"></asp:ListItem>
                    <asp:ListItem Value="FR0018-PF (factor de potencia a alto voltaje)" Text="FR0018-PF (factor de potencia a alto voltaje)"></asp:ListItem>
                    <asp:ListItem Value="FR0019-EFF (eficiencia de voltaje)" Text="FR0019-EFF (eficiencia de voltaje)"></asp:ListItem>
                    <asp:ListItem Value="FR0020-PF (factor de potencia a bajo voltaje)" Text="FR0020-PF (factor de potencia a bajo voltaje)"></asp:ListItem>
                    <asp:ListItem Value="FR0021-EFF (eficiencia a bajo voltaje)" Text="FR0021-EFF (eficiencia a bajo voltaje)"></asp:ListItem>
                    <asp:ListItem Value="FR0022-Output current (corriente de salida)" Text="FR0022-Output current (corriente de salida)"></asp:ListItem>
                    <asp:ListItem Value="FR0022A-Output current (corriente de salida) POR EQUIPO" Text="FR0022A-Output current (corriente de salida) POR EQUIPO"></asp:ListItem>
                    <asp:ListItem Value="FR0023-No Load Voltage(sin voltaje de carga)" Text="FR0023-No Load Voltage(sin voltaje de carga)"></asp:ListItem>
                    <asp:ListItem Value="FR0024-Output voltage( voltaje de salida)" Text="FR0024-Output voltage( voltaje de salida)"></asp:ListItem>
                    <asp:ListItem Value="FR0025-THD(prueba de distorción armonica)" Text="FR0025-THD(prueba de distorción armonica)"></asp:ListItem>
                    <asp:ListItem Value="FR0026-OCP(Protección contra sobrecorriente)" Text="FR0026-OCP(Protección contra sobrecorriente)"></asp:ListItem>
                    <asp:ListItem Value="FR0027-Auxiliary source VCC( voltaje auxiliar de 12V)" Text="FR0027-Auxiliary source VCC( voltaje auxiliar de 12V)"></asp:ListItem>
                    <asp:ListItem Value="FR0028-Pico de tierra\Entrada - Tierra Verde" Text="FR0028-Pico de tierra\Entrada - Tierra Verde"></asp:ListItem>
                    <asp:ListItem Value="FR0029-AC - Earth (Entrada con tierra Verde)" Text="FR0029-AC - Earth (Entrada con tierra Verde)"></asp:ListItem>
                    <asp:ListItem Value="FR0030-DC - Earth(Salida-tierra Verde)" Text="FR0030-DC - Earth(Salida-tierra Verde)"></asp:ListItem>
                    <asp:ListItem Value="FR0031-AC - DC (Entrada-Salida)" Text="FR0031-AC - DC (Entrada-Salida)"></asp:ListItem>
                    <asp:ListItem Value="FR0032-AC - Earth2 (Entrada-Tierra Amarilla)" Text="FR0032-AC - Earth2 (Entrada-Tierra Amarilla)"></asp:ListItem>
                    <asp:ListItem Value="FR0033-AC - Earth2 (Medición del Gastube)" Text="FR0033-AC - Earth2 (Medición del Gastube)"></asp:ListItem>
                    <asp:ListItem Value="FF0038-Housing sucio" Text="FF0038-Housing sucio"></asp:ListItem>
                    <asp:ListItem Value="FF0039-faltante de firmware" Text="FF0039-faltante de firmware"></asp:ListItem>
                    <asp:ListItem Value="DOB001-Etiqueta serial invertida" Text="DOB001-Etiqueta serial invertida"></asp:ListItem>
                    <asp:ListItem Value="DOB002-Etiqueta producto" Text="DOB002-Etiqueta producto"></asp:ListItem>
                    <asp:ListItem Value="DOB003-Residuos de potting" Text="DOB003-Residuos de potting"></asp:ListItem>
                    <asp:ListItem Value="DOB004-Shield Loop mal colocado" Text="DOB004-Shield Loop mal colocado"></asp:ListItem>
                    <asp:ListItem Value="DOB005-Shield Loop dañado" Text="DOB005-Shield Loop dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB006-Shield Loop dañad" Text="DOB006-Shield Loop dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB007-Housing dañado" Text="DOB007-Housing dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB008-Side Case dañado" Text="DOB008-Side Case dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB009-Tornillo barrido" Text="DOB009-Tornillo barrido"></asp:ListItem>
                    <asp:ListItem Value="DOB010-Tornillo elevado" Text="DOB010-Tornillo elevado"></asp:ListItem>
                    <asp:ListItem Value="DOB011-Tornillo inclinado" Text="DOB011-Tornillo inclinado"></asp:ListItem>
                    <asp:ListItem Value="DOB012-Tornillo faltante" Text="DOB012-Tornillo faltante"></asp:ListItem>
                    <asp:ListItem Value="DOB013-Ground Washer floja" Text="DOB013-Ground Washer floja"></asp:ListItem>
                    <asp:ListItem Value="DOB014-Tuerca faltante" Text="DOB014-Tuerca faltante"></asp:ListItem>
                    <asp:ListItem Value="DOB015-cable dañado" Text="DOB015-cable dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB016-Sin serigrafia" Text="DOB016-Sin serigrafia"></asp:ListItem>
                    <asp:ListItem Value="DOB017-serigrafia invertida" Text="DOB017-serigrafia invertida"></asp:ListItem>
                    <asp:ListItem Value="DOB018-Housing barrido" Text="DOB018-Housing barrido"></asp:ListItem>
                    <asp:ListItem Value="DOB019-side case equivocado" Text="DOB019-side case equivocado"></asp:ListItem>
                    <asp:ListItem Value="DOB020-Housing rayado" Text="DOB020-Housing rayado"></asp:ListItem>
                    <asp:ListItem Value="DOB021-Side case rayada" Text="DOB021-Side case rayada"></asp:ListItem>
                    <asp:ListItem Value="DOB022-Side case rayada" Text="DOB022-Side case rayada"></asp:ListItem>
                    <asp:ListItem Value="DOB023-Cable expuesto" Text="DOB023-Cable expuesto"></asp:ListItem>
                    <asp:ListItem Value="DOB024-Falla de proveedor" Text="DOB024-Falla de proveedor"></asp:ListItem>
                    <asp:ListItem Value="DOB025-Housing invertido" Text="DOB025-Housing invertido"></asp:ListItem>
                </asp:DropDownList><br />
                &nbsp;&nbsp;<asp:TextBox ID="txtValue" runat="server" Text="" Visible="false" AutoCompleteType="Disabled" Style="text-transform: uppercase"></asp:TextBox><br />
            </div><br />
            <div class="btns-salida"><br />
                <div>
                    <asp:LinkButton runat="server" ID="btnSave" Text="" CssClass="btn3 btn-success d-block p-2" Font-Size="20px" Visible="false" AutoPostBack="true" OnClick="btnSave_Click">
                 <span class="fas fa-save font-weight-bold" aria-hidden="true"></span> &nbsp;&nbsp;GUARDAR
                    </asp:LinkButton>
                    <br />
                </div>
                <div>
                    <asp:LinkButton runat="server" ID="btnCancel" Text="" CssClass="btn3 btn-danger d-block p-2" Font-Size="20px" Visible="false" OnClick="btnCancel_Click">
                 <span class="fas fa-eraser font-weight-bold" aria-hidden="true"></span>&nbsp;&nbsp;CANCELAR
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" ID="LinkButton1" Text="" CssClass="btn4 btn-warning d-block p-2" Font-Size="20px" Visible="false">
                 <span class="fas fa-eraser font-weight-bold" aria-hidden="true"></span>&nbsp;&nbsp;MODIFICAR
                    </asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="result mx-auto">
            <asp:Label runat="server" Text="" ID="res"></asp:Label>
        </div>

        <div id="nav-user" class="mx-auto" style="width: 1100px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="userlbl" runat="server" Text="Usuario:"></asp:Label>
            <asp:Label ID="userlabel" runat="server" Text=""></asp:Label>
        </div>
        <asp:LinkButton CssClass="btnLogout" runat="server" PostBackUrl="~/Menu.aspx"> <span class="fas fa-backspace" aria-hidden="true"></span> &nbsp;Menú
        </asp:LinkButton>

        <asp:LinkButton CssClass="btnLogout2" runat="server" PostBackUrl="~/Login.aspx"><span class="fas fa-sign-out-alt" aria-hidden="true"></span> &nbsp;
        </asp:LinkButton>
    </form>


</body>
</html>
