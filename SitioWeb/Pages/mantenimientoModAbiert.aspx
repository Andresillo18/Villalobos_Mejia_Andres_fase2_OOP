<%@ Page Title="Mantenimiento Mod Abiertos" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="mantenimientoModAbiert.aspx.cs" Inherits="SitioWeb.Pages.mantenimientoModAbiert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            flex: 0 0 auto;
            width: 33%
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1 class="subTitulos">Ingreso o modificación de Módulos</h1>
    <div class="container">
        <div class="row">
            <div class="col-4">                
                <asp:Label class="texto" ID="lblCodModulo" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodModAbiert" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <asp:HyperLink class="texto" ID="HLCodEntrenador" runat="server" ToolTip="Si presiona aquí podrá ver la referencia a los Entrenadores para saber cuál es su código" Text="Cod Entrenador: "></asp:HyperLink>
                <asp:TextBox ID="txtCodEntrenador" runat="server" TabIndex="1"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <asp:HyperLink class="texto" ID="HLCodMod" runat="server" NavigateUrl="~/Pages/modulo.aspx" ToolTip="Si presiona aquí podrá ver la referencia a los Módulos para saber cuál es su código" Text="Cod Módulo: "></asp:HyperLink>                
                <asp:TextBox ID="txtCodMod" runat="server" TabIndex="2"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:HyperLink class="texto" ID="HLCodHor" runat="server" ToolTip="Si presiona aquí podrá ver la referencia a los Horarios para saber cuál es su código" Text="Cod Horario: "></asp:HyperLink>
                <asp:TextBox ID="txtCodHorMod" runat="server" TabIndex="3"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="auto-style1">
                <asp:Label class="texto" ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                <%--Se usa un calendario de asp--%>
                <asp:Calendar ID="CalFechaInicio" runat="server" BackColor="Black" BorderColor="White" BorderWidth="1px" class="calendario" Font-Names="Verdana" Font-Size="9pt" ForeColor="White" Height="190px" NextPrevFormat="FullMonth" TabIndex="4" Width="314px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>

            </div>

            <%--El primer calendario estan en la fila del primero con diferente cantidad de columnas--%>
            <%--     <div class="col-2">
                <asp:Label class="texto" ID="lblFechaFin" runat="server" Text="Fecha Fin: "></asp:Label>
                <asp:Calendar class="calendario" ID="CalFechaFin" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="44px" TabIndex="4" Width="100px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </div>--%>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblObservaciones" runat="server" Text="Observaciones: "></asp:Label>
                <asp:TextBox ID="txtObservaciones" runat="server" TabIndex="1" Height="81px" Width="240px"></asp:TextBox>
            </div>

            <div class="col-4">
                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button class="btn btn-danger" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
