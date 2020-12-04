<%@ Page Title="Ventas canceladas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentasCanceladas.aspx.cs" Inherits="WebForm.VentasCanceladas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Ventas canceladas</h2>
    </div>
    <hr />
    <div class="form-group">
        <a href="Ventas.aspx" class="btn btn-primary">Volver</a>
    </div>
    <hr />
    <asp:GridView class="table table-striped table-dark border-dark" DataKeyNames="ID" ID="dgvVentas" AutoGenerateColumns="False" OnRowCommand="dgvVentas_RowCommand" runat="server" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" ReadOnly="true">
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
