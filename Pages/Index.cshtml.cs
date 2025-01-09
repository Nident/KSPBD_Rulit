using KSPBD_Rulit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace KSPBD_Rulit.Pages

{
    [Authorize]  // ������������ ������ ������ �������������� �������������
    public class IndexModel : PageModel
    {
        private readonly Context _context;

        public IndexModel(Context context)
        {
            _context = context;
        }

        public List<������> ������� { get; set; } = new List<������>();

        // �������� ������ �� ��
        public async Task OnGetAsync()
        {
            ������� = await _context.������.ToListAsync();
        }

        // ����� ��� �������� �������
        public IActionResult OnPostDeleteObject(int id)
        {
            var ������ = _context.������.Find(id);
            if (������ != null)
            {
                _context.������.Remove(������);
                _context.SaveChanges();
                return RedirectToPage(); // ������������ �������� ����� ��������
            }

            // ���� ������ �� ������
            return RedirectToPage();
        }


        public async Task<IActionResult> OnGetObjectInfoAsync(int id)
        {
            var ������ = await _context.������.FirstOrDefaultAsync(o => o.��������� == id);

            if (������ == null)
            {
                return new JsonResult(new { Error = "������ �� ������" });
            }

            return new JsonResult(������);
        }


    }
}
