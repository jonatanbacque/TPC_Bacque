<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebForm.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Ventas</h2>
    </div>
    <hr />
    <div class="form-group">
        <a href="/" class="btn btn-primary">Volver</a>
        <asp:Button class="btn btn-primary" ID="btnListado" Text="Ver listado de productos" OnClick="btnListado_Click" runat="server" />
        <asp:Button class="btn btn-primary" ID="btnEdicion" Text="Editar elementos" OnClick="btnEdicion_Click" runat="server" />
    </div>
    <hr />
    <div class="form-group">
        <asp:Label for="ddlEdicion" Text="Elegir que editar" runat="server" />
        <asp:DropDownList CssClass="form-control" ID="ddlEdicion" runat="server">
        </asp:DropDownList>
    </div>
</asp:Content>
