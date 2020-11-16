<%@ Page Title="Finalizando compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="WebForm.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    


    <div class="card-deck">
        <% foreach (Dominio.Articulo item in listaCarrito)
            { %>
        <div class="card border-primary text-center container-fluid" style="max-width:300px; min-width:200px;">
            <img class="card-img-top img-fluid" src="<% = item.ImagenUrl %>"  alt="<% = item.Producto %>">
            <div class="card-body"></div>
            <div class="card-footer">
                <h5 class="card-title"><% = item.Producto %></h5>
                <small class="text-muted"><% = item.Descripcion %></small>
                <hr />
                <small class="text-muted">$ <% = item.Precio %></small>
            </div>
        </div>
        <% } %>
    </div>

</asp:Content>
