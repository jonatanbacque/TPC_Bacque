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
        private SmtpClient cliente;
        private MailMessage email;
        void conectar()
        {
            cliente = new SmtpClient("smtp.gmail.com", 587);
            cliente.Credentials = new NetworkCredential("jonatanbacque@gmail.com", "Klapaus1");
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
                    string body ="<html lang=es>" +
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
                        "<h1> Bienvenido al eCommerce de Aleli Esencias </h1>" +
                        "<h5> Estimado " + usuario.persona.Apellido + " " + usuario.persona.Nombre + " recibimos su registro.</h5>" +
                        "<h6> Su usuario es " + usuario.Nombre + ".</h6>" +
                        "<h6> Su password es " + usuario.Password + ".</h6>" +
                        "<h6> Esperamos tenga una grata experiencia de compra.</h6>" +
                        "<hr/" +
                        "<span> Agradecemos su visita y le enviamos saludos cordiales.</span>" +
                        "</td>" +
                        "</tr>" +
                        "</table>" +
                        "<script src = https://code.jquery.com/jquery-3.5.1.min.js ></script>" +
                        "<script src = https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js ></script>" +
                        "<script src = https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js ></script>" +
                        "</body>" +
                        "</html>";

                    email = new MailMessage();
                    email.From = new MailAddress("jonatanbacque@gmail.com", "Aleli Esencias");
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
    }
}
