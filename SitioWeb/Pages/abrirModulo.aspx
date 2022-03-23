<%@ Page Title="Abrir Módulos" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="abrirModulo.aspx.cs" Inherits="SitioWeb.Pages.abrirModulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2 class="subTitulos">Apertura de Módulos</h2>
    <p class="texto">Fecha de Inicio:</p>
     <asp:TextBox ID="txtModuloAbierto" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />

    <asp:Button class="nuevoRegistro" runat="server" Text="Agregar Módulo" ID="btnAgregar" OnClick="btnAgregar_Click" />

    <asp:GridView class="grdLista" ID="grdModulos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EmptyDataText="No hay registros para mostrar" Height="135px" ShowHeaderWhenEmpty="True" Width="100%" GridLines="Horizontal" OnPageIndexChanging="grdLista_PageIndexChanging" PageSize="6">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("COD_MODULO_ABIERTO").ToString() %>' CommandName="Modificar" Font-Underline="True" ForeColor="Black" OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("COD_MODULO_ABIERTO").ToString() %>' CommandName="Eliminar" ForeColor="Black" OnCommand="lnkEliminar_Command">Eliminar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="COD_ENTRENADOR" HeaderText="Cod Entrenador" />
            <asp:BoundField DataField="COD_MODULO" HeaderText="Cod Módulo" />
            <asp:BoundField DataField="COD_HORARIO_MODULOS" HeaderText="Cod Horario de Módulos" />
            <asp:BoundField DataField="FECHA_INICIO_MODULO" HeaderText="Fecha Inicio" DataFormatString="{0:d}" />
            <asp:BoundField DataField="FECHA_FINAL_MODULO" HeaderText="Fecha Fin" DataFormatString="{0:d}" />
            <asp:BoundField DataField="OBSERVACIONES_MODULO_ABIERTO" HeaderText="Observaciones" />
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
