<%@ Page Title="Finalizando compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraMetodo.aspx.cs" Inherits="WebForm.CompraMetodo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Finalizando Compra</h2>
    </div>
    <hr />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row">
                <div class="form-group col-md-4">
                    <div class="form-group">
                        <asp:Label for="ddlMetodoEnvio" Text="Metodo de Envío" runat="server" />
                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddlMetodoEnvio" OnTextChanged="ddlMetodoEnvio_TextChanged" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblDomicilioEntrega" for="txtDomicilioEntrega" Visible="false" Text="Domicilio de entrega" runat="server" />
                        <asp:TextBox ID="txtDomicilioEntrega" CssClass="form-control" Visible="false" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblFechaEntrega" for="txtFechaEntrega" Visible="false" Text="Fecha de entrega" runat="server" />
                        <asp:TextBox ID="txtFechaEntrega" CssClass="form-control" Visible="false" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtPrecio" Text="Importe Final" runat="server" />
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">$</span>
                            </div>
                            <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="form-group col-md-8">

                    <div class="card-deck">
                        <% foreach (Dominio.Elemento item in listaElementos)
                            { %>
                        <div class="card border-primary text-center container-fluid" style="max-width: 180px; min-width: 180px;">
                            <img class="card-img-top img-fluid" src="<% = item.articulo.ImagenUrl %>" alt="<% = item.articulo.Producto %>">
                            <div class="card-body"></div>
                            <div class="card-footer">
                                <h5 class="card-title"><% = item.articulo.Producto %></h5>
                                <h6 class="card-subtitle">Cant: <% = item.Cantidad %></h6>
                                <br />
                                <small class="text-muted">$ <% = item.articulo.Precio %></small>
                            </div>
                        </div>
                        <% } %>
                    </div>
                </div>
            </div>
            <%--<div class="form-group">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" id="gridCheck">
                    <label class="form-check-label" for="gridCheck">
                        Check me out
                    </label>
                </div>
            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
