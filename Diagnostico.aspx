<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Diagnostico.aspx.cs" Inherits="DiagnosticoReparacion.Diagnostico" %>

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
    <title>Diagnóstico</title>
</head>
<body class="body-menu">
    <form id="form1" runat="server">
        <div class="header-menu">
            <div class="nav-logo">
                <asp:Image ImageUrl="~/Resources/Images/inv.png" runat="server" Height="50px" Width="150px" />
            </div>
            <h1>DIAGNÓSTICO</h1>
        </div>
        
        <div class="form-repa">
            <asp:Label ID="lblScan" runat="server" Text="ESCANEAR SERIAL" Font-Size="150%" Font-Bold="true"></asp:Label><br />

            
            <asp:TextBox ID="txtSerial" runat="server" ForeColor="#0079bc" AutoPostBack="true" Font-Size="150%" Style="text-transform: uppercase" AutoCompleteType="Disabled" OnTextChanged="txtSerial_TextChanged" ></asp:TextBox><br />
           
        </div>

        <div class="container4 mx-auto">
            <div id="labels" class="labels">
                <asp:Label ID="data1" runat="server" Text="Numero de Serie:" Visible="false"></asp:Label><br />
                <asp:Label ID="data2" runat="server" Text="Work Order:" Visible="false"></asp:Label><br />
                <asp:Label ID="data3" runat="server" Text="Modelo:" Visible="false"></asp:Label><br />
                <asp:Label ID="data4" runat="server" Text="Ingresó:" Visible="false"></asp:Label><br />
                <asp:Label ID="data5" runat="server" Text="Fecha Ingreso:" Visible="false"></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Text="Falla:" Visible="false"></asp:Label><br />
                <asp:Label ID="Label2" runat="server" Text="Valor:" Visible="false"></asp:Label><br />
                <asp:Label ID="Label6" runat="server" Text="Diagnostico:" Visible="false"></asp:Label><br /><br />
                <%--<asp:Label ID="Label5" runat="server" Text="Diagnostico:" Visible="false"></asp:Label><br />--%>
                <asp:Label ID="Label4" runat="server" Text="Locación:" Visible="false"></asp:Label><br /><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Comentarios:" Visible="false"></asp:Label><br />
            </div>
            <div id="labelr" class="labelr">
                &nbsp;&nbsp;<asp:Label ID="lblSN" runat="server" Text="" Visible="false" ></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblWO" runat="server" Text="" Visible="false" ></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblMOD" runat="server" Text="" Visible="false" ></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblUSER" runat="server" Text="" Visible="false" ></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblDATE" runat="server" Text="" Visible="false" ></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblFalla" runat="server" Text="" Visible="false" ></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblValor" runat="server" Text="" Visible="false" ></asp:Label><br />
                &nbsp;&nbsp;<asp:DropDownList runat="server" ID="ListValue" Visible="false" CssClass="mydropdownlist" AutoPostBack="true" Font-Size="Small">
                    <asp:ListItem Value="0" Text="">Falla</asp:ListItem>
                    <asp:ListItem Value="DTU001-Componente faltante" Text="DTU001-Componente faltante"></asp:ListItem>
                    <asp:ListItem Value="DTU002-Sin evidencia de pin" Text="DTU002-Sin evidencia de pin"></asp:ListItem>
                    <asp:ListItem Value="DTU003-Pin sin insertar" Text="DTU003-Pin sin insertar"></asp:ListItem>
                    <asp:ListItem Value="DTU004-Cables Invertidos" Text="DTU004-Cables Invertidos"></asp:ListItem>
                    <asp:ListItem Value="DTU005-Componente Elevado" Text="DTU005-Componente Elevado"></asp:ListItem>
                    <asp:ListItem Value="DTU006-Componente mal colocado" Text="DTU006-Componente mal colocado"></asp:ListItem>
                    <asp:ListItem Value="DTU007-Componente Invertido" Text="DTU007-Componente Invertido"></asp:ListItem>
                    <asp:ListItem Value="DTU008-Componente extra" Text="DTU008-Componente extra"></asp:ListItem>
                    <asp:ListItem Value="DTU009-Componente sin soldar" Text="DTU009-Componente sin soldar"></asp:ListItem>
                    <asp:ListItem Value="DTU010-Cables dañados" Text="DTU010-Cables dañados"></asp:ListItem>
                    <asp:ListItem Value="DTU011-Hole tapado" Text="DTU011-Hole tapado"></asp:ListItem>
                    <asp:ListItem Value="DTU012-Exceso de soldadura" Text="DTU012-Exceso de soldadura"></asp:ListItem>
                    <asp:ListItem Value="DTU013-Cables Invertidos" Text="DTU013-Cables Invertidos"></asp:ListItem>
                    <asp:ListItem Value="DTU014-Componente equivocado" Text="DTU014-Componente equivocado"></asp:ListItem>
                    <asp:ListItem Value="DTU015-Pin doblado" Text="DTU015-Pin doblado"></asp:ListItem>
                    <asp:ListItem Value="DTU017-Corto de soldadura" Text="DTU017-Corto de soldadura"></asp:ListItem>
                    <asp:ListItem Value="DTU018-Insuficiencia de Soldadura" Text="DTU018-Insuficiencia de Soldadura"></asp:ListItem>
                    <asp:ListItem Value="DTU019-Componente desprendido" Text="DTU019-Componente desprendido"></asp:ListItem>
                    <asp:ListItem Value="FF0001-Falso Rechazo de equipo" Text="FF0001-Falso Rechazo de equipo"></asp:ListItem>
                    <asp:ListItem Value="FF0002-Falso Rechazo por debugeo de fixture nuevo" Text="FF0002-Falso Rechazo por debugeo de fixture nuevo"></asp:ListItem>
                    <asp:ListItem Value="FF0003-Residuos de potting en cables" Text="FF0003-Residuos de potting en cables"></asp:ListItem>
                    <asp:ListItem Value="FF0004-Falla en el equipo de diagnostico" Text="FF0004-Falla en el equipo de diagnostico"></asp:ListItem>
                    <asp:ListItem Value="FF0005-Falso Rechazo operación" Text="FF0005-Falso Rechazo operación"></asp:ListItem>
                    <asp:ListItem Value="FF0006-Falta de prueba OTP" Text="FF0006-Falta de prueba OTP"></asp:ListItem>
                    <asp:ListItem Value="FF0007-Falso Rechazo de Equipo Output Current" Text="FF0007-Falso Rechazo de Equipo Output Current"></asp:ListItem>
                    <asp:ListItem Value="FF0008-Residuos de potting en conector" Text="FF0008-Residuos de potting en conector"></asp:ListItem>
                    <asp:ListItem Value="FF0009" Text="FF0009-Falso Rechazo por conexión"></asp:ListItem>
                    <asp:ListItem Value="FF0010" Text="FF0010-Falla de dimmimg"></asp:ListItem>
                    <asp:ListItem Value="FF0011" Text="FF0011-Programación de SCARD"></asp:ListItem>
                    <asp:ListItem Value="Otros" Text="Otros"></asp:ListItem>
