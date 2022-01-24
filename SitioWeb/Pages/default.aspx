<%@ Page Title="Programas" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SitioWeb._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h2 class="subTitulos">Creación de programas</h2>

    <p class="texto">Nombre del Programa:</p>
    <asp:TextBox ID="txtPrograma" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />

    <asp:GridView class="grdLista" ID="grdLista" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EmptyDataText="No hay registros para mostrar" Height="135px" ShowHeaderWhenEmpty="True" Width="100%" GridLines="Horizontal">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("COD_PROGRAMA").ToString() %>' CommandName="Modificar" Font-Underline="True" ForeColor="Black">Modificar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("COD_PROGRAMA").ToString() %>' CommandName="Eliminar" Font-Underline="True" ForeColor="Black">Eliminar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NOMBRE_PROGRAMA" HeaderText="Nombre" />
            <asp:BoundField DataField="DESCRIPCION_PROGRAMA" HeaderText="Descripción" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
            <asp:BoundField DataField="CUPO_PROGRAMA" HeaderText="Cupo" />
            <asp:BoundField DataField="TELEFONO_PROGRAMA" HeaderText="Teléfono" />
            <asp:BoundField DataField="EMAIL_PROGRAMA" HeaderText="Email" />
            <asp:BoundField DataField="PROVINCIA_PROGRAMA" HeaderText="Provincia" />
            <asp:BoundField DataField="FECHA_INICIO_PROGRAMA" HeaderText="Fecha de Inicio" ApplyFormatInEditMode="True" DataFormatString="{0:D}" />
            <asp:BoundField DataField="FECHA_FIN_PROGRAMA" HeaderText="Fecha de Fin" />
            <asp:BoundField DataField="OBSERVACIONES_PROGRAMA" HeaderText="Observaciones" />
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
