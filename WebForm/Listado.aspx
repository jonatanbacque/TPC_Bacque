<%@ Page Title="Listado de Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="WebForm.Listado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Listado de Productos</h2>
    <hr />

    <div class="form-group">
        <a href="Ventas.aspx" class="btn btn-primary">Volver</a>
        <asp:Button ID="btnNuevo" class="btn btn-primary" Text="Cargar nuevo articulo" OnClick="btnNuevo_Click" runat="server" />
    </div>
    <hr />

    <asp:GridView class="table table-striped table-dark border-dark" DataKeyNames="ID" ID="dgvArticulos" AutoGenerateColumns="False"
        OnRowCommand="dgvArticulos_RowCommand" runat="server" HorizontalAlign="Center">
        <Columns>
            <asp:ImageField HeaderText="Imagen" ControlStyle-Height="150px" ControlStyle-Width="150px"
                DataImageUrlField="ImagenUrl" ItemStyle-CssClass="img-fluid" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
            <asp:ButtonField HeaderText="Elegir" ItemStyle-VerticalAlign="Middle" ButtonType="Button" Text="Editar" CommandName="Select" />
            <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" ReadOnly="true" />
            <asp:BoundField HeaderText="Producto" ItemStyle-VerticalAlign="Middle" DataField="Producto" ReadOnly="true" />
            <asp:BoundField HeaderText="Descripción" ItemStyle-VerticalAlign="Middle" DataField="Descripcion" ReadOnly="true" />
            <asp:BoundField HeaderText="Precio" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Precio" ReadOnly="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
