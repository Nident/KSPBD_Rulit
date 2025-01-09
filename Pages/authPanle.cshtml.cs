using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using KSPBD_Rulit.Models;

namespace KSPBD_Rulit.Pages
{
    public class authPanleModel : PageModel
    {
        private readonly Context _context;

        public authPanleModel(Context context)
        {
            _context = context;
        }

        [BindProperty]
        public string Login { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Введите логин и пароль.";
                return Page();
            }

            var user = await _context.Пользователи.FirstOrDefaultAsync(u => u.Login == Login);

            if (user == null || !BCrypt.Net.BCrypt.Verify(Password, user.CachePassword))
            {
                ErrorMessage = "Неверный логин или пароль.";
                return Page();
            }

            // Создание ClaimsPrincipal для пользователя
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role) // Указываем роль пользователя
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            // Перенаправление на главную страницу после успешного входа
            return RedirectToPage("/Index");
    

        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            // Очищаем куки аутентификации
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Перенаправляем на страницу логина
            return RedirectToPage("/authPanle");
        }

    }
}
