<%@ Page Title="Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraListado.aspx.cs" Inherits="WebForm.CompraListado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listado de Compras</h2>
    <hr />

    <div class="form-group">
        <a href="/" class="btn btn-primary">Volver</a>
        <asp:Button ID="btn" class="btn btn-primary" Text="" runat="server" />
    </div>
    <hr />
    <asp:GridView class="table table-striped table-dark border-dark" DataKeyNames="ID" ID="dgvCompra" AutoGenerateColumns="False" OnRowCommand="dgvCompra_RowCommand" runat="server" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" ReadOnly="true">
                <HeaderStyle CssClass="oculto"/>
                <ItemStyle CssClass="oculto"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="IdCarrito" DataField="IdCarrito" ReadOnly="true">
                <HeaderStyle CssClass="oculto"/>
                <ItemStyle CssClass="oculto"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Estado" DataField="Estado" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Fecha Compra" DataField="FechaCompra" DataFormatString="{0:g}" ReadOnly="true">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Fecha Entrega" DataField="FechaEntrega" DataFormatString="{0:d}" ReadOnly="true">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="$ {0}" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:BoundField>
            <asp:ButtonField HeaderText="Detalles" ButtonType="Button" Text="Detalles" CommandName="Select">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
