<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebForm.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--stilo css para ocultar columna en grid view--%>
    <style>
        .oculto {
            display: none;
        }
    </style>

    <div>
        <h2>Ventas</h2>
    </div>

    <hr />

    <asp:GridView class="table" ID="dgvCarrito" AutoGenerateColumns="False" runat="server">
        <Columns>
            <asp:ImageField HeaderText="Imagen" ControlStyle-Height="150px" ControlStyle-Width="150px" DataImageUrlField="ImagenUrl" ItemStyle-CssClass="img-fluid" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
            <asp:ButtonField HeaderText="Eliminar" ItemStyle-VerticalAlign="Middle" ButtonType="Button" Text="Editar" CommandName="Select" />
            <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" ReadOnly="true" />
            <asp:BoundField HeaderText="Producto" ItemStyle-VerticalAlign="Middle" DataField="Producto" ReadOnly="true" />
            <asp:BoundField HeaderText="Descripción" ItemStyle-VerticalAlign="Middle" DataField="Descripcion" ReadOnly="true" />
            <asp:BoundField HeaderText="Precio" ItemStyle-VerticalAlign="Middle" DataField="Precio" ReadOnly="true" />
        </Columns>
    </asp:GridView>
    <hr />

    <div class="form-row">
        <div class="form-group">
            <div class="btn-group" role="group" aria-label="Basic example">
                <a href="/" class="btn btn-primary">Seguir Comprando</a>
                <asp:Button class="btn btn-primary" ID="btnCarritoVaciar" Text="Vaciar Carrito" OnClick="btnCarritoVaciar_Click" runat="server" />
                <a href="/Compra.aspx" class="btn btn-primary">Finalizar Compra</a>
            </div>
        </div>
        <div class="form-group align-content-end align-items-end align-self-end justify-content-end text-right">
            <label class="form-control">Total: $<%=this.aux.Sum(s => s.Precio)%></label>
        </div>
    </div>
</asp:Content>
