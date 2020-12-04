<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebForm.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Ventas</h2>
    </div>
    <hr />
    <div class="form-group">
        <a href="/" class="btn btn-primary">Volver</a>
        <asp:Button class="btn btn-primary" ID="btnListado" Text="Ver listado de productos" OnClick="btnListado_Click" runat="server" />
        <asp:Button class="btn btn-primary" ID="btnEdicion" Text="Editar elementos" OnClick="btnEdicion_Click" runat="server" />
        <a href="VentasCanceladas.aspx" class="btn btn-primary">Ventas Canceladas</a>
    </div>
    <hr />
    <asp:GridView class="table table-striped table-dark border-dark" DataKeyNames="ID" ID="dgvVentas" AutoGenerateColumns="False" OnRowCommand="dgvVentas_RowCommand" runat="server" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" ReadOnly="true">
                <HeaderStyle CssClass="oculto"/>
                <ItemStyle CssClass="oculto"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="IdCarrito" DataField="IdCarrito" ReadOnly="true">
                <HeaderStyle CssClass="oculto"/>
                <ItemStyle CssClass="oculto"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Dirección" DataField="Direccion" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Estado" DataField="Estado" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Fecha Compra" DataField="FechaCompra" DataFormatString="{0:g}" ReadOnly="true">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Metodo Compra" DataField="MetodoCompra" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="$ {0}" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Metodo Envio" DataField="MetodoEnvio" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Fecha Entrega" DataField="FechaEntrega" DataFormatString="{0:d}" ReadOnly="true">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:ButtonField HeaderText="Opcion" ButtonType="Button" Text="Detalles" CommandName="Select">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
