<%@ Page Title="Mantenimiento de Módulos" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="mantenimientoModulos.aspx.cs" Inherits="SitioWeb.Pages.mantenimientoModulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1 class="subTitulos">Ingreso o modificación de Módulos</h1>
    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodModulo" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodModulo" runat="server" ReadOnly="True"></asp:TextBox>
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
                <asp:Label class="texto" ID="lblHoras" runat="server" Text="Horas de Duración: "></asp:Label>
                <asp:DropDownList ID="cboHoras" runat="server" TabIndex="2">
                    <asp:ListItem>80</asp:ListItem>
                    <asp:ListItem>110</asp:ListItem>
                    <asp:ListItem>120</asp:ListItem>
                    <asp:ListItem>90</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto Estado" ID="lblRequesitos" runat="server" Text="Requesitos: "></asp:Label>
              <asp:TextBox ID="txtRequesitos" class="textBoxBig" runat="server" TabIndex="3"></asp:TextBox>  
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
