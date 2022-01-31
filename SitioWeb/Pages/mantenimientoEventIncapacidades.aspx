<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="mantenimientoEventIncapacidades.aspx.cs" Inherits="SitioWeb.Pages.mantenimientoEventIncapacidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h1 class="subTitulos">Ingreso o modificación de Incapacitaciones o Eventos</h1>
    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodIncapEvent" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodIncapEvent" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodEntrenador" runat="server" Text="COD del Entrenador: "></asp:Label>
                <asp:TextBox ID="txtCodEntrenador" runat="server" TabIndex="1"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="auto-style1">
                <asp:Label class="texto" ID="lblDiaInicio" runat="server" Text="Día Inicio: "></asp:Label>
                <%--Se usa un calendario de asp --%>
                <asp:Calendar ID="CalDiaInicio" runat="server" BackColor="Black" BorderColor="White" BorderWidth="1px" class="calendario" Font-Names="Verdana" Font-Size="9pt" ForeColor="White" Height="190px" NextPrevFormat="FullMonth" TabIndex="2" Width="314px">
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
            <div class="auto-style1">
                <asp:Label class="texto" ID="lblDiaFin" runat="server" Text="Día Final: "></asp:Label>
                <%--Se usa un calendario de asp--%>
                <asp:Calendar ID="CalDiaFin" runat="server" BackColor="Black" BorderColor="White" BorderWidth="1px" class="calendario" Font-Names="Verdana" Font-Size="9pt" ForeColor="White" Height="190px" NextPrevFormat="FullMonth" TabIndex="3" Width="314px">
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
                <asp:Label class="texto" ID="lblObservaciones" runat="server" Text="Observaciones: "></asp:Label>
                <asp:TextBox ID="txtObservaciones" class="textBoxBig" runat="server" TabIndex="4" MaxLength="500"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button class="btn btn-danger" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
