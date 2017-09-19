using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Projeto.Web.Models;
using System.Net;

namespace Projeto.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SendEmail(HomeViewModel model)
        {
            try
            {
                MailAddress from = new MailAddress("raphaelportfolio22@gmail.com", "Raphael portfolio");
                MailAddress to = new MailAddress("raphael.2205@gmail.com", "Raphael Gmail");
                MailMessage message = new MailMessage(from, to);
                
                message.Subject = "Contato portfolio";
                message.Body = $"Nome: {model.name} \n" +
                               $"Email: {model.email} \n" +
                               $"Telefone: {model.phone} \n" +
                               $"Mensagem: {model.message}";
                
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true; // GMail requer SSL
                smtp.Port = 587;       // porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                // seu usuário e senha para autenticação
                smtp.Credentials = new NetworkCredential("raphaelportfolio22@gmail.com", "raphael22");

                smtp.Send(message);

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json("sucesso");
        }

        public ActionResult DashboardVendas()
        {
            return View();
        }


    }
}