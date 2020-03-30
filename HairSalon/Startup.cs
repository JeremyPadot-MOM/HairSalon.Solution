using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;

namespace HairSalon
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

    //New code
    services.AddEntityFrameworkMySql()
        .AddDbContext<HairSalonContext>(options => options
        .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}");
      });
        app.UseStaticFiles();
        app.Run(async (context) =>
        {
          await context.Response.WriteAsync("Something went wrong!");
        });

    }
  }
}