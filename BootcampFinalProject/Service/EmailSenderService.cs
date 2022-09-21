using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace BootcampFinalProject.Service
{
    public class EmailSenderService : IHostedService, IDisposable
    {
        private readonly IServiceProvider serviceProvider;
        private int executionCount = 0;
        private readonly ILogger<EmailSenderService> logger;
        private Timer _timer = null!;

        public EmailSenderService(ILogger<EmailSenderService> logger, IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Timed Hosted Service running.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);
            var randomGenerator = new Random();
            using (var scope = serviceProvider.CreateScope()) {
            var mailService = scope.ServiceProvider.GetService<IMailService>();
                logger.LogInformation("Checking emails {Count} th time");
                var mails = mailService.GetWaitingMails();
                foreach (var mail in mails)
                {
                    randomGenerator.Next(1,5);
                    if(randomGenerator.Next(1,5) == 1)
                    {
                        mail.Status = "Sent";
                    }
                    else
                    {
                        mail.Status = "Failed";
                        mail.Attempt++;
                    }
                    mailService.Update(mail.Id, mail);
                }
            }         
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Timed Hosted Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
