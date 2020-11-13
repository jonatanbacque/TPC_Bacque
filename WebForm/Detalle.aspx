<%@ Page Title="Detalle del Articulo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebForm.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Detalle</h2>
    </div>

    <div class="card-deck">
        <div class="card border-primary text-center">
            <asp:Image class="card-img-top" ID="imgImagen" runat="server" />
            <div class="card-body">
                <h5 class="card-title">
                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                </h5>
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                <hr />
                <div class="btn-group" role="group" aria-label="Basic example">
                    <a href="/" class="btn btn-primary">Volver al Listado</a>
                    <a href="Carrito.aspx?ID=<% =id.ToString() %>" class="btn btn-primary">Agregar al carrito</a>
                </div>
            </div>
        </div>
        <div class="card border-primary text-center">
            One of three columns
        </div>
    </div>

    <h6 class="text-left">Productos relacionados:</h6>

    <div class="card-deck">
        <% foreach (Dominio.Articulo item in listaArticulos)
            { %>
        <div class="card border-primary text-center">
            <img class="card-img-top" src="<% = item.ImagenUrl %>"  alt="<% = item.Nombre %>">
            <div class="card-body">
                <h5 class="card-title"><% = item.Nombre %></h5>
                <p class="card-text"><% = item.Descripcion %></p>
                <hr />
                <div class="btn-group" role="group" aria-label="Basic example">
                    <%--<a href="Detalle.aspx?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Detalle</a>--%>
                    <a href="Carrito.aspx?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Agregar</a>
                </div>
            </div>
            <div class="card-footer">
                <small class="text-muted"><% = item.Descripcion %></small>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
