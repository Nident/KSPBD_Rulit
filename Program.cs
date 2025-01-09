using Microsoft.AspNetCore.Authentication.Cookies;
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

            // Настройка аутентификации с использованием Cookie
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/authPanle";  // Указание пути к странице авторизации
                    options.AccessDeniedPath = "/authPanle";  // Указание страницы для отказа в доступе
                });


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

            // Подключение аутентификации и авторизации
            app.UseAuthentication();
            app.UseAuthorization();

            // Перенаправление на authPanle как стартовую страницу
            app.MapGet("/", async context =>
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    context.Response.Redirect("/Index");  // Перенаправление на Index, если пользователь уже авторизован
                }
                else
                {
                    context.Response.Redirect("/authPanle");  // Перенаправление на authPanle, если пользователь не авторизован
                }
                await Task.CompletedTask;
            });



            app.MapRazorPages();

            app.Run();
        }
    }
}
