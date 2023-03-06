using System.Collections.Generic;

namespace Services
{
    public class MailDto
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class MailSendinblue
    {
        public UserMail Sender { get; set; }
        public List<UserMail> to { get; set; }
        public string HtmlContent { get; set; }
        public string Subject { get; set; }
    }

    public class UserMail
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}