<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebForm.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--stilo css para ocultar columna en grid view--%>
    <style>
        .oculto{
            display: none;
        }

        .img-chica{
            max-height:150px;
            max-width:150px;
            height:100px;
            width:100px;
        }
    </style>

    <div>
        <h2>Ventas</h2>
    </div>

    <hr />

    <asp:GridView class="table" ID="dgvArticulos" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnRowCommand="dgvArticulos_RowCommand" runat="server">
        <Columns>
            <asp:ButtonField HeaderText="Elegir" ButtonType="Button" Text="Editar" CommandName="Select" />
            <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" ReadOnly="true"/>
            <asp:BoundField HeaderText="Producto" DataField="Producto" ReadOnly="true"/>
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" ReadOnly="true"/>
            <asp:BoundField HeaderText="Precio" DataField="Precio" ReadOnly="true"/>
            <asp:ImageField HeaderText="Imagen" DataImageUrlField="ImagenUrl" ItemStyle-CssClass="img-chica" ReadOnly="true" />
        </Columns>
    </asp:GridView>

</asp:Content>
