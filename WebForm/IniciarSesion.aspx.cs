using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebForm
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        PersonaNegocio personaNegocio = new PersonaNegocio();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        Persona persona;
        Usuario usuario;
        bool a;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtDNI.Style.Add("overflow", "hidden");
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContrasena1.Text != txtContrasena2.Text)
                {
                    lblCrear.Text = "Las claves no coinciden!";
                }

                else
                {

                    if (usuarioNegocio.nombreOK(txtUsuarioNom.Text))
                    {
                        int dni = 0;
                        a = int.TryParse(txtDNI.Text, out dni);
                        int tel = 0;
                        a = int.TryParse(txtTelefono.Text, out tel);

                        persona = new Persona
                        {
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            DNI = dni,
                            Direccion = txtDireccion.Text,
                            Telefono = tel,
                            Email = txtEmail.Text,
                        };

                        personaNegocio.agregar(persona);

                        usuario = new Usuario
                        {
                            persona = new Persona
                            {
                                Id = personaNegocio.ultimo()
                            },
                            Nombre = txtUsuarioNom.Text,
                            Password = txtContrasena1.Text,
                            Nivel = 1
                        };

                        usuarioNegocio.agregar(usuario);


                        Session.Add("usuario", usuario);
                    }

                    else lblCrear.Text = "El usuario ya existe!";
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            if (Session["usuario"] != null)
            {
                //Precargo ID del carrito si esaba comprando
                if (Request.QueryString["ID"] != null)
                {
                    Response.Redirect("Compra.aspx");
                }

                Response.Redirect("Default.aspx");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario
                {
                    Nombre = txtUsuario.Text,
                    Password = txtContrasena.Text,
                };
                //Comprueba si existe
                if (usuarioNegocio.loguear(usuario) == 0)
                {
                    lblIngresar.Text = "Usuario y/o clave incorrecta!";
                }
                else
                {
                    Session.Add("usuario", usuarioNegocio.listarID(usuarioNegocio.loguear(usuario)));
                }
            }

            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            if (Session["usuario"] != null)
            {
                //Precargo ID del carrito si esaba comprando
                if (Request.QueryString["ID"] != null)
                {
                    Response.Redirect("Compra.aspx");
                }

                Response.Redirect("Default.aspx");
            }
        }
    }
}