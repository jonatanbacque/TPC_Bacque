<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoEliminados.aspx.cs" Inherits="WebForm.ListadoEliminados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listado de Productos eliminados</h2>
    <hr />

    <div class="form-group">
        <a href="Listado.aspx" class="btn btn-primary">Volver</a>
    </div>
    <hr />

    <asp:GridView class="table table-striped table-dark border-dark" DataKeyNames="ID" ID="dgvArticulos" AutoGenerateColumns="False" runat="server" HorizontalAlign="Center">
        <Columns>
            <asp:ImageField HeaderText="Imagen" ControlStyle-Height="150px" ControlStyle-Width="150px"
                DataImageUrlField="ImagenUrl" ItemStyle-CssClass="img-fluid" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
            <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" ReadOnly="true" />
            <asp:BoundField HeaderText="Producto" ItemStyle-VerticalAlign="Middle" DataField="Producto" ReadOnly="true" />
            <asp:BoundField HeaderText="Descripción" ItemStyle-VerticalAlign="Middle" DataField="Descripcion" ReadOnly="true" />
            <asp:BoundField HeaderText="Precio" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="Precio" ReadOnly="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
