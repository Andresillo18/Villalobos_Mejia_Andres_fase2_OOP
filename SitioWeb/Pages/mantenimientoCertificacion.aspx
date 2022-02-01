<%@ Page Title="Mantenimiento de Certificados" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="mantenimientoCertificacion.aspx.cs" Inherits="SitioWeb.Pages.mantenimientoCertificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h1 class="subTitulos">Ingreso o modificación de Certificaciones</h1>
    <div class="container">

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodCertificacion" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodCertificacion" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodEntrenador" runat="server" Text="COD del Entrenador: "></asp:Label>
                <asp:TextBox ID="txtCodEntrenador" runat="server" TabIndex="1"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:CheckBox ID="CBGimnasio" runat="server" ForeColor="White" Text="Gimnasio" ValidationGroup="gimnasio" TabIndex="2" />
            </div>
            <div class="col-4">
                <asp:CheckBox ID="CBNatacion" runat="server" ForeColor="White" Text="Natación" ValidationGroup="natacion" TabIndex="3" />
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:CheckBox ID="CBMaraton" runat="server" ForeColor="White" Text="Maratón" ValidationGroup="maraton" TabIndex="4" />
            </div>
            <div class="col-4">
                <asp:CheckBox ID="CBCiclismo" runat="server" ForeColor="White" Text="Ciclismo" ValidationGroup="ciclismo" TabIndex="5" />
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
