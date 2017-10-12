namespace LoggingMicroservice
{
    using System.Reflection;
    using LoggingMicroservice.Config;
    using LoggingMicroservice.Core;
    using LoggingMicroservice.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using NSwag.AspNetCore;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services, ILoggerFactory logger)
        {
            services.AddMvc(o =>
            {
                o.Filters.Add(new GlobalExceptionFilter(logger));
            });

            services.AddSingleton<IMessageLog, TextFileMessageLog>();

            services.Configure<MessageLogOptions>(Configuration.GetSection("MessageLog"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, new SwaggerUiSettings());
        }
    }
}
