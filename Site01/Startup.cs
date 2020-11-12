using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Site01.Database;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Site01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<DatabaseContext>(options => {
                //Providers: conex�es com banco de dados
                
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=site01;Integrated Security=True;");
            });

            
            services.AddDistributedMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // ******* ROTAS ***********//

            //dom�nio         controlador (tem que ter uma classe dentro do dir. "Controllers") 
            //www.site.com.br/noticia/visualizar/acidentes-de-carro-nas-rodovias (id? pode ser um nro)
            //                        a��o (Action)
            // Exemplos
            //www.site.com.br/cliente/lista
            //www.site.com.br/cliente/deletar/30
            //Rota padr�o: {dominio}/{Controllers=Home}/{Action=Index}/{id?}
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            

            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });*/
        }
    }
}