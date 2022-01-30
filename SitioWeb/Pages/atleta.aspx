<%@ Page Title="Atletas" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="atleta.aspx.cs" Inherits="SitioWeb.Pages.atleta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <h2 class="subTitulos">Ingreso de Entrenadores</h2>

    <p class="texto">Nombre del Entrenador:</p>
    <asp:TextBox ID="txtAtleta" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />

    <asp:Button class="nuevoRegistro" runat="server" Text="Agregar Atleta" ID="btnAgregar" OnClick="btnAgregar_Click" />

    <asp:GridView class="grdLista" ID="grdAtletas" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EmptyDataText="No hay registros para mostrar" Height="135px" ShowHeaderWhenEmpty="True" Width="100%" GridLines="Horizontal" PageSize="8" OnPageIndexChanging="grdAtletas_PageIndexChanging">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("COD_ATLETA").ToString() %>' CommandName="Modificar" Font-Underline="True" ForeColor="Black" OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("COD_ATLETA").ToString() %>' CommandName="Eliminar" ForeColor="Black" OnCommand="lnkEliminar_Command">Eliminar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID_ATLETA" HeaderText="ID" />
            <asp:BoundField DataField="NOMBRE_ATLETA" HeaderText="Nombre" />
            <asp:BoundField DataField="APELLIDO1_ATLETA" HeaderText="Apellido 1" />
            <asp:BoundField DataField="APELLIDO2_ATLETA" HeaderText="Apellido 2" />
            <asp:BoundField DataField="TELEFONO1_ATLETA" HeaderText="Teléfono 1" />
            <asp:BoundField DataField="TELEFONO2_ATLETA" HeaderText="Teléfono 2" />
            <asp:BoundField DataField="GENERO" HeaderText="Genero" />
            <asp:BoundField DataField="PROVINCIA_ATLETA" HeaderText="Provincia" />
            <asp:BoundField DataField="DISTRITO_ATLETA" HeaderText="Distrito" />
            <asp:BoundField DataField="CANTON_ATLETA" HeaderText="Cantón" />
            <asp:BoundField DataField="FECHA_NACIMIENTO_ATLETA" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
            <asp:BoundField DataField="ESTADO_ATLETA" HeaderText="Estado" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
