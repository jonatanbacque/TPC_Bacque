﻿<%@ Page Title="Articulos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="WebForm.Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Artículos</h2>
    </div>
    <hr />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <div class="form-group">
                        <asp:Label for="txtNombre" Text="Producto" runat="server" />
                        <asp:TextBox ID="txtNombre" AutoPostBack="true" class="form-control" placeholder="Ingrese nombre del producto." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtPresentacion" Text="Producto" runat="server" />
                        <asp:TextBox ID="txtPresentacion" AutoPostBack="true" class="form-control" placeholder="Ingrese presentación." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtDescripcion" Text="Descripción" runat="server" />
                        <asp:TextBox ID="txtDescripcion" AutoPostBack="true" class="form-control" placeholder="Ingrese descripción." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtMarca" Text="Marca" runat="server" />
                        <asp:TextBox ID="txtMarca" AutoPostBack="true" class="form-control" placeholder="Ingrese marca." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="ddlCategorias" Text="Categorias" runat="server" />
                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddlCategorias" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtURLImagen" Text="URL de imagen" runat="server" />
                        <asp:TextBox ID="txtURLImagen" AutoPostBack="true" OnTextChanged="txtURLImagen_TextChanged" TextMode="Url"  CssClass="form-control" placeholder="Ingrese URL de la imágen." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtPrecio" Text="Precio" runat="server" />
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">$</span>
                            </div>
                            <asp:TextBox ID="txtPrecio" class="form-control" placeholder="Ingrese precio del producto." runat="server"/>
                            <div class="input-group-append">
                                <span class="input-group-text">.00</span>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="btn-group col-md-2">
                            <a href="/Listado.aspx" class="btn btn-primary">Volver</a>
                            <asp:Button class="btn btn-primary" ID="btnGuardar" Text="Guardar cambios" OnClick="btnGuardar_Click" runat="server" />
                            <asp:Button class="btn btn-primary" ID="btnEliminar" Visible="false" Text="Eliminar Producto" OnClick="btnEliminar_Click" runat="server" />
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Label ID="lblGuardar" runat="server" for="btnGuardar" />
                        </div>
                    </div>
                </div>
                <div class="form-group col-md-6">
                    <div>
                        <asp:Label for="imgImagen" Text="Imagen" runat="server" />
                        <asp:Image ID="imgImagen" class="border-0 img-fluid" runat="server" />
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
