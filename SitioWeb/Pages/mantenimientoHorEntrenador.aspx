<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="mantenimientoHorEntrenador.aspx.cs" Inherits="SitioWeb.Pages.mantenimientoHorEntrenador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1 class="subTitulos">Ingreso o modificación de Horarios de Módulos</h1>
    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodHoraEntrenador" runat="server" Text="COD: "></asp:Label>
                <asp:TextBox ID="txtCodHoraEntrenador" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label class="texto" ID="lblCodEntrenador" runat="server" Text="COD del Entrenador: "></asp:Label>
                <asp:TextBox ID="txtCodEntrenador" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:CheckBox ID="CBLunes" runat="server" ForeColor="White" Text="Lunes" ValidationGroup="lunes" TabIndex="1" />
            </div>
            <div class="col-4">
                <asp:CheckBox ID="CBMartes" runat="server" ForeColor="White" Text="Martes" ValidationGroup="martes" TabIndex="2" />
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:CheckBox ID="CBMiercoles" runat="server" ForeColor="White" Text="Miércoles" ValidationGroup="miercoles" TabIndex="3" />
            </div>
            <div class="col-4">
                <asp:CheckBox ID="CBJueves" runat="server" ForeColor="White" Text="Jueves" ValidationGroup="jueves" TabIndex="4" />
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:CheckBox ID="CBViernes" runat="server" ForeColor="White" Text="Viernes" ValidationGroup="viernes" TabIndex="5" />
            </div>
            <div class="col-4">
                <asp:CheckBox ID="CBSabado" runat="server" ForeColor="White" Text="Sabado" ValidationGroup="sabado" TabIndex="6" />
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:CheckBox ID="CBDomingo" runat="server" ForeColor="White" Text="Domingo" ValidationGroup="domingo" TabIndex="7" />
            </div>
        </div>


        <div class="row">
            <div class="col-4">
                <asp:Label ID="lblHoraInicio" class="texto" runat="server" Text="Hora de Inicio: "></asp:Label>
                <asp:TextBox ID="txtTimeStart" runat="server" TabIndex="8"></asp:TextBox>
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
                <asp:TextBox ID="txtTimeEnd" runat="server" TabIndex="9"></asp:TextBox>
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
            <div class="col-4">
                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button class="btn btn-danger" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
