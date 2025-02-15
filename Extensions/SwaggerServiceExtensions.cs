﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.Extensions
{
    public static class SwaggerServiceExtensions
    {

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "certs", Version = "v1" });
            });

            return services;

        }

        public static IApplicationBuilder UseSwaggerDocumention(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "certs v1"));

            return app;

        }
    }
}
