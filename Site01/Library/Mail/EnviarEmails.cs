using Site01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Site01.Library.Mail
{
    public class EnviarEmails
    {
        public static void EnviarMensagemContato(Contato contato)
        {
            //Configurar servidor SMTP
            string conteudo = string.Format("Nome: {0}<br /> Email: {1}<br /> Assunto: {2}<br /> Mensagem: {3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);

            SmtpClient smtp = new SmtpClient(Constants.ServidorSMTP, Constants.PortaSMTP);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Constants.Usuario, Constants.Senha);
            //Mensagem de email
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("danieltb3006@gmail.com");
            mensagem.To.Add("danieltb3006@gmail.com");
            mensagem.Subject = "Formulário de Contato";
            mensagem.IsBodyHtml = true;
            mensagem.Body = "<h1>Formulário de Contato</h1>" + conteudo;
            smtp.Send(mensagem);
        }
    }
}
