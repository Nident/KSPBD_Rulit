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

        // Свойство для хранения объектов
        public List<Объект> Объекты { get; set; } = new List<Объект>();

        public async Task OnGetAsync()
        {
            // Загрузка всех объектов из базы данных
            Объекты = await _context.Объект.ToListAsync();
        }

        public async Task<IActionResult> OnGetObjectInfoAsync(int id)
        {
            var объект = await _context.Объект.FirstOrDefaultAsync(o => o.ИдОбьекта == id);

            if (объект == null)
            {
                Console.WriteLine($"Объект с id {id} не найден");
                return new JsonResult(new { Error = "Объект не найден" });
            }

            Console.WriteLine($"Объект найден: Район = {объект.Район}, Улица = {объект.Улица}, Статус = {объект.Статус}");
            return new JsonResult(объект);
        }

    }
}

