using System.Diagnostics;

namespace Api.Services
{
    public class CloudMailService : IMailService
    {
        private string _emailTo = "admin@gmail.com";
        private string _emailFrom = "noreply@gmail.com";

        public void send(string subject, string message)
        {

            Debug.WriteLine($"Meail enviado de {_emailFrom} a {_emailTo } CloudMailService");
            Debug.WriteLine($"Asunto: {subject}");
            Debug.WriteLine($"Mensaje: {message}");

        }
    }
}
