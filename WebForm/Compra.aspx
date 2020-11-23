<%@ Page Title="Finalizando compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="WebForm.Compra" %>

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
                        <asp:Label for="txtNombre" Text="Producto" runat="server" />
                        <asp:TextBox ID="txtNombre" type="text" AutoPostBack="true" class="form-control" placeholder="Ingrese nombre del producto." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtPresentacion" Text="Producto" runat="server" />
                        <asp:TextBox ID="txtPresentacion" type="text" AutoPostBack="true" class="form-control" placeholder="Ingrese presentación." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtDescripcion" Text="Descripción" runat="server" />
                        <asp:TextBox ID="txtDescripcion" type="text" AutoPostBack="true" class="form-control" placeholder="Ingrese descripción." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtMarca" Text="Marca" runat="server" />
                        <asp:TextBox ID="txtMarca" type="text" AutoPostBack="true" class="form-control" placeholder="Ingrese marca." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="ddlCategorias" Text="Categorias" runat="server" />
                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddlCategorias" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtPrecio" Text="Precio" runat="server" />
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">$</span>
                            </div>
                            <asp:TextBox ID="txtPrecio" type="text" class="form-control" placeholder="Ingrese precio del producto." runat="server" aria-label="Amount (to the nearest dollar)" />
                            <div class="input-group-append">
                                <span class="input-group-text">.00</span>
                            </div>
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
                                <h6 class="card-title"><% = item.articulo.Producto %></h6>
                                <h7 class="card-subtitle">Cant: <% = item.Cantidad %></h7>
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
