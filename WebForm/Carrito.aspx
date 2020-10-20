<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebForm.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label id="label1" Text="text" runat="server" />
    <asp:GridView runat="server" ID="dgvCarrito" UseAccessibleHeader="true" CssClass="table table-condensed table-hover" Width="50%" />
    <hr />
</asp:Content>
