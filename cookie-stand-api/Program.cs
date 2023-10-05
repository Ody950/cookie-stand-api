
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using cookie_stand_api.Data;
using cookie_stand_api.Models.Interfaces;
using cookie_stand_api.Models.Services;


            var builder = WebApplication.CreateBuilder(args);

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.
            builder.Services.AddDbContext<SalmonDbContext>(options =>
            {
                options.UseSqlServer(connString);
            });

            builder.Services.AddTransient<ICookieStand, CookieStandService>();


            builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger(aptions =>
            {
                aptions.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(aptions =>
            {
                aptions.SwaggerEndpoint("/api/v1/swagger.json", "Salmon");
                aptions.RoutePrefix = "docs";
            });


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        

























