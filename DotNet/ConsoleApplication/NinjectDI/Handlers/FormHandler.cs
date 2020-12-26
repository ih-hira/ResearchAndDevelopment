using NinjectDI.Interfaces;

namespace NinjectDI.Handlers
{
    public class FormHandler
    {
        private readonly IMailSender mailSender;

        public FormHandler(IMailSender mailSender)
        {
            this.mailSender = mailSender;
        }

        public void Handle(string toAddress)
        {
            mailSender.Send(toAddress, "This is Ninject example");
        }
    }
}
