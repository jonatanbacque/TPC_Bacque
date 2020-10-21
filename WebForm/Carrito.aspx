<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebForm.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="dgvCarrito" UseAccessibleHeader="true" CssClass="table table-condensed table-hover" Width="50%" />
    <hr />
    <asp:Label class="text-muted font-weight-bold text-right" Text="<%=this.aux.Sum(s => s.Precio)%>" runat="server" />
    
</asp:Content>
