using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Assignment
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();

            //Custom Middleware
            app.UseMyCustomMiddleware();

            //Middleware
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync(_configuration["MyKey"] );
                await context.Response.WriteAsync("\n Hello World main!(before)\n");
                await next();
                await context.Response.WriteAsync("Hello World main! (after)\n");
            });

            //nested maps
            app.Map("/map1",
                FirstMiddleware => FirstMiddleware.Map("/map1a",
                SecondMiddleware => SecondMiddleware.Run(async (context) =>
                await context.Response.WriteAsync("Hello from Nested Middleware\n"))));

            //Map Delegate
            app.Map("/map", HandleMap);

            //MapWhen for conditional non-rejoining branching 
            app.MapWhen(context => context.Request.Query.ContainsKey("branch"), HandleBranch);

            //UseWhen for conditional rejoining branching 
            app.UseWhen(
                context => context.Request.Path.StartsWithSegments(new PathString("/UseWhen")),
                a => a.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("Hello World From UseWhen (before)!\n");
                    await next();
                    await context.Response.WriteAsync("Hello World From UseWhen (after)!\n");
                }));

            //Terminal middleware (Run)
            app.Run(TerminalMiddleware);          
        }

        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}\n");
            });
        }
       
        private static void HandleMap(IApplicationBuilder app)
        {
            app.Use(async (context, next)=>
            {
                await context.Response.WriteAsync("Map segment 1.(before)\n");
                await next();
                await context.Response.WriteAsync("Map segment 1.(after)\n");
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from Run C.\n");
                
            });

        }

        private async Task TerminalMiddleware(HttpContext context)
        {
            await context.Response.WriteAsync("Hello World From Terminal Middleware!\n");
        }

    }
}
