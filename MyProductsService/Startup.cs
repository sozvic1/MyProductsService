using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductsBusinessLayer;
using ProductsBusinessLayer.AutService;
using ProductsBusinessLayer.MapperProfile;
using ProductsBusinessLayer.Services.HashService;
using ProductsBusinessLayer.Services.ProductService;
using ProductsBusinessLayer.Services.RegistrationService;
using ProductsBusinessLayer.Services.SmtpService;
using ProductsBusinessLayer.Services.UserService;
using ProductsCore.Options;
using ProductsDataLayer;
using ProductsDataLayer.Repositories.EmailRepository;
using ProductsDataLayer.Repository.ProductRepository;
using ProductsDataLayer.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyProductsService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFCoreContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:Default"]));
            var assamblies = new[]
            {
                Assembly.GetAssembly(typeof(ProductsProfile))
            };
            var authOptions = Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>();
            services.Configure<AuthOptions>(Configuration.GetSection(nameof(AuthOptions)));
            services.Configure<SmtpOptions>(Configuration.GetSection(nameof(SmtpOptions)));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {                            
                            ValidateIssuer = true,                           
                            ValidIssuer = authOptions.Issuer,
                            ValidateAudience = true,                         
                            ValidAudience = authOptions.Audience,                         
                            ValidateLifetime = true,
                            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(authOptions.SecretKey)),                        
                            ValidateIssuerSigningKey = true,
                        };
                    });
            services.AddSignalR();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISmtpService, SmtpService>();
            services.AddControllersWithViews();
            services.AddAutoMapper(assamblies);
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IProductReposirory, ProductRepositoryDb>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddControllers();
            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
              
            });
          
        }
    }
}
