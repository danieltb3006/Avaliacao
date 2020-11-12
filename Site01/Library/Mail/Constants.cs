using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Mail
{
    public class Constants
    {
        //POP3, IMAP: ler msgs de email
        //SMTP: enviar e-mail

        //Autenticação - Gmail
        public readonly static string Usuario = "danieltb3006@gmail.com";
        public readonly static string Senha = "5x0p0t5o";

        //Servidor SMTP
        public readonly static string ServidorSMTP = "smtp.gmail.com";
        public readonly static int PortaSMTP = 587;

    }
}
