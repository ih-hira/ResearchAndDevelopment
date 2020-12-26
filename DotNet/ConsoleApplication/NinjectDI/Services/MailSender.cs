using NinjectDI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjectDI.Services
{
    public class MailSender : IMailSender
    {
        public void Send(string toAddress, string subject)
        {
            Console.WriteLine($"Sending mail to [{toAddress}] with subject [{subject}]");
        }
    }
}
