<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Catalogo de Compras</h2>
    <hr />

    <asp:Button ID="btnCarrito" class="btn btn-primary" Text="Ir al carrito" Visible="false" OnClick="btnCarrito_Click" runat="server" />

    <%if (Convert.ToInt32(Session["carrito"]) != 0)
        {%><hr />
    <%}%>

    <div class="form-group center_div">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="card-deck">
                    <% foreach (Dominio.Articulo item in listaArticulos)
                        { %>
                    <div class="card border-primary text-center container-fluid" style="max-width: 260px; min-width: 120px;">
                        <img class="card-img-top img-fluid" src="<% = item.ImagenUrl %>" alt="<% = item.Producto %>">
                        <div class="card-body"></div>
                        <div class="card-footer">
                            <h6 class="card-title"><% = item.Producto %></h6>
                            <%--<div>
                                <small class="text-muted"><% = item.Descripcion %></small>
                            </div>--%>
                            <div>
                                <small class="text-muted">Precio: $ <% = item.Precio %></small>
                            </div>
                            <hr />
                            <div class="btn-group-auto" role="group" aria-label="Basic example">
                                <%--<a href="Detalle.aspx?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Detalle</a>--%>

                                <a href="?ID=<% =item.Id.ToString() %>" class="btn btn-primary">Agregar al Carrito</a>
                            </div>
                        </div>
                    </div>
                    <% } %>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
