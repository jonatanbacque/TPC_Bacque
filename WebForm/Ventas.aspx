﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebForm.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--stilo css para ocultar columna en grid view--%>
    <style>
        .oculto {
            display: none;
        }
    </style>

    <div class="form-group">
        <div class="btn-group col-md-6">
            <a href="/" class="btn btn-primary">Volver</a>
            <a href="/Articulos?nuevo=1" class="btn btn-primary">Cargar nuevo articulo</a>
        </div>
    </div>
        <h2>Ventas</h2>
    <hr />

    <asp:GridView class="table" ID="dgvArticulos" AutoGenerateColumns="False" OnRowCommand="dgvArticulos_RowCommand" runat="server" CellPadding="0" EditIndex="1" SelectedIndex="1" HorizontalAlign="Center">
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