<%--                    <asp:ListItem Value="FR0012" Text="FR0012-Write current (corriente de escritura)"></asp:ListItem>
                    <asp:ListItem Value="FR0013" Text="FR0013-Turn on time (Tiempo de encendido )"></asp:ListItem>
                    <asp:ListItem Value="FR0014" Text="FR0014-Read and write information"></asp:ListItem>
                    <asp:ListItem Value="FR0015" Text="FR0015-Clean calibration value "></asp:ListItem>
                    <asp:ListItem Value="FR0016" Text="FR0016-Calibrate 10% current "></asp:ListItem>
                    <asp:ListItem Value="FR0017" Text="FR0017-Calibrate current "></asp:ListItem>
                    <asp:ListItem Value="FR0018" Text="FR0018-PF (factor de potencia a alto voltaje)"></asp:ListItem>
                    <asp:ListItem Value="FR0019" Text="FR0019-EFF (eficiencia de voltaje) "></asp:ListItem>
                    <asp:ListItem Value="FR0020" Text="FR0020-PF (factor de potencia a bajo voltaje)"></asp:ListItem>
                    <asp:ListItem Value="FR0021" Text="FR0021-EFF (eficiencia a bajo voltaje) "></asp:ListItem>
                    <asp:ListItem Value="FR0022" Text="FR0022-Output current (corriente de salida)"></asp:ListItem>
                    <asp:ListItem Value="FR0022A" Text="FR0022A-Output current (corriente de salida) POR EQUIPO"></asp:ListItem>
                    <asp:ListItem Value="FR0023" Text="FR0023-No Load Voltage(sin voltaje de carga)"></asp:ListItem>
                    <asp:ListItem Value="FR0024" Text="FR0024-Output voltage( voltaje de salida)"></asp:ListItem>
                    <asp:ListItem Value="FR0025" Text="FR0025-THD(prueba de distorción armonica)"></asp:ListItem>
                    <asp:ListItem Value="FR0026" Text="FR0026-OCP(Protección contra sobrecorriente)"></asp:ListItem>
                    <asp:ListItem Value="FR0027" Text="FR0027-Auxiliary source VCC( voltaje auxiliar de 12V)"></asp:ListItem>
                    <asp:ListItem Value="FR0028" Text="FR0028-Pico de tierra\Entrada - Tierra Verde"></asp:ListItem>
                    <asp:ListItem Value="FR0029" Text="FR0029-AC - Earth (Entrada con tierra Verde)"></asp:ListItem>
                    <asp:ListItem Value="FR0030" Text="FR0030-DC - Earth(Salida-tierra Verde)"></asp:ListItem>
                    <asp:ListItem Value="FR0031" Text="FR0031-AC - DC (Entrada-Salida)"></asp:ListItem>
                    <asp:ListItem Value="FR0032" Text="FR0032-AC - Earth2 (Entrada-Tierra Amarilla)"></asp:ListItem>
                    <asp:ListItem Value="FR0033" Text="FR0033-AC - Earth2 (Medición del Gastube)"></asp:ListItem>
                    <asp:ListItem Value="FF0038" Text="FF0038-Housing sucio "></asp:ListItem>
                    <asp:ListItem Value="FF0039" Text="FF0039-faltante de firmware"></asp:ListItem>--%>
   <%--                 <asp:ListItem Value="DOB001" Text="DOB001-Etiqueta serial invertida"></asp:ListItem>
                    <asp:ListItem Value="DOB002" Text="DOB002-Etiqueta producto"></asp:ListItem>
                    <asp:ListItem Value="DOB003" Text="DOB003-Residuos de potting"></asp:ListItem>
                    <asp:ListItem Value="DOB004" Text="DOB004-Shield Loop mal colocado"></asp:ListItem>
                    <asp:ListItem Value="DOB005" Text="DOB005-Shield Loop dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB006" Text="DOB006-Shield Loop dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB007" Text="DOB007-Housing dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB008" Text="DOB008-Side Case dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB009" Text="DOB009-Tornillo barrido"></asp:ListItem>
                    <asp:ListItem Value="DOB010" Text="DOB010-Tornillo elevado"></asp:ListItem>
                    <asp:ListItem Value="DOB011" Text="DOB011-Tornillo inclinado"></asp:ListItem>
                    <asp:ListItem Value="DOB012" Text="DOB012-Tornillo faltante"></asp:ListItem>
                    <asp:ListItem Value="DOB013" Text="DOB013-Ground Washer floja"></asp:ListItem>
                    <asp:ListItem Value="DOB014" Text="DOB014-Tuerca faltante"></asp:ListItem>
                    <asp:ListItem Value="DOB015" Text="DOB015-cable dañado"></asp:ListItem>
                    <asp:ListItem Value="DOB016" Text="DOB016-Sin serigrafia"></asp:ListItem>
                    <asp:ListItem Value="DOB017" Text="DOB017-serigrafia invertida"></asp:ListItem>
                    <asp:ListItem Value="DOB018" Text="DOB018-Housing barrido"></asp:ListItem>
                    <asp:ListItem Value="DOB019" Text="DOB019-side case equivocado"></asp:ListItem>
                    <asp:ListItem Value="DOB020" Text="DOB020-Hosing rayado"></asp:ListItem>
                    <asp:ListItem Value="DOB021" Text="DOB021-Side case rayada"></asp:ListItem>
                    <asp:ListItem Value="DOB022" Text="DOB022-Side case rayada"></asp:ListItem>
                    <asp:ListItem Value="DOB023" Text="DOB023-Cable expuesto"></asp:ListItem>
                    <asp:ListItem Value="DOB024" Text="DOB024-Falla de proveedor"></asp:ListItem>
                    <asp:ListItem Value="DOB025" Text="DOB025-Housing invertido"></asp:ListItem>--%>
                </asp:DropDownList><br /><br />
                <%--&nbsp;&nbsp;<asp:TextBox ID="txtDiag" runat="server" Text="" Visible="false" ></asp:TextBox><br />--%>
                &nbsp;&nbsp;<asp:TextBox ID="txtLoc" runat="server" Text="" Visible="false" AutoCompleteType="Disabled" Style="text-transform: uppercase" ></asp:TextBox><br /><br />
                <%--<asp:Label ID="Label5" runat="server" Text="" Visible="false"></asp:Label>--%>
                &nbsp;&nbsp;<asp:TextBox ID="txtComments" runat="server" Text="" Visible="false"  TextMode="MultiLine" Rows="6" focus="" AutoCompleteType="Disabled" Style="text-transform: uppercase; "  ></asp:TextBox><br />
            </div>
