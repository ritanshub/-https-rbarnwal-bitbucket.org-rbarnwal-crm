using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravelCRMServices
{
    public class EmailSenderService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
