<%@ Page Title="Mantenimiento Mod Abiertos" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="mantenimientoModAbiert.aspx.cs" Inherits="SitioWeb.Pages.mantenimientoModAbiert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1 class="subTitulos">Ingreso o modificación de Módulos</h1>
    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:MultiView ID="MultiView1" runat="server"></asp:MultiView>
                <asp:Label class="texto" ID="lblCodModulo" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodModulo" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodEntrenador" runat="server" Text="Cod Entrenador: "></asp:Label>
                <asp:TextBox ID="txtCodEntrenador" runat="server" TabIndex="1"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodMod" runat="server" Text="Cod Módulo: "></asp:Label>
                <asp:TextBox ID="txtCodMod" runat="server" TabIndex="2"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodHor" runat="server" Text="Cod Horario: "></asp:Label>
                <asp:TextBox ID="txtCodHorMod" runat="server" TabIndex="3"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-2">
                <asp:Label class="texto" ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                <asp:Calendar class="calendario" ID="CalFechaInicio" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="44px" TabIndex="4" Width="100px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
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
                <asp:TextBox ID="txtObservaciones" runat="server" TabIndex="1"></asp:TextBox>
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
