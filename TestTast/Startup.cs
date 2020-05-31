using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;
using TestTask.Common;
using TestTask.Common.Models;
using TestTask.DataAccess;
using TestTask.DataAccess.UnitOfWork;
using TestTask.Services;

namespace TestTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<TestTaskDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var response = new BadRequestObjectResult(new ErrorDetails(context.ModelState));
                    response.ContentTypes.Add("application/problem+json");
                    return response;
                };
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "api/documentation";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoJam API v1");
                options.DocExpansion(DocExpansion.List);
                options.DisplayRequestDuration();
                options.EnableFilter();
            });
        }
    }
}
