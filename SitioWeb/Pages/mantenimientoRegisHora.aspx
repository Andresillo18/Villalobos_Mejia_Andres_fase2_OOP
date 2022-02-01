<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="mantenimientoRegisHora.aspx.cs" Inherits="SitioWeb.Pages.mantenimientoRegisHora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style1 {
            flex: 0 0 auto;
            width: 33.33333333%;
            margin-left: 40px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <h1 class="subTitulos">Ingreso o modificación de Horarios de Módulos</h1>
    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodRegHoras" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodRegHoras" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodEntrenador" runat="server" Text="COD del Entrenador: "></asp:Label>
                <asp:TextBox ID="txtCodEntrenador" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="auto-style1">
                <asp:Label class="texto" ID="lblDiaRegistro" runat="server" Text="Fecha Registrado: "></asp:Label>
                <%--Se usa un calendario de asp--%>
                <asp:Calendar ID="CalDiaRegistro" runat="server" BackColor="Black" BorderColor="White" BorderWidth="1px" class="calendario" Font-Names="Verdana" Font-Size="9pt" ForeColor="White" Height="190px" NextPrevFormat="FullMonth" TabIndex="4" Width="314px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>

            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label ID="lblHoraInicio" class="texto" runat="server" Text="Hora de Inicio: "></asp:Label>
                <asp:TextBox ID="txtTimeStart" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="regextxtSessionTime" runat="server"
                    ControlToValidate="txtTimeStart"
                    ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$"
                    ErrorMessage="* Debes ingresar un tiempo valido. Format: HH:MM:SS"
                    Display="Dynamic"
                    SetFocusOnError="true" class="texto"></asp:RegularExpressionValidator>
            </div>

            <div class="col-4">
                <asp:Label ID="lblHoraFin" class="texto" runat="server" Text="Hora de Fin: "></asp:Label>
                <asp:TextBox ID="txtTimeEnd" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="txtTimeEnd"
                    ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$"
                    ErrorMessage="* Debes ingresar un tiempo valido. Formato: HH:MM:SS"
                    Display="Dynamic"
                    SetFocusOnError="true" class="texto"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row">
            <div class="auto-style1">
                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button class="btn btn-danger" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
