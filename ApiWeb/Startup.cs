using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ApiWeb.Infrastructure;
using ApiWeb.Mapper;
using ApiWeb.Repository;
using ApiWeb.Repository.IRepository;
using AutoMapper;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ApiWeb
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
            services.AddScoped<IContactoRepository, ContactoRepository>();
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddDbContext<ProductosDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(ContactoMapper));
            services.AddAutoMapper(typeof(GrupoMapper));
            services.AddAutoMapper(typeof(ProductoMapper));
            services.AddAutoMapper(typeof(ProveedorMapper));
            services.AddAutoMapper(typeof(UnidadMedidaMapper));
            services.AddAutoMapper(typeof(UsuarioMapper));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:TokenKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            //Parte para utilizar swagger y documentar la API
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("UsuariosProductosAPI", new OpenApiInfo()
                {
                    Title = "Usuarios Productos API",
                    Description = "Contiene los usuarios de la aplicación",
                    Version = "1.0",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "cris_up@outlook.com",
                        Name = "Cristhian Ubaldo Promotor",
                        Url = new Uri("https://axsistecnologia.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "BSD",
                        Url = new Uri("https://bsd.axsistec.com")
                    }
                });

                options.SwaggerDoc("UnidadesMedidaProductosAPI", new OpenApiInfo()
                {
                    Title = "Catalogos Generales API",
                    Description = "Contiene las unidades de medida del sat para los productos",
                    Version = "1.0",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "cris_up@outlook.com",
                        Name = "Cristhian Ubaldo Promotor",
                        Url = new Uri("https://axsistecnologia.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "BSD",
                        Url = new Uri("https://bsd.axsistec.com")
                    }
                });

                var XMLComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var APIRutaComentarios = Path.Combine(AppContext.BaseDirectory, XMLComentarios);
                options.IncludeXmlComments(APIRutaComentarios);

                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authentication",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                         new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            }, new List<string>()
                    }
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //options.SwaggerEndpoint("/swagger/CatalogosAPI/swagger.json", "Catalogos generales API");
                options.SwaggerEndpoint("swagger/UsuariosProductosAPI/swagger.json", "Usuarios API");
                options.SwaggerEndpoint("swagger/UnidadesMedidaProductosAPI/swagger.json", "Undades de medida de los productos API");
                options.RoutePrefix = "";
            });
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
    }
}
