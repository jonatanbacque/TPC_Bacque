using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CorreoNegocio
    {
        ElementoNegocio elementoNegocio = new ElementoNegocio();
        EnvioNegocio envioNegocio = new EnvioNegocio();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        private SmtpClient cliente;
        private MailMessage email;
        private string encabezado = "<html lang=en>" +
                        "<head>" +
                        "<link rel=stylesheet href=https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css >" +
                        "</head>" +
                        "<body>" +
                        "<table align=center>" +
                        "<tr>" +
                        "<td>" +
                        "<div align=center>" +
                        "<img src=https://ss-static-01.esmsv.com/id/117805/galeriaimagenes/obtenerimagen/?width=75&height=75&id=sitio_logo&ultimaModificacion=2020-11-14+07%3A28%3A53 >" +
                        "</div>" +
                        "<h1>Aleli Esencias </h1>";
        private string firma = "<hr/>" +
                        "<span>Ante cualquier inquietud, contactate vía e-mail a: </span>" +
                        "<a class=btn-primary href=mailto:aleli.esencias@gmail.com>aleli.esencias@gmail.com</a> " +
                        "<br/>" +
                        "<a class=btn-primary href=wa.link/4evh7f >" +
                        "<img src=https://cdn.icon-icons.com/icons2/1945/PNG/128/iconfinder-whatsapp-4661617_122497.png width=20 height=20>" +
                        "1135228893" +
                        "</a>" +
                        "<br/>" +
                        "<br/>" +
                        "<span>Muchas gracias!<span>" +
                        "<br/>" +
                        "<a class=btn-primary href=www.aleliesencias.com.ar>Aleli Esencias</a> " +
                        "</td>" +
                        "</tr>" +
                        "</table>" +
                        "<script src = https://code.jquery.com/jquery-3.5.1.min.js ></script>" +
                        "<script src = https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js ></script>" +
                        "<script src = https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js ></script>" +
                        "</body>" +
                        "</html>";

        private void conectar()
        {
            cliente = new SmtpClient("smtp.gmail.com", 587);
            cliente.Credentials = new NetworkCredential(usuarioNegocio.adminlistar().persona.Email, usuarioNegocio.adminlistar().Password);
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.EnableSsl = true;
        }

        public void AltaUsuario(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    conectar();
                    string body = encabezado +
                        "<h3>Estimad@ " + usuario.persona.Apellido + " " + usuario.persona.Nombre + " recibimos su registro.</h3>" +
                        "<h4>Su usuario es " + usuario.Nombre + ".</h4>" +
                        "<h4>Su password es " + usuario.Password + ".</h4>" + firma;

                    email = new MailMessage();
                    email.From = new MailAddress(usuarioNegocio.adminlistar().persona.Email, "Aleli Esencias");
                    email.To.Add(new MailAddress(usuario.persona.Email));
                    email.Subject = "Bienvenido a Aleli Esencias";
                    email.IsBodyHtml = true;
                    email.Body = body;

                    cliente.Send(email);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void clienteCompra(Usuario usuario, Compra compra)
        {
            try
            {
                if (usuario != null)
                {
                    conectar();

                    var body = new System.Text.StringBuilder();

                    body.AppendLine(
                        "<h3>Estimad@ " + usuario.persona.Apellido + " " + usuario.persona.Nombre + ", gracias por elegirnos!</h3>" +
                        "<br/>" +
                        "<h4>Detalle:</h4>" +
                        "<br/>" +
                        "<table class=table>" +
                        "<colgroup span = 4 ></colgroup>" +
                        "<tr>" +
                        "<th>Nombre</th>" +
                        "<th>Cantidad</th>" +
                        "<th>Precio</th>" +
                        "</tr>");

                    foreach (var item in elementoNegocio.listarID(compra.carrito.Id))
                    {
                        body.AppendLine(
                            "<tr>" +
                            "<td>" + item.articulo.Producto + "</td>" +
                            "<td>" + item.Cantidad + "</td>" +
                            "<td>$" + item.articulo.Precio + "</td>" +
                            "</tr>");
                    };

                    body.AppendLine("</table>" +
                        "<br/>" +
                        "<span> Total: $" + compra.ImporteFinal + ".</span>" +
                        "<br/>" +
                        "<span> Método de envío: " +
                        envioNegocio.listarID(compra.envio.Id).metodoEnvio + ".</span>" +
                        "<br/>" +
                        "<span> Fecha estimada de entrega: " + envioNegocio.listarID(compra.envio.Id).fechaEntrega.ToShortDateString() + ".</span>");

                    email = new MailMessage();
                    email.From = new MailAddress(usuarioNegocio.adminlistar().persona.Email, "Aleli Esencias");
                    email.To.Add(new MailAddress(usuario.persona.Email));
                    email.Subject = "Aleli Esencias: Nueva compra.";
                    email.IsBodyHtml = true;
                    email.Body = encabezado + body.ToString() + firma;

                    cliente.Send(email);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void adminCompra(Usuario usuario, Compra compra)
        {
            try
            {
                if (usuario != null)
                {
                    conectar();

                    var body = new System.Text.StringBuilder();

                    body.AppendLine(
                        "<h3>El cliente " + usuario.persona.Apellido + " " + usuario.persona.Nombre + ", realizó una compra.</h3>" +
                        "<br/>" +
                        "<h4>Detalle:</h4>" +
                        "<br/>" +
                        "<table class=table>" +
                        "<colgroup span = 4 ></colgroup>" +
                        "<tr>" +
                        "<th>Nombre</th>" +
                        "<th>Cantidad</th>" +
                        "<th>Precio</th>" +
                        "</tr>");

                    foreach (var item in elementoNegocio.listarID(compra.carrito.Id))
                    {
                        body.AppendLine(
                            "<tr>" +
                            "<td>" + item.articulo.Producto + "</td>" +
                            "<td>" + item.Cantidad + "</td>" +
                            "<td>$" + item.articulo.Precio + "</td>" +
                            "</tr>");
                    };

                    body.AppendLine("</table>" +
                        "<br/>" +
                        "<span> Total: $" + compra.ImporteFinal + ".</span>" +
                        "<br/>" +
                        "<span> Método de envío: " +
                        envioNegocio.listarID(compra.envio.Id).metodoEnvio + ".</span>" +
                        "<br/>" +
                        "<span> Fecha estimada de entrega: " + envioNegocio.listarID(compra.envio.Id).fechaEntrega.ToShortDateString() + ".</span>");

                    email = new MailMessage();
                    email.From = new MailAddress(usuarioNegocio.adminlistar().persona.Email, "Aleli Esencias");
                    email.To.Add(new MailAddress(usuarioNegocio.adminlistar().persona.Email));
                    email.Subject = "Aleli Esencias: Nueva compra.";
                    email.IsBodyHtml = true;
                    email.Body = encabezado + body.ToString() + firma;

                    cliente.Send(email);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
