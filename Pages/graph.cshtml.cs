using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KSPBD_Rulit.Models;

namespace KSPBD_Rulit.Pages
{
    public class graphModel : PageModel
    {
        private readonly Context _context;

        public graphModel(Context context)
        {
            _context = context;
        }

        public IList<ПланРабот> ПланРабот { get; set; }

        // Для работы с объединенными данными
        public IList<workPlanTable> WorkPlanTable { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ПланРабот = await _context.ПланРабот.ToListAsync();

            WorkPlanTable = await (from workPlan in _context.ПланРабот
                                   join section in _context.Секция
                                   on workPlan.СекцияId equals section.ИдСекции
                                   select new workPlanTable
                                   {
                                       plan_Id = workPlan.WorkPlan_Id,
                                       plan_period = workPlan.DateOfWork,
                                       section_Id = section.ИдСекции,
                                       section_name = section.НаименованиеСекции
                                   }).ToListAsync();

            //_context.ПланРабот.ToListAsync();

            if (ПланРабот == null || ПланРабот.Count == 0)
            {
                ПланРабот = new List<ПланРабот>();
            }

            return Page();
        }
    }
}

public class workPlanTable
{
    public int plan_Id { get; set; }
    public string plan_period { get; set; }
    public int section_Id { get; set; }
    public string section_name { get; set; }
}

