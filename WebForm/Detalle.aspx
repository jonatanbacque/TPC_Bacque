<%@ Page Title="Detalle del Articulo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebForm.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Detalle</h2>
    </div>

    <div class="card-deck">
        <div class="card border-primary text-center">
            <asp:Image class="card-img-top" ID="imgImagen" runat="server" />
        </div>
        <div class="card border-primary text-left">
            <div class="card-header">
                <h4>
                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                </h4>
            </div>
            <small class="text-muted">
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                <asp:Label ID="lblPrecio" runat="server"></asp:Label>
            </small>
            <hr />
            <div class="card-footer">
                <div class="btn-group" role="group" aria-label="Basic example">
                    <a href="/" class="btn btn-primary">Volver al Listado</a>

                    <asp:Button class="btn btn-primary" ID="btnCarritoAgregar" Text="Agregar al Carrito" OnClick="btnCarritoAgregar_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <h1 class="text-left">Productos relacionados:</h1>


    <div class="card-deck">
        <% foreach (Dominio.Articulo item in listaArticulos)
            { %>
        <div class="card border-primary text-center" style="max-width: 250px;">
            <img class="card-img-top" src="<% = item.ImagenUrl %>" alt="<% = item.Nombre %>">
            <div class="card-body"></div>
            <div class="card-footer">
                <h5 class="card-title"><% = item.Nombre %></h5>
                <small class="text-muted"><% = item.Descripcion %></small>
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
