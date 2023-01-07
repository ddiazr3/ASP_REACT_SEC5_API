using Api.Controllers;
using System.Diagnostics;

namespace Api.Services
{
    public class LocalMailService : IMailService
    {
        private ILogger<LocalMailService> _logger;
        private IConfiguration _configuracion;
        public LocalMailService(IConfiguration configuration, ILogger<LocalMailService> logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuracion = configuration ?? throw new ArgumentNullException(nameof(logger)); ;
        }


        public void send(string subject, string message)
        {

            Debug.WriteLine($"Meail enviado de {_configuracion["mailSetting:mailFromAddres"]} a {_configuracion["mailSetting:mailToAddres"]} LocalMailService");
            Debug.WriteLine($"Asunto: {subject}");
            Debug.WriteLine($"Mensaje: {message}");

        }

    }
}
