<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebForm.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="true" CssClass="table table-striped" />

    <%--<asp:GridView runat="server" ID="dgvCarrito" UseAccessibleHeader="true" CssClass="table table-condensed table-hover" Width="50%" />--%>

    <hr />

    <div class="btn-group" role="group" aria-label="Basic example">
        <a href="/" class="btn btn-primary">Seguir Comprando</a>
        <asp:Button class="btn btn-primary" ID="btnCarritoVaciar" Text="Vaciar Carrito" OnClick="btnCarritoVaciar_Click" runat="server" />
        <a href="/Compra.aspx" class="btn btn-primary">Finalizar Compra</a>
    </div>

    <label class="text-right text-muted font-weight-bold">Total: $<%=this.aux.Sum(s => s.Precio)%></label>

</asp:Content>
