using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApiWallet.Contexts;
using WebApiWallet.Entities;
using WebApiWallet.Models;
using WebApiWallet.Models.Creacion;
using WebApiWallet.Services;

namespace WebApiWallet
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
            services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosAzure>();
            services.AddAutoMapper( configuration => {
                configuration.CreateMap<Analisis,AnalisisCreacionDTO>();
                configuration.CreateMap<Cartera,CarteraCreacionDTO>();
                configuration.CreateMap<Costes_fin,Costes_finCreacionDTO>();
                configuration.CreateMap<Costes_ini,Costes_iniCreacionDTO>();
                configuration.CreateMap<Costos_gastos,Costos_gastosCreacionDTO>();
                configuration.CreateMap<Empresa,EmpresaCreacionDTO>();
                configuration.CreateMap<Factura,FacturaCreacionDTO>();
                configuration.CreateMap<Letra,LetraCreacionDTO>();
                configuration.CreateMap<Recibo,ReciboCreacionDTO>();
                configuration.CreateMap<Tasa,TasaCreacionDTO>();

                configuration.CreateMap<Analisis,AnalisisCreacionDTO>().ReverseMap();
                configuration.CreateMap<Cartera,CarteraCreacionDTO>().ReverseMap();
                configuration.CreateMap<Costes_fin,Costes_finCreacionDTO>().ReverseMap();
                configuration.CreateMap<Costes_ini,Costes_iniCreacionDTO>().ReverseMap();
                configuration.CreateMap<Costos_gastos,Costos_gastosCreacionDTO>().ReverseMap();
                configuration.CreateMap<Empresa,EmpresaCreacionDTO>().ReverseMap();
                configuration.CreateMap<Factura,FacturaCreacionDTO>().ReverseMap();
                configuration.CreateMap<Letra,LetraCreacionDTO>().ReverseMap();
                configuration.CreateMap<Recibo,ReciboCreacionDTO>().ReverseMap();
                configuration.CreateMap<Tasa,TasaCreacionDTO>().ReverseMap();
            }, typeof(Startup));

            services.AddCors();
            services.AddDbContext<ApplicationSecurityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationSecurityDbContext>()
            .AddDefaultTokenProviders();
            services.AddResponseCaching();

            services.AddCors(options => { options.AddPolicy("All", builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*")); });
            services.AddControllers();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"])),
                    ClockSkew = TimeSpan.Zero
                }
            );
        
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiWallet", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "tomsAuth"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiWallet v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseResponseCaching();
            app.UseAuthentication();
            app.UseCors("All");
        }
    }
}
