<%@ Page Title="Finalizando compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraMetodo.aspx.cs" Inherits="WebForm.CompraMetodo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Finalizando Compra</h2>
    </div>
    <hr />
    <div class="form-row">
        <div class="form-group col-md-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <asp:Label for="ddlMetodoPago" Text="Metodo de Pago" runat="server" />
                        <asp:DropDownList CssClass="form-control" ID="ddlMetodoPago" AutoPostBack="true" OnSelectedIndexChanged="ddlMetodoPago_SelectedIndexChanged" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtNombre" Text="Nombre para Facturacion" runat="server" />
                        <asp:TextBox ID="txtNombre" CssClass="form-control" ReadOnly="false" AutoPostBack="true" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtEnvio" Text="Domicilio de Entrega" runat="server" />
                        <asp:TextBox ID="txtEnvio" CssClass="form-control" ReadOnly="false" AutoPostBack="true" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtPrecio" Text="Importe Final" runat="server" />
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">$</span>
                            </div>
                            <asp:TextBox ID="txtPrecio" CssClass="form-control" AutoPostBack="true" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="btn-group" role="group" aria-label="Basic example">
                            <asp:Button class="btn btn-primary" ID="btnCancelar" Text="Cancelar compra" OnClick="btnCancelar_Click" runat="server" />
                            <asp:Button class="btn btn-primary" ID="btnFinalizar" Text="Finalizar compra" Enabled="false" OnClick="btnFinalizar_Click" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
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
</asp:Content>
