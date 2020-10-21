<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebForm.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %></h2>
    <hr />
    <address>
        Argentina<br />
        Calle Sin Nombre 123<br />
        <abbr title="Telefono">Tel:</abbr>
        011.1234.5678
    </address>
    <hr />
    <address>
        <strong>Support:</strong>   <a href="mailto:jonatan.bacque@alumnos.frgp.utn.edu.ar">jonatan.bacque@alumnos.frgp.utn.edu.ar</a><br />
    </address>

</asp:Content>
