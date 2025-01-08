using Microsoft.EntityFrameworkCore;
using KSPBD_Rulit.Models; // Пространство имён с вашим Context

namespace KSPBD_Rulit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Получаем строку подключения из файла конфигурации
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // Регистрируем DbContext
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(connection));

            // Добавляем Razor Pages
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Создаём базу данных или применяем миграции
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
                SeedCl.Seed(dbContext); 
            }

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }
    }
}
