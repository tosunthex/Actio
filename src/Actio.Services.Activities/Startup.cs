using Actio.Common.Commands;
using Actio.Common.RabbitMq;
using Actio.Common.Mongo;
using Actio.Services.Activities.Domains.Repositories;
using Actio.Services.Activities.Handlers;
using Actio.Services.Activities.Repositories;
using Actio.Services.Activities.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Actio.Services.Activities
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddMongoDb(Configuration);
            services.AddRabitMq(Configuration);
            services.AddScoped<ICommandHandler<CreateActivity>, CreateActivityHandler>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDatabaseSeeder, CustomMongoSeeder>();

            var serviceProvider = services.BuildServiceProvider();
            var databaseInitialize = serviceProvider.GetService<IDatabaseInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}
