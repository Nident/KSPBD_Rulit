using KSPBD_Rulit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KSPBD_Rulit.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Context _context;

        public IndexModel(Context context)
        {
            _context = context;
        }

        public List<Объект> Объекты { get; set; } = new List<Объект>();

        // Загрузка данных из БД
        public async Task OnGetAsync()
        {
            Объекты = await _context.Объект.ToListAsync();
        }

        // Метод для удаления объекта
        public IActionResult OnPostDeleteObject(int id)
        {
            var объект = _context.Объект.Find(id);
            if (объект != null)
            {
                _context.Объект.Remove(объект);
                _context.SaveChanges();
                return RedirectToPage(); // Перезагрузка страницы после удаления
            }

            // Если объект не найден, можно вернуть ошибку или просто обновить страницу
            return RedirectToPage();
        }

    }
}
