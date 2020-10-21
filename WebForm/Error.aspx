<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebForm.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Error</h1>
        <asp:Label Text="text" ID="lblError" runat="server" />
        <div>
            <a href="/">Volver</a>
        </div>
    </div>
</asp:Content>
