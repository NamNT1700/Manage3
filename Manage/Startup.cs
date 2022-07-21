using Manage.Model.Context;
using Manage.Repository.Base.IRepository;
using Manage.Repository.Base.IRepository.IWrapper;
using Manage.Repository.Base.Repository;
using Manage.Repository.Base.Repository.Wrapper;
using Manage.Service.IService;
using Manage.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            services.AddScoped<IHuAllowanceRepositoryWrapper, HuAllowanceRepositoryWrapper>();
            services.AddScoped<IHuBankRepositoryWrapper, HuBankRepositoryWrapper>();
            services.AddScoped<IHuContractRepositoryWapper, HuContractRepositoryWapper>();
            services.AddScoped<IHuHospitalRepositoryWrapper, HuHospitalRepositoryWrapper>();
            services.AddScoped<IHuNationRepositoryWrapper, HuNationRepositoryWrapper>();
            services.AddScoped<IHuTitleRepositoryWrapper, HuTitleRepositoryWrapper>();


            services.AddScoped<IUserRepositoryWrapper, UserRepositoryWrapper>();
            services.AddScoped<IAllowanceService, AllowanceService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<INationService, NationService>();
            services.AddScoped<ITitleService, TitleService>();

            services.AddDbContext<DatabaseContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("database"),b=>b.MigrationsAssembly("Manage.API")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manage", Version = "v1" });
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