<%--             <div id="labelo" class="labels">
                <asp:Label ID="Label1" runat="server" Text="Falla:" Visible="false"></asp:Label><br />
                <asp:Label ID="Label2" runat="server" Text="Valor" Visible="false"></asp:Label><br />
            </div>
            <div id="labelp" class="labelr">
                &nbsp;&nbsp;<asp:Label ID="lblFalla" runat="server" Text="" Visible="false" ></asp:Label><br />
                &nbsp;&nbsp;<asp:Label ID="lblValor" runat="server" Text="" Visible="false" ></asp:Label><br />
            </div>--%>
            <br />
            <div class="btns-salida">
                <br />
                <br />
                <div>
                 <asp:LinkButton runat="server" ID="btnSave" Text="" CssClass="btn3 btn-success    d-block p-2 " Font-Size="20px" Visible="false"  AutoPostBack="true" OnClick="btnSave_Click" >
                 <span class="fas fa-save font-weight-bold" aria-hidden="true"></span> &nbsp;GUARDAR
                 </asp:LinkButton>
                    <br />
                </div>

                <div>
                    <asp:LinkButton runat="server" ID="btnCancel" Text="" CssClass="btn3 btn-danger   d-block p-2 " Font-Size="20px" Visible="false" Onclick="btnCancel_Click" >
                 <span class="fas fa-eraser font-weight-bold" aria-hidden="true"></span>CANCELAR
                        </asp:LinkButton>
                </div>
            </div>

        </div>
        <div class="result mx-auto">
            <asp:Label runat="server" Text="" ID="res"   Visible="false"></asp:Label><br />
            <asp:Label runat="server" Text="" ID="desc"  Visible="false"></asp:Label>
        </div>

        <div id="nav-user" class="mx-auto" style="width: 1100px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="userlbl" runat="server" Text="Usuario:"></asp:Label>
            <asp:Label ID="userlabel" runat="server" Text=""></asp:Label>
        </div>

        <asp:LinkButton CssClass="btnLogout" runat="server" PostBackUrl="~/Menu.aspx">
                <span class="fas fa-backspace" aria-hidden="true"></span> &nbsp;Menú
        </asp:LinkButton>

        <asp:LinkButton CssClass="btnLogout2" runat="server" PostBackUrl="~/Login.aspx">
                <span class="fas fa-sign-out-alt" aria-hidden="true"></span> 
        </asp:LinkButton>
    </form>
</body>
</html>
