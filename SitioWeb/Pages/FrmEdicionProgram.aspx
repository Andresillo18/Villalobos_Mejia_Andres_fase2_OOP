<%@ Page Title="Mantenimiento de Programas" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="FrmEdicionProgram.aspx.cs" Inherits="SitioWeb.Pages.FrmEdicionProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1 class="subTitulos">Ingreso o modificación de Programas</h1>
    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodPrograma" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodPrograma" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" TabIndex="1"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblDescripcion" runat="server" Text="Descripción: "></asp:Label>
                <asp:TextBox ID="txtDescripcion" class="textBoxBig" runat="server" TabIndex="2"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto Estado" ID="lblEstado" runat="server" Text="Estado: "></asp:Label>
                <asp:RadioButton ID="RBActivo" class="texto" runat="server" GroupName="Estado" Text="Activo" TabIndex="3" />
                <asp:RadioButton ID="RBInactivo" class="texto" runat="server" GroupName="Estado" Text="Inactivo" />
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblObservaciones" runat="server" Text="Observaciones: "></asp:Label>
                <asp:TextBox ID="txtObservaciones" class="textBoxBig" runat="server" TabIndex="4"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button class="btn btn-danger" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
