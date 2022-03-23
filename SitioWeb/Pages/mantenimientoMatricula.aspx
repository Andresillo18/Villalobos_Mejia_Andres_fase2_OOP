<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="mantenimientoMatricula.aspx.cs" Inherits="SitioWeb.Pages.mantenimientoMatricula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h1 class="subTitulos">Ingreso o modificación de Módulos</h1>
    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodMatricula" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodMatricula" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <asp:HyperLink class="texto" ID="HLCodAtleta" runat="server" ToolTip="Si presiona aquí podrá ver la referencia a los Atletas para saber cuál es su código" Text="Cod Atleta: " NavigateUrl="~/Pages/atleta.aspx"></asp:HyperLink>
                <asp:TextBox ID="txtCodAtleta" runat="server" TabIndex="1"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <asp:HyperLink class="texto" ID="HLCodModAbiert" runat="server" NavigateUrl="~/Pages/abrirModulo.aspx" ToolTip="Si presiona aquí podrá ver la referencia a los Módulos Abiertos para saber cuál es su código" Text="Cod Módulo Abierto: "></asp:HyperLink>
                <asp:TextBox ID="txtCodModAbiert" runat="server" TabIndex="2"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="auto-style1">
                <asp:Label class="texto" ID="lblFechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                <asp:TextBox ID="CalFechaMatricula" runat="server" TextMode="Date"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblEstado" runat="server" Text="Estado: "></asp:Label>
                <asp:DropDownList ID="CBEstado" runat="server" TabIndex="4">
                    <asp:ListItem>En curso</asp:ListItem>
                    <asp:ListItem>Abandonó</asp:ListItem>
                    <asp:ListItem>Aprovado</asp:ListItem>
                    <asp:ListItem>Reprobado</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

          <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblNotaFinal" runat="server" Text="Nota Final: "></asp:Label>
                <asp:TextBox ID="txtNotaFinal" runat="server" TabIndex="5" MaxLength="100" TextMode="Number" ValidateRequestMode="Enabled">0</asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblMontoCancelado" runat="server" Text="Monto Cancelado: "></asp:Label>
                <asp:TextBox ID="txtMontoCancelado" runat="server" TabIndex="6" TextMode="Number" ValidateRequestMode="Enabled"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblTipoCobro" runat="server" Text="Estado: "></asp:Label>
                <asp:DropDownList ID="CBTipoCobro" runat="server" TabIndex="7">
                    <asp:ListItem>Curso Y Matricula</asp:ListItem>
                    <asp:ListItem>Curso</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblTipoPago" runat="server" Text="Tipo de Pago: "></asp:Label>
                <asp:DropDownList ID="CBTipoPago" runat="server" TabIndex="8">
                    <asp:ListItem>Transferencia</asp:ListItem>
                    <asp:ListItem>Sinpe</asp:ListItem>
                    <asp:ListItem>Tarjeta</asp:ListItem>
                    <asp:ListItem>Efectivo</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button class="btn btn-danger" ID="Button2" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
