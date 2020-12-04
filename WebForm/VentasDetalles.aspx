<%@ Page Title="Detalle de venta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentasDetalles.aspx.cs" Inherits="WebForm.VentasDetalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Detalle de Venta</h2>
    </div>
    <hr />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row">
                <div class="form-group col-md-4">
                    <div class="form-group">
                        <asp:Label for="txtPrecio" Text="Precio" runat="server" />
                        <asp:TextBox ID="txtPrecio" CssClass="form-control" ReadOnly="false" AutoPostBack="true" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtPrecioMetodo" Text="Metodo de pago" runat="server" />
                        <asp:TextBox ID="txtPrecioMetodo" CssClass="form-control" ReadOnly="false" AutoPostBack="true" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtEnvio" Text="Método de envío" runat="server" />
                        <asp:TextBox ID="txtEnvio" CssClass="form-control" ReadOnly="false" AutoPostBack="true" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtEnvioPrecio" Text="Costo de envío" runat="server" />
                        <asp:TextBox ID="txtEnvioPrecio" CssClass="form-control" ReadOnly="false" AutoPostBack="true" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="ddlEnvioEstado" Text="Estado" runat="server" />
                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddlEnvioEstado" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click" runat="server" />
                        <asp:Button ID="btnGuardar" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" runat="server" />
                        <asp:Label ID="lblResultado" for="btnGuardar" Text="" runat="server" />
                    </div>
                </div>
            </div>
            <hr />
            <asp:GridView class="table table-striped table-dark border-dark" AutoPostBack="true" ID="dgvCompra" AutoGenerateColumns="False" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="ID" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" DataField="ID" ReadOnly="true" />
                    <asp:ImageField HeaderText="Imagen" ControlStyle-Height="150px" ControlStyle-Width="150px" DataImageUrlField="ImagenUrl" ItemStyle-CssClass="img-fluid" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                    <asp:BoundField HeaderText="Cantidad" ItemStyle-VerticalAlign="Middle" DataField="Cantidad" ReadOnly="true" />
                    <asp:BoundField HeaderText="Producto" ItemStyle-VerticalAlign="Middle" DataField="Producto" ReadOnly="true" />
                    <asp:BoundField HeaderText="Descripción" ItemStyle-VerticalAlign="Middle" DataField="Descripcion" ReadOnly="true" />
                    <asp:BoundField HeaderText="Precio" ItemStyle-VerticalAlign="Middle" DataFormatString="$ {0}" DataField="Precio" ReadOnly="true" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
