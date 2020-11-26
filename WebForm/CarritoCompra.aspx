<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarritoCompra.aspx.cs" Inherits="WebForm.CarritoCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--stilo css para ocultar columna en grid view--%>
    <style>
        .oculto {
            display: none;
        }
    </style>
    <div>
        <h2>Carrito</h2>
    </div>
    <hr />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row">
                <div class="form-group">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <a href="/" class="btn btn-primary">Seguir Comprando</a>
                        <asp:Button class="btn btn-primary" ID="btnCarritoVaciar" Text="Vaciar Carrito" OnClick="btnCarritoVaciar_Click" runat="server" />
                        <asp:Button class="btn btn-primary" ID="btnComprar" Text="Comprar" OnClick="btnComprar_Click" Visible="false" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblImporte" CssClass="form-control" runat="server" />
                </div>
            </div>
            <hr />
            <asp:GridView class="table" ID="dgvCarrito" AutoPostBack="true" AutoGenerateColumns="False" runat="server" OnRowCommand="dgvCarrito_RowCommand" CellPadding="0" EditIndex="0" SelectedIndex="0">
                <Columns>
                    <asp:ImageField HeaderText="Imagen" ControlStyle-Height="150px" ControlStyle-Width="150px" DataImageUrlField="ImagenUrl" ItemStyle-CssClass="img-fluid" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                    <asp:BoundField HeaderText="Cantidad" ItemStyle-VerticalAlign="Middle" DataField="Cantidad" ReadOnly="true" />
                    <asp:ButtonField HeaderText="Eliminar" ItemStyle-VerticalAlign="Middle" ButtonType="Button" Text="Eliminar" CommandName="Select" />
                    <asp:BoundField HeaderText="ID" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" DataField="ID" ReadOnly="true" />
                    <asp:BoundField HeaderText="Producto" ItemStyle-VerticalAlign="Middle" DataField="Producto" ReadOnly="true" />
                    <asp:BoundField HeaderText="Descripción" ItemStyle-VerticalAlign="Middle" DataField="Descripcion" ReadOnly="true" />
                    <asp:BoundField HeaderText="Precio" ItemStyle-VerticalAlign="Middle" DataField="Precio" ReadOnly="true" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
