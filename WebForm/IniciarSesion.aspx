<%@ Page Title="Inicio Sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="WebForm.IniciarSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-row">
        <div class="form-group col-md-4 center_div">
            <h2>Crear Usuario</h2>
        </div>
        <div class="form-group col-md-4 center_div">
            <h2>Iniciar Sesión</h2>
        </div>
    </div>
    <hr />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <asp:Panel CssClass="form-row" DefaultButton="btnIngresar" runat="server">
                <div class="form-group col-md-4 center_div">
                    <div class="form-group">
                        <asp:Label for="txtNombre" Text="Nombre" runat="server" />
                        <asp:TextBox ID="txtNombre" CssClass="form-control" AutoPostBack="true" placeholder="Ingrese nombre" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtApellido" Text="Apellido" runat="server" />
                        <asp:TextBox ID="txtApellido" CssClass="form-control" AutoPostBack="true" placeholder="Ingrese apellido" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtDNI" Text="DNI" runat="server" />
                        <asp:TextBox ID="txtDNI" CssClass="form-control" AutoPostBack="true" placeholder="Ingrese DNI" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtDireccion" Text="Dirección" runat="server" />
                        <asp:TextBox ID="txtDireccion" CssClass="form-control" AutoPostBack="true" placeholder="Ingrese dirección" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtTelefono" Text="Telefono" runat="server" />
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">+54 9</span>
                            </div>
                            <asp:TextBox ID="txtTelefono" TextMode="Phone" CssClass="form-control" AutoPostBack="true" placeholder="Ingrese numero de teléfono" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtEmail" Text="Email" runat="server" />
                        <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" AutoPostBack="true" placeholder="Ingrese direccion de email" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtUsuarioNom" Text="Usuario" runat="server" />
                        <asp:TextBox ID="txtUsuarioNom" CssClass="form-control" AutoPostBack="true" placeholder="Ingrese nombre de usuario" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtContrasena1" Text="Contraseña" runat="server" />
                        <asp:TextBox ID="txtContrasena1" TextMode="Password" CssClass="form-control" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtContrasena2" Text="Repita Contraseña" runat="server" />
                        <asp:TextBox ID="txtContrasena2" TextMode="Password" CssClass="form-control" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCrear" CssClass="btn btn-primary" Text="Crear Usuario" OnClick="btnCrear_Click" runat="server" />
                        <asp:Label ID="lblCrear" for="btnCrear" Text="" runat="server" />
                    </div>
                </div>
                <div class="form-group col-md-4 center_div">
                    <div class="form-group">
                        <asp:Label for="txtUsuario" Text="Usuario" runat="server" />
                        <asp:TextBox ID="txtUsuario" CssClass="form-control" AutoPostBack="true" placeholder="Ingrese usuario" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtContrasena" Text="Contraseña" runat="server" />
                        <asp:TextBox ID="txtContrasena" TextMode="Password" CssClass="form-control" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnIngresar" class="btn btn-primary" Text="Iniciar Sesión" OnClick="btnIngresar_Click" runat="server" />
                        <asp:Label ID="lblIngresar" for="btnIngresar" Text="" runat="server" />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
