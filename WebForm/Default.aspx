<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Catalogo de productos</h2>
    </div>

    <hr />

    <div class="card-deck">
        <% foreach (Dominio.Articulo item in listaArticulos)
            { %>
        <div class="card border-primary text-center container-fluid" style="max-width: 300px; min-width: 200px;">
            <img class="card-img-top img-fluid" src="<% = item.ImagenUrl %>" alt="<% = item.Producto %>">
            <div class="card-body"></div>
            <div class="card-footer">
                <h5 class="card-title"><% = item.Producto %></h5>
                <div>
                    <small class="text-muted"><% = item.Descripcion %></small>
                </div>
                <div>
                    <small class="text-muted">Precio: $ <% = item.Precio %></small>
                </div>
        <hr />
        <div class="btn-group" role="group" aria-label="Basic example">
            <a href="Detalle.aspx?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Detalle</a>

            <a href="?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Agregar al Carrito</a>
        </div>
    </div>
    </div>
        <% } %>
    </div>

</asp:Content>
