using AutoMapper;
using Manage.Logger;
using Manage.Model.Context;
using Manage.Repository.Base.IRepository;
using Manage.Repository.Base.Repository;
using Manage.Service.IService;
using Manage.Service.Service;
using Manage.Service.ServiceBase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;


namespace Manage.API
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "Origins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200/")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowAnyOrigin();
                    });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddDbContext<DatabaseContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("database"),b=>b.MigrationsAssembly("Manage.API")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manage", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,// = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            services.AddAuthentication(otp =>
            {
                otp.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                otp.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
          .AddJwtBearer(options =>
          {
              options.RequireHttpsMetadata = false;
              options.SaveToken = true;
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = false,
                  ValidateAudience = false,
                  //ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  //ValidIssuer = issuer,
                  //ValidAudience = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                  ClockSkew = TimeSpan.Zero
              };
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manage v1"));
            }
            app.UseMiddleware<LoggingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
