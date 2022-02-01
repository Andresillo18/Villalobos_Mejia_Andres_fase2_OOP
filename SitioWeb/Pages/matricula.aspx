<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="matricula.aspx.cs" Inherits="SitioWeb.Pages.matricula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

      <h2 class="subTitulos">Creación de Matrículas</h2>    

    <asp:Button class="nuevoRegistro" runat="server" Text="Registrar Matrícula" ID="btnAgregar" OnClick="btnAgregar_Click" />

    <asp:GridView class="grdLista" ID="grdMatriculas" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EmptyDataText="No hay registros para mostrar" Height="135px" ShowHeaderWhenEmpty="True" Width="100%" GridLines="Horizontal" OnPageIndexChanging="grdLista_PageIndexChanging" PageSize="6">
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
            <asp:BoundField DataField="COD_ATLETA" HeaderText="Cod Atleta" />
            <asp:BoundField DataField="COD_MODULO_ABIERTO" HeaderText="Cod Módulo Abierto" />
            <asp:BoundField DataField="FECHA_MATRICULA" HeaderText="Fecha Matriculada" DataFormatString="{0:d}" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
            <asp:BoundField DataField="NOTA_FINAL" HeaderText="Nota Final" />
            <asp:BoundField DataField="MONTO_CANCELADO" HeaderText="Monto Cancelado" />
            <asp:BoundField DataField="TIPO_COBRO" HeaderText="Tipo de Cobro" />
            <asp:BoundField DataField="TIPO_PAGO" HeaderText="Tipo de Pago" />
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
