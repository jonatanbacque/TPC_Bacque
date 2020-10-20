<%@ Page Title="Mercadito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Catalogo de productos</h2>
    </div>
    <hr />
    <div class="card-columns">
        <% foreach (Dominio.Articulo item in listaArticulos)
            { %>

        <div class="card border-primary mb-3 text-center">
            <img src="<% = item.ImagenUrl %>"" class="card-img-top" alt="<% = item.Nombre %>"></img>
            <div class="card-body">
                <h5 class="card-title"><% = item.Nombre %></h5>
                <%--<p class="card-text"><% = item.Descripcion %></p>--%>
                <hr />
                <div class="btn-group" role="group" aria-label="Basic example">
                    <a href="Detalle.aspx?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Detalle</a>
                    <a href="Carrito.aspx?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Agregar</a>
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
