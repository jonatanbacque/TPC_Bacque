<%@ Page Title="Edicion de Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentasEditar.aspx.cs" Inherits="WebForm.VentasEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Edición de Ventas</h2>
    </div>
    <hr />

    <div class="form-group">
        <asp:Label for="ddlEdicion" Text="Elegir que editar" runat="server" />
        <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddlEdicion" OnSelectedIndexChanged="ddlEdicion_SelectedIndexChanged" runat="server">
        </asp:DropDownList>
    </div>

    <hr />
    <div class="form-row">
        <div class="form-group col-md-8 center_div">
            <div class="form-group">
                <asp:Label for="ddlElemento" Text="Elegir" runat="server" />
                <asp:DropDownList CssClass="form-control" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="ddlElemento_SelectedIndexChanged" ID="ddlElemento" runat="server">
                </asp:DropDownList>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <asp:Label for="txtNombre" Text="Nombre" runat="server" />
                        <asp:TextBox ID="txtNombre" AutoPostBack="true" class="form-control" placeholder="Ingrese nombre." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtDetalle" Text="Detalle" runat="server" />
                        <asp:TextBox ID="txtDetalle" AutoPostBack="true" class="form-control" placeholder="Ingrese detalle." runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblDemora" for="txtDemora" Text="Demora en días" Visible="false" runat="server" />
                        <asp:TextBox ID="txtDemora" AutoPostBack="true" class="form-control" placeholder="Ingrese demora en días." Visible="false" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblPrecio" for="txtPrecio" Text="Precio" runat="server" Visible="false" />
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span id="spnPrecio" class="input-group-text" visible="false" runat="server">$</span>
                            </div>
                            <asp:TextBox ID="txtPrecio" AutoPostBack="true" CssClass="form-control" placeholder="Ingrese precio del envío." Visible="false" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="form-group">
                <div class="btn-group center-div">
                    <a href="Ventas.aspx" class="btn btn-primary">Volver</a>
                    <asp:Button class="btn btn-primary" ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" Enabled="false" runat="server" />
                    <asp:Button class="btn btn-primary" ID="btnGuardar" Text="Guardar cambios" OnClick="btnGuardar_Click" Enabled="false" runat="server" />
                    <asp:Button class="btn btn-primary" ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" Enabled="false" runat="server" />
                    <asp:Label CssClass=" align-middle" ID="lblResultado" runat="server" />
                </div>
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
