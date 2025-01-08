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

        // �������� ��� �������� ��������
        public List<������> ������� { get; set; } = new List<������>();

        public async Task OnGetAsync()
        {
            // �������� ���� �������� �� ���� ������
            ������� = await _context.������.ToListAsync();
        }

        public async Task<IActionResult> OnGetObjectInfoAsync(int id)
        {
            var ������ = await _context.������.FirstOrDefaultAsync(o => o.��������� == id);

            if (������ == null)
            {
                Console.WriteLine($"������ � id {id} �� ������");
                return new JsonResult(new { Error = "������ �� ������" });
            }

            Console.WriteLine($"������ ������: ����� = {������.�����}, ����� = {������.�����}, ������ = {������.������}");
            return new JsonResult(������);
        }

    }
}

