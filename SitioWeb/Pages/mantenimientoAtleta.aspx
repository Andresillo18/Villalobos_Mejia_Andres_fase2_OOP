<%@ Page Title="Mantenimiento de Atletas" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="mantenimientoAtleta.aspx.cs" Inherits="SitioWeb.Pages.mantenimientoAtleta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

     <h1 class="subTitulos">Ingreso o modificación de Atletas</h1>
    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodEntrenador" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodEntrenador" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblId" runat="server" Text="ID: "></asp:Label>
                <asp:TextBox ID="txtIdEntrenador" runat="server" TabIndex="1" MaxLength="30"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" TabIndex="2" MaxLength="20"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblApellido1" runat="server" Text="Apellido 1: "></asp:Label>
                <asp:TextBox ID="txtApellido1" runat="server" TabIndex="3"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:Label class="texto" ID="lblApellido2" runat="server" Text="Apellido 2: "></asp:Label>
                <asp:TextBox ID="txtApellido2" runat="server" TabIndex="4" MaxLength="20"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblTelefono1" runat="server" Text="Teléfono 1: "></asp:Label>
                <asp:TextBox ID="txtTelefono1" runat="server" TabIndex="5" MaxLength="15"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:Label class="texto" ID="lblTelefono2" runat="server" Text="Teléfono 2: "></asp:Label>
                <asp:TextBox ID="txtTelefono2" runat="server" TabIndex="6" MaxLength="15"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCorreo" runat="server" Text="Correo: "></asp:Label>
                <asp:DropDownList ID="CBGenero" runat="server">
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="auto-style1">
                <asp:Label class="texto" ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                <%--Se usa un calendario de asp--%>
                <asp:Calendar ID="CalFechaNacimiento" runat="server" BackColor="Black" BorderColor="White" BorderWidth="1px" class="calendario" Font-Names="Verdana" Font-Size="9pt" ForeColor="White" Height="190px" NextPrevFormat="FullMonth" TabIndex="8" Width="314px">
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
                <asp:Label class="texto" ID="lblProvincia" runat="server" Text="Provincia: "></asp:Label>                
                <asp:DropDownList ID="CBProvincia" TabIndex="9" runat="server">
                    <asp:ListItem>Alajuela</asp:ListItem>
                    <asp:ListItem>San José</asp:ListItem>
                    <asp:ListItem>Guanacaste</asp:ListItem>
                    <asp:ListItem>Puntarenas</asp:ListItem>
                    <asp:ListItem>Heredia</asp:ListItem>
                    <asp:ListItem>Cartago</asp:ListItem>
                    <asp:ListItem>Limón</asp:ListItem>
                </asp:DropDownList>
            </div>

               <div class="col-4">
                <asp:Label class="texto" ID="lblDistrito" runat="server" Text="Distrito: "></asp:Label>
                <asp:TextBox ID="txtDistrito" runat="server" TabIndex="10" MaxLength="20"></asp:TextBox>
            </div>

               <div class="col-4">
                <asp:Label class="texto" ID="lblCanton" runat="server" Text="Cantón: "></asp:Label>
                <asp:TextBox ID="txtCanton" runat="server" TabIndex="11" MaxLength="20"></asp:TextBox>
            </div>

        </div>

        <div class="row">
            <div class="col-4">
                <%--Se usa el estado para saber si existe, remplazo del atributo "existe"--%>
                <asp:Label class="texto" ID="lblEstadp" runat="server" Text="Estado: "></asp:Label>
                <asp:RadioButton ID="RBActivo" runat="server" ForeColor="White" Text="Activo" ValidationGroup="estado" TabIndex="12" />
                <asp:RadioButton ID="RBInactivo" runat="server" ForeColor="White" Text="Inactivo" ValidationGroup="estado" />
            </div>
        </div>
        <div class="col-4">
            <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button class="btn btn-danger" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
