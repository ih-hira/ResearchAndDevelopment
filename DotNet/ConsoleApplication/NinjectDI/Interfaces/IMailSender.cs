using System;
using System.Collections.Generic;
using System.Text;

namespace NinjectDI.Interfaces
{
    public interface IMailSender
    {
        void Send(string toAddress, string subject);
    }
}
