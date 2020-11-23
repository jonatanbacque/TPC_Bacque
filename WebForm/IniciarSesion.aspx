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

            <div class="form-row">
                <div class="form-group col-md-4 center_div">
                    <div class="form-group">
                        <asp:Label for="txtNombre" Text="Nombre" runat="server" />
                        <asp:TextBox ID="txtNombre" type="text" class="form-control" placeholder="Ingrese nombre" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtApellido" Text="Apellido" runat="server" />
                        <asp:TextBox ID="txtApellido" type="text" class="form-control" placeholder="Ingrese apellido" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtDNI" Text="DNI" runat="server" />
                        <asp:TextBox ID="txtDNI" type="numeric" class="form-control" placeholder="Ingrese DNI" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtDireccion" Text="Dirección" runat="server" />
                        <asp:TextBox ID="txtDireccion" type="text" class="form-control" placeholder="Ingrese dirección" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtTelefono" Text="Telefono" runat="server" />
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">+54 9</span>
                            </div>
                            <asp:TextBox ID="txtTelefono" type="numeric" class="form-control" placeholder="Ingrese numero de teléfono" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtEmail" Text="Email" runat="server" />
                        <asp:TextBox ID="txtEmail" type="text" class="form-control" placeholder="Ingrese direccion de email" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtUsuarioNom" Text="Usuario" runat="server" />
                        <asp:TextBox ID="txtUsuarioNom" type="text" class="form-control" placeholder="Ingrese nombre de usuario" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtContrasena1" Text="Contraseña" runat="server" />
                        <asp:TextBox ID="txtContrasena1" type="password" class="form-control" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtContrasena2" Text="Repita Contraseña" runat="server" />
                        <asp:TextBox ID="txtContrasena2" type="password" class="form-control" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCrear" class="btn btn-primary" Text="Crear Usuario" OnClick="btnCrear_Click" runat="server" />
                        <asp:Label ID="lblCrear" AutoPostBack="true" for="btnCrear" Text="" runat="server" />
                    </div>
                </div>
                <div class="form-group col-md-4 center_div">
                    <div class="form-group">
                        <asp:Label for="txtUsuario" Text="Usuario" runat="server" />
                        <asp:TextBox ID="txtUsuario" type="text" class="form-control" placeholder="Ingrese usuario" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Label for="txtContrasena" Text="Contraseña" runat="server" />
                        <asp:TextBox ID="txtContrasena" type="password" class="form-control" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnIngresar" class="btn btn-primary" Text="Iniciar Sesión" OnClick="btnIngresar_Click" runat="server" />
                        <asp:Label ID="lblIngresar" AutoPostBack="true" for="btnIngresar" Text="" runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
