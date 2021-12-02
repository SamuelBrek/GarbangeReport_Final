using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Garbange.Infraestructure.Data;
using Garbange.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Garbange.Domain.Entities;
using Garbange.Domain.Interfaces;
using Garbange.Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Garbange.Application.Services;
using FluentValidation;
using Garbange.Domain.Dtos.Requests;
using Garbange.Infraestructure.Validators;

namespace Garbange.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Garbange.Api", Version = "v1" });

            });
            services.AddDbContext<Garbange4BContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GarbangeProject")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDenunciaService, DenunciaService>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IRegistroService, RegistroService>();
            services.AddTransient<IDenunciaRepository, DenunciaSQLrepositorie>();
            services.AddTransient<IEventoRepository, EventoSQLrepositorie>();
            services.AddTransient<IRegistroRepository, RegistroSQLrepositorie>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IValidator<DenunciaCreateRequest>, DenunciaCreateRequestValidator>();
            services.AddScoped<IValidator<DenunciaUpdateRequest>, DenunciaUpdateRequestValidator>();
            services.AddScoped<IValidator<RegistroCreateRequest>, RegistroCreateRequestValidator>();
            services.AddScoped<IValidator<RegistroUpdateRequest>, RegistroUpdateRequestValidator>();
            services.AddScoped<IValidator<EventoCreateRequest>, EventoCreateRequestValidator>();
            services.AddScoped<IValidator<EventoUpdateRequest>, EventoUpdateRequestValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Garbange.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
