<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Catalogo de productos</h2>
    </div>

    <hr />

    <div class="card-deck">
        <% foreach (Dominio.Articulo item in listaArticulos)
            { %>
        <div class="card border-primary text-center">
            <%--<img class="card-img-top" src="<% = item.ImagenUrl %>"  alt="<% = item.Nombre %>">--%>
            <div class="card-body">
                <h5 class="card-title"><% = item.Nombre %></h5>
                <%--<p class="card-text"><% = item.Descripcion %></p>--%>
                <hr />
                <div class="btn-group" role="group" aria-label="Basic example">
                    <a href="Detalle.aspx?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Detalle</a>

                    <a href="Carrito.aspx?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Agregar al Carrito</a>
                </div>
            </div>
            <div class="card-footer">
                <small class="text-muted"><% = item.Descripcion %></small>
            </div>
        </div>
        <% } %>
    </div>

</asp:Content>
