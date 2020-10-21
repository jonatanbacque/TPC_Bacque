<%@ Page Title="Detalle del Articulo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebForm.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Detalle</h2>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <div class="card border-primary mb-3 text-center">
                <asp:Image class="card-img-top" ID="imgImagen" runat="server" />
                <div class="card-body">
                    <h4>
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </h4>
                    <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                    <hr />
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <a href="/" class="btn btn-primary">Volvel al Listado</a>
                        <a href="Carrito.aspx?ID=<% =id.ToString() %>" class="btn btn-primary">Agregar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
