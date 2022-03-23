<%@ Page Title="Entrenadors" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="entrenador.aspx.cs" Inherits="SitioWeb.Pages.entrenador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <h2 class="subTitulos">Ingreso de Entrenadores</h2>

    <p class="texto">Nombre del Entrenador:</p>
    <asp:TextBox ID="txtEntrenador" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />

    <asp:Button class="nuevoRegistro" runat="server" Text="Agregar Entrenador" ID="btnAgregar" OnClick="btnAgregar_Click" />

    <asp:GridView class="grdLista" ID="grdEntrenadores" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EmptyDataText="No hay registros para mostrar" Height="135px" ShowHeaderWhenEmpty="True" Width="100%" GridLines="Horizontal" OnPageIndexChanging="grdLista_PageIndexChanging" PageSize="8">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("COD_ENTRENADOR").ToString() %>' CommandName="Modificar" Font-Underline="True" ForeColor="Black" OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("COD_ENTRENADOR").ToString() %>' CommandName="Eliminar" ForeColor="Black" OnCommand="lnkEliminar_Command">Eliminar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID_ENTRENADOR" HeaderText="ID" />
            <asp:BoundField DataField="NOMBRE_ENTRENADOR" HeaderText="Nombre" />
            <asp:BoundField DataField="APELLIDO1_ENTRENADOR" HeaderText="Apellido 1" />
            <asp:BoundField DataField="APELLIDO2_ENTRENADOR" HeaderText="Apellido 2" />
            <asp:BoundField DataField="TELEFONO1_ENTRENADOR" HeaderText="Teléfono 1" />
            <asp:BoundField DataField="TELEFONO2_ENTRENADOR" HeaderText="Teléfono 2" />
            <asp:BoundField DataField="CORREO_ENTRENADOR" HeaderText="Correo" />
            <asp:BoundField DataField="FECHA_NACIMIENTO_ENTRENADOR" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
            <asp:BoundField DataField="PROVINCIA_ENTRENADOR" HeaderText="Provincia" />
            <asp:BoundField DataField="DISTRITO_ENTRENADOR" HeaderText="Distrito" />
            <asp:BoundField DataField="CANTON_ENTRENADOR" HeaderText="Cantón" />
            <asp:BoundField DataField="ESTADO_ENTRENADOR" HeaderText="Estado" />
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
