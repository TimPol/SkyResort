using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkiResort.Models;
using Microsoft.AspNetCore.Authorization;

namespace SkiResort
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			// получаем строку подключения из файла конфигурации
			string connection = Configuration.GetConnectionString("DefaultConnection");
			// добавляем контекст MobileContext в качестве сервиса в приложение
			services.AddDbContext<SkiResortContext>(options =>
				options.UseSqlServer(connection));
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
		   .AddCookie(options => //CookieAuthenticationOptions
				{
			   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
		   });
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseAuthentication();
			}

			app.UseMvc(routes => //Настройки маршрутизации
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
