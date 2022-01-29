<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="horarioModulo.aspx.cs" Inherits="SitioWeb.Pages.horarioModulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2 class="subTitulos">Creación de Horarios para Módulos</h2>
     <asp:Button class="nuevoRegistro" runat="server" Text="Agregar Horario" ID="btnAgregar" OnClick="btnAgregar_Click" />
        <asp:GridView class="grdLista" ID="grdModulos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EmptyDataText="No hay registros para mostrar" Height="135px" ShowHeaderWhenEmpty="True" Width="100%" GridLines="Horizontal" OnPageIndexChanging="grdLista_PageIndexChanging" PageSize="8">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("COD_HORARIO_MODULOS").ToString() %>' CommandName="Modificar" Font-Underline="True" ForeColor="Black" OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("COD_HORARIO_MODULOS").ToString() %>' CommandName="Eliminar" ForeColor="Black" OnCommand="lnkEliminar_Command">Eliminar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DIA_LUNES" HeaderText="Día Lunes" />
            <asp:BoundField DataField="DIA_MARTES" HeaderText="Día Martes" />
            <asp:BoundField DataField="DIA_MIERCOLES" HeaderText="Día Miércoles" />
            <asp:BoundField DataField="DIA_JUEVES" HeaderText="Día Jueves" />
            <asp:BoundField DataField="DIA_VIERNES" HeaderText="Día Viernes" />
            <asp:BoundField DataField="DIA_SABADO" HeaderText="Día Sabado" />
            <asp:BoundField DataField="DIA_DOMINGO" HeaderText="Día Domingo" />
            <asp:BoundField DataField="HORA_INICIO_HORARIO" HeaderText="Hora Inicio" />
            <asp:BoundField DataField="HORA_FIN_HORARIO" HeaderText="Hora Final" />
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
