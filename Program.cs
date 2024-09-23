using HTTPswagerTEST.Models;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace HTTPswagerTEST
{



	public class Program
	{

		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddDbContext<UsersContext>(options => 
					options.UseInMemoryDatabase("Userss"));


			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Список пользователей",
					Description = "Список пользователей с возможностью редактирования",
				});

				var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
			});

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}



			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();


			app.Run();
		}
	}
}
