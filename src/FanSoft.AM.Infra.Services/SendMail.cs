using FanSoft.AM.Domain.Contracts.Infra.Service;
using FanSoft.AM.Domain.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FanSoft.AM.Infra.Services
{
    public class SendMail : ISendMail
    {
        private readonly SMTPServer _smtpServer;
        public SendMail(IConfiguration config)
        {
            _smtpServer = new SMTPServer();

            new ConfigureFromConfigurationOptions<SMTPServer>(
                config.GetSection("SMTPServer"))
                    .Configure(_smtpServer);
        }

        public async Task Send(EMailMessage data)
        {

            if (!_smtpServer.Ativo)
                return;

            var smtpClient = new SmtpClient
            {
                Host = _smtpServer.Server,
                Port = _smtpServer.Port,
                EnableSsl = _smtpServer.SSL,
                Credentials = new NetworkCredential(_smtpServer.Email, _smtpServer.Senha)
            };

            using (var message = new MailMessage(_smtpServer.Email, data.To)
            {
                Subject = data.Subject,
                Body = data.Body
            })
            {

                try
                {
                    await smtpClient.SendMailAsync(message);
                }
                catch
                {
                    return;
                }
            }
        }

        private class SMTPServer
        {
            public bool Ativo { get; set; }
            public string Server { get; set; }
            public int Port { get; set; }
            public bool SSL { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
        }
    }
    
}
