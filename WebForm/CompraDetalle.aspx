<%@ Page Title="Detalle de Compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraDetalle.aspx.cs" Inherits="WebForm.CompraDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Detalle de Compra</h2>
    </div>
    <hr />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row">
                <div class="form-group">
                    <div class="form-group">
                        <a href="CompraListado.aspx" class="btn btn-primary">Volver</a>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblImporte" AutoPostBack="true" CssClass="form-control" runat="server" />
                </div>
            </div>
            <hr />
            <asp:GridView class="table table-striped table-dark border-dark" AutoPostBack="true" ID="dgvCompra" AutoGenerateColumns="False" OnRowCommand="dgvCompra_RowCommand" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="ID" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" DataField="ID" ReadOnly="true" />
                    <asp:ImageField HeaderText="Imagen" ControlStyle-Height="150px" ControlStyle-Width="150px" DataImageUrlField="ImagenUrl" ItemStyle-CssClass="img-fluid" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                    <asp:BoundField HeaderText="Cantidad" ItemStyle-VerticalAlign="Middle" DataField="Cantidad" ReadOnly="true" />
                    <asp:BoundField HeaderText="Producto" ItemStyle-VerticalAlign="Middle" DataField="Producto" ReadOnly="true" />
                    <asp:BoundField HeaderText="Descripción" ItemStyle-VerticalAlign="Middle" DataField="Descripcion" ReadOnly="true" />
                    <asp:BoundField HeaderText="Precio" ItemStyle-VerticalAlign="Middle" DataFormatString="$ {0}" DataField="Precio" ReadOnly="true" />
                    <asp:ButtonField HeaderText="Cancelar" ButtonType="Button" Text="Cancelar" CommandName="Select">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
