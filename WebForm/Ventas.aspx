<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebForm.Ventas" %>

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

    <asp:GridView class="table" ID="dgvArticulos" AutoGenerateColumns="False" OnRowCommand="dgvArticulos_RowCommand" runat="server">
        <Columns>
            <asp:ImageField HeaderText="Imagen" ControlStyle-Height="150px" ControlStyle-Width="150px" DataImageUrlField="ImagenUrl" ItemStyle-CssClass="img-fluid" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
            <asp:ButtonField HeaderText="Elegir" ItemStyle-VerticalAlign="Middle" ButtonType="Button" Text="Editar" CommandName="Select" />
            <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" ReadOnly="true" />
            <asp:BoundField HeaderText="Producto" ItemStyle-VerticalAlign="Middle" DataField="Producto" ReadOnly="true" />
            <asp:BoundField HeaderText="Descripción" ItemStyle-VerticalAlign="Middle" DataField="Descripcion" ReadOnly="true" />
            <asp:BoundField HeaderText="Precio" ItemStyle-VerticalAlign="Middle" DataField="Precio" ReadOnly="true" />
        </Columns>
    </asp:GridView>

</asp:Content>
