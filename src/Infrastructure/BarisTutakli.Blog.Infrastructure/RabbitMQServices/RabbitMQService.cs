using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Application.Wrappers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace BarisTutakli.Blog.Infrastructure.RabbitMQServices
{
    public class RabbitMQService:IRabbitMQService
    {
        private IConfiguration _configuration;
        public ConnectionFactory _factory { get; private set; }
        public RabbitMQService(IConfiguration configuration,ConnectionFactory connectionFactory)
        {
            _configuration = configuration;
            _factory = connectionFactory;
        }
        public Response SendEmailIntoQueue(MailResponse mailResponse)
        {
            //Mail settings will be added
            var mail = new MailMessage();
            mail.Sender = new MailAddress("", "s");
            mail.To.Add(new MailAddress(mailResponse.ToEmail, "ss"));
            mail.Subject = mailResponse.Subject;
            mail.Body = mailResponse.Body;
            mail.From = new MailAddress("", "ss");
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            try
            {
                Publish(mail);
            }
            catch (Exception e)
            {

                throw new Exception(message: e.Message);
            }

            return new Response { Message="succeeded" };
        }
        private void Publish(MailMessage mailMessage)
        {
            IConnection connection = _factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: "Mails",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mailMessage, formatting: Formatting.Indented));

            channel.BasicPublish(exchange: "",
                 routingKey: "Mails",
                 basicProperties: null,
                 body: body);
        }

       
    }
}
