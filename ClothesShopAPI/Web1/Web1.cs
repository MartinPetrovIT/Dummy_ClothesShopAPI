using System;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Data;
using ClothesShop.Logic.Interfaces.Auth.Services;
using ClothesShop.Logic.Interfaces.Dress.Services;
using ClothesShop.Logic;
using ClothesShoAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Web1
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance.
    /// </summary>
    internal sealed class Web1 : StatelessService
    {
        public Web1(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        var builder = WebApplication.CreateBuilder();
                           builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                      .AddJwtBearer(options =>
                                      {
                                          options.TokenValidationParameters = new TokenValidationParameters
                                          {
                                              ValidateIssuer = true,
                                              ValidateAudience = true,
                                              ValidateLifetime = true,
                                              ValidateIssuerSigningKey = true,
                                              ValidIssuer = builder.Configuration["Jwt:Issuer"],
                                              ValidAudience = builder.Configuration["Jwt:Issuer"],
                                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                                          };
                                      });
                          builder.Services.AddCors(options =>
                                                   {
                                                       options.AddDefaultPolicy(
                                                                         policy =>
                                                                         {
                                                                             policy.AllowAnyOrigin()
                                                                             .AllowAnyHeader()
                                                                             .AllowAnyMethod();
                                                                         });
                                                   });
                          builder.Services.AddDbContext<ApplicationDBContext>(options =>
                          {
                              options.UseSqlServer("Server=.;Database=ClothesShop;User Id=marto1;Password=marto1;",
                                  b => b.MigrationsAssembly("ClothesShop.Database"));
                          });

                        builder.Services.AddSingleton<StatelessServiceContext>(serviceContext);
                        builder.WebHost
                                    .UseKestrel()
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url);
                        
                        // Add services to the container.
                                   builder.Services.AddTransient<IDressService, DressService>();
                                   builder.Services.AddTransient<IAuthService, AuthService>();   
                        
                        builder.Services.AddControllers();
                        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                        builder.Services.AddEndpointsApiExplorer();
                        builder.Services.AddSwaggerGen();
                        
                        var app = builder.Build();
                        
                        // Configure the HTTP request pipeline.
                        if (app.Environment.IsDevelopment())
                        {
                            app.UseSwagger();
                            app.UseSwaggerUI();
                        }


                        app.UseCors();

                        app.UseAuthorization();
                        
                        app.MapControllers();
                        
                        return app;


                    }))
            };
        }
    }
}
