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
    public partial class VentasEditar : System.Web.UI.Page
    {
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        EstadoEnvioNegocio estadoEnvioNegocio = new EstadoEnvioNegocio();
        MetodoEnvioNegocio metodoEnvioNegocio = new MetodoEnvioNegocio();
        MetodoPagoNegocio metodoPagoNegocio = new MetodoPagoNegocio();

        List<string> cosas = new List<string>()
        {
            "Elegir",
            "Categorias",
            "Estados de envío",
            "Métodos de envío",
            "Métodos de pago"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlEdicion.DataSource = cosas;
                    ddlEdicion.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlEdicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //
                txtNombre.Text = "";
                txtDetalle.Text = "";
                txtDemora.Text = "";
                txtPrecio.Text = "";
                lblResultado.Text = "";
                btnAgregar.Text = "Agregar";
                //Oculto opciones de metodo de envio
                lblDemora.Visible = false;
                txtDemora.Visible = false;
                lblPrecio.Visible = false;
                txtPrecio.Visible = false;
                spnPrecio.Visible = false;

                ddlElemento.Enabled = true;
                btnAgregar.Enabled = true;
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = true;


                switch (ddlEdicion.SelectedIndex)
                {
                    case 1:
                        ddlElemento.DataSource = categoriaNegocio.listar();
                        btnAgregar.Text = "Agregar Categoría";
                        break;

                    case 2:
                        ddlElemento.DataSource = estadoEnvioNegocio.listar();
                        btnAgregar.Text = "Agregar Estado";
                        break;

                    case 3:
                        ddlElemento.DataSource = metodoEnvioNegocio.listar();
                        lblDemora.Visible = true;
                        txtDemora.Visible = true;
                        lblPrecio.Visible = true;
                        txtPrecio.Visible = true;
                        spnPrecio.Visible = true;
                        btnAgregar.Text = "Agregar Método";
                        break;

                    case 4:
                        ddlElemento.DataSource = metodoPagoNegocio.listar();
                        lblPrecio.Visible = true;
                        txtPrecio.Visible = true;
                        spnPrecio.Visible = true;
                        btnAgregar.Text = "Agregar Método";
                        break;

                    default:
                        ddlElemento.DataSource = "";
                        ddlElemento.Enabled = false;
                        btnAgregar.Enabled = false;
                        btnGuardar.Enabled = false;
                        btnEliminar.Enabled = false;
                        break;
                }
                ddlElemento.DataTextField = "Nombre";
                ddlElemento.DataValueField = "ID";
                ddlElemento.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");

            }
        }
        protected void ddlElemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtNombre.Text = "";
                txtDetalle.Text = "";
                txtDemora.Text = "";
                txtPrecio.Text = "";
                lblResultado.Text = "";

                switch (ddlEdicion.SelectedIndex)
                {
                    case 1:
                        txtNombre.Text = categoriaNegocio.listarID(ddlElemento.SelectedIndex + 1).Nombre;
                        txtDetalle.Text = categoriaNegocio.listarID(ddlElemento.SelectedIndex + 1).Detalle;
                        break;

                    case 2:
                        txtNombre.Text = estadoEnvioNegocio.listarID(ddlElemento.SelectedIndex + 1).Nombre;
                        txtDetalle.Text = estadoEnvioNegocio.listarID(ddlElemento.SelectedIndex + 1).Detalle;
                        break;

                    case 3:
                        txtNombre.Text = metodoEnvioNegocio.listarID(ddlElemento.SelectedIndex + 1).Nombre;
                        txtDetalle.Text = metodoEnvioNegocio.listarID(ddlElemento.SelectedIndex + 1).Detalle;
                        txtDemora.Text = metodoEnvioNegocio.listarID(ddlElemento.SelectedIndex + 1).Demora.ToString();
                        txtPrecio.Text = metodoEnvioNegocio.listarID(ddlElemento.SelectedIndex + 1).Precio.ToString();
                        break;

                    case 4:
                        txtNombre.Text = metodoPagoNegocio.listarID(ddlElemento.SelectedIndex + 1).Nombre;
                        txtDetalle.Text = metodoPagoNegocio.listarID(ddlElemento.SelectedIndex + 1).Detalle;
                        txtPrecio.Text = metodoPagoNegocio.listarID(ddlElemento.SelectedIndex + 1).Precio.ToString();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int demora;
                decimal precio;
                switch (ddlEdicion.SelectedIndex)
                {
                    case 1:
                        Categoria categoria = new Categoria
                        {
                            Id = ddlElemento.SelectedIndex + 1,
                            Nombre = txtNombre.Text,
                            Detalle = txtDetalle.Text
                        };
                        categoriaNegocio.agregar(categoria);
                        break;

                    case 2:
                        EstadoEnvio estadoEnvio = new EstadoEnvio
                        {
                            Id = ddlElemento.SelectedIndex + 1,
                            Nombre = txtNombre.Text,
                            Detalle = txtDetalle.Text
                        };
                        estadoEnvioNegocio.agregar(estadoEnvio);
                        break;

                    case 3:
                        int.TryParse(txtDemora.Text, out demora);
                        decimal.TryParse(txtPrecio.Text, out precio);

                        MetodoEnvio metodoEnvio = new MetodoEnvio
                        {
                            Id = ddlElemento.SelectedIndex + 1,
                            Nombre = txtNombre.Text,
                            Detalle = txtDetalle.Text,
                            Demora = demora,
                            Precio = precio
                        };
                        metodoEnvioNegocio.agregar(metodoEnvio);
                        break;

                    case 4:
                        decimal.TryParse(txtPrecio.Text, out precio);

                        MetodoPago metodoPago = new MetodoPago
                        {
                            Id = ddlElemento.SelectedIndex + 1,
                            Nombre = txtNombre.Text,
                            Detalle = txtDetalle.Text,
                            Precio = precio
                        };
                        metodoPagoNegocio.agregar(metodoPago);
                        break;

                    default:
                        break;
                }

                txtNombre.Text = "";
                txtDetalle.Text = "";
                txtDemora.Text = "";
                txtPrecio.Text = "";

                ddlEdicion.SelectedIndex = 0;
                ddlElemento.DataSource = "";
                ddlElemento.DataBind();

                btnAgregar.Enabled = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;

                lblResultado.Text = "Elemento Agregado.";
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int demora;
                decimal precio;
                switch (ddlEdicion.SelectedIndex)
                {
                    case 1:
                        Categoria categoria = new Categoria
                        {
                            Id = ddlElemento.SelectedIndex + 1,
                            Nombre = txtNombre.Text,
                            Detalle = txtDetalle.Text
                        };
                        categoriaNegocio.modificar(categoria);
                        break;

                    case 2:
                        EstadoEnvio estadoEnvio = new EstadoEnvio
                        {
                            Id = ddlElemento.SelectedIndex + 1,
                            Nombre = txtNombre.Text,
                            Detalle = txtDetalle.Text
                        };
                        estadoEnvioNegocio.modificar(estadoEnvio);
                        break;

                    case 3:
                        int.TryParse(txtDemora.Text, out demora);
                        decimal.TryParse(txtPrecio.Text, out precio);

                        MetodoEnvio metodoEnvio = new MetodoEnvio
                        {
                            Id = ddlElemento.SelectedIndex + 1,
                            Nombre = txtNombre.Text,
                            Detalle = txtDetalle.Text,
                            Demora = demora,
                            Precio = precio
                        };
                        metodoEnvioNegocio.modificar(metodoEnvio);
                        break;

                    case 4:
                        int.TryParse(txtDemora.Text, out demora);
                        decimal.TryParse(txtPrecio.Text, out precio);

                        MetodoPago metodoPago = new MetodoPago
                        {
                            Id = ddlElemento.SelectedIndex + 1,
                            Nombre = txtNombre.Text,
                            Detalle = txtDetalle.Text,
                            Precio = precio
                        };
                        metodoPagoNegocio.modificar(metodoPago);
                        break;

                    default:
                        break;
                }

                txtNombre.Text = "";
                txtDetalle.Text = "";
                txtDemora.Text = "";
                txtPrecio.Text = "";

                ddlEdicion.SelectedIndex = 0;
                ddlElemento.DataSource = "";
                ddlElemento.DataBind();

                btnAgregar.Enabled = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;

                lblResultado.Text = "Elemento Guardado.";
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (ddlEdicion.SelectedIndex)
                {
                    case 1:
                        categoriaNegocio.eliminar(ddlElemento.SelectedIndex + 1);
                        break;

                    case 2:
                        estadoEnvioNegocio.eliminar(ddlElemento.SelectedIndex + 1);
                        break;

                    case 3:
                        metodoEnvioNegocio.eliminar(ddlElemento.SelectedIndex + 1);
                        break;

                    case 4:
                        metodoPagoNegocio.eliminar(ddlElemento.SelectedIndex + 1);
                        break;

                    default:
                        break;
                }

                txtNombre.Text = "";
                txtDetalle.Text = "";
                txtDemora.Text = "";
                txtPrecio.Text = "";

                ddlEdicion.SelectedIndex = 0;
                ddlElemento.DataSource = "";
                ddlElemento.DataBind();

                btnAgregar.Enabled = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;

                lblResultado.Text = "Elemento Eliminado.";
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}