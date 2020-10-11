using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RSoft.Mail.Business.Contracts;
using RSoft.Mail.Business.Enums;
using RSoft.Mail.Business.Options;
using RSoft.Mail.Business.Repositories;
using RSoft.Mail.Business.Senders;
using RSoft.Mail.Business.Services;
using SendGrid;
using System;

namespace RSoft.Mail.Business.IoC
{

    /// <summary>
    /// Privides Dependency Injection methods
    /// </summary>
    public static class DependencyInjection
    {

        /// <summary>
        /// Add mail services into service collection object
        /// </summary>
        /// <param name="services">Service collection object</param>
        /// <param name="configuration">Configuration parameters object</param>
        public static IServiceCollection AddMailServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<SmtpOptions>(options => configuration.GetSection("Sender:Smtp").Bind(options));
            services.Configure<SendGridOptions>(options => configuration.GetSection("Sender:SendGrid").Bind(options));
            services.Configure<RedirectToOptions>(options => configuration.GetSection("Sender:RedirectTo").Bind(options));
            services.Configure<SenderOptions>(options => configuration.GetSection("Sender").Bind(options));
            
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<IMailService, MailService>();


            SenderOptions options = new SenderOptions();
            configuration.Bind("Sender", options);
            switch (options.Type)
            {
                case SenderType.Smtp:
                    //BACKLOG: NotImplementedException
                    throw new NotImplementedException();
                    break;
                case SenderType.SendGrid:
                    services.AddScoped<ISender, SendGridSender>();
                    services.AddScoped<ISendGridClient>(s => new SendGridClient(options.SendGrid.AppKey));
                    break;
            }

            return services;

        }

    }

}
