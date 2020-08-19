using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ordering.API.RabbitMQ;

namespace Ordering.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private static EventBusRabbitMQConsumer Listener { get; set; }

        public static IApplicationBuilder UseRabbitMQListener(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<EventBusRabbitMQConsumer>();
            var lifecycle = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            lifecycle.ApplicationStarted.Register(OnStarted);
            lifecycle.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            Listener.Consume();
        }

        private static void OnStopping()
        {
            Listener.Disconnect();
        }
    }
}
