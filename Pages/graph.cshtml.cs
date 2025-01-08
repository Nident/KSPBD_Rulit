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
        public IList<workPlanTable> WorkPlanTable { get; set; }


        // Свойства для выбранных раздела, подраздела и вида работы
        public IList<Раздел> Раздел { get; set; }
        public Раздел SelectedChapter { get; set; }
        public IList<chapterTable> ChapterTable { get; set; }

        public IList<Подраздел> Подраздел { get; set; }
        public Подраздел SelectedSubChapter { get; set; }
        public IList<subChapterTable> SubChapterTable { get; set; }

        public IList<ВидРабот> ВидРабот { get; set; }
        public ВидРабот SelectedWorkType { get; set; }
        public IList<workTypeTable> WorkTypeTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? chapterId, int? subChapterId, int? workTypeId)
        {
            // Загружаем все данные
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

            Раздел = await _context.Раздел.ToListAsync();
            ChapterTable = await (from chapter in _context.Раздел
                                  join subchapter in _context.Подраздел
                                  on chapter.chapter_id equals subchapter.chapter_id
                                  select new chapterTable
                                  {
                                      chapter_id = chapter.chapter_id,
                                      subchapter_id = subchapter.subchapter_id,
                                      subchapter_name = subchapter.subchapter_name,
                                      units = "m2"
                                  }).ToListAsync();

            Подраздел = await _context.Подраздел.ToListAsync();
            SubChapterTable = await (from subchapter in _context.Подраздел
                                     join workType in _context.ВидРабот
                                     on subchapter.subchapter_id equals workType.subchapter_id
                                     select new subChapterTable
                                     {
                                         subchapter_id = subchapter.subchapter_id,
                                         workType_id = workType.WorkType_id,
                                         workType_name = workType.WorkType_name,
                                         units = "m2"
                                     }).ToListAsync();

            ВидРабот = await _context.ВидРабот.ToListAsync();

            // Устанавливаем выбранные значения для раздела, подраздела и типа работы
            SelectedChapter = chapterId.HasValue ?
                Раздел.FirstOrDefault(r => r.chapter_id == chapterId) :
                Раздел.FirstOrDefault(); // Если не выбран раздел, берем первый

            if (SelectedChapter != null)
            {
                // Устанавливаем подраздел для выбранного раздела
                SelectedSubChapter = subChapterId.HasValue ?
                    Подраздел.FirstOrDefault(s => s.subchapter_id == subChapterId) :
                    Подраздел.FirstOrDefault(s => s.chapter_id == SelectedChapter.chapter_id);
            }

            if (SelectedSubChapter != null)
            {
                // Устанавливаем тип работы для выбранного подраздела, но без дефолтного значения
                SelectedWorkType = workTypeId.HasValue ?
                    ВидРабот.FirstOrDefault(w => w.WorkType_id == workTypeId) :
                    null; // Устанавливаем null, если workTypeId не передан
            }

            // Фильтруем таблицы в зависимости от выбранных значений
            if (SelectedChapter != null && ChapterTable != null)
            {
                ChapterTable = ChapterTable.Where(c => c.chapter_id == SelectedChapter.chapter_id).ToList();
            }
            else
            {
                // Обработка случая, когда SelectedChapter или ChapterTable равны null
                ChapterTable = new List<chapterTable>(); // или другая логика по умолчанию
            }

            if (SelectedSubChapter != null && SubChapterTable != null)
            {
                SubChapterTable = SubChapterTable.Where(sc => sc.subchapter_id == SelectedSubChapter.subchapter_id).ToList();
            }

            if (SelectedWorkType != null)
            {
                WorkPlanTable = WorkPlanTable.Where(wp => wp.section_Id == SelectedWorkType.WorkType_id).ToList();
            }

            return Page(); // Возвращаем полную страницу
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


public class chapterTable
{
    public int chapter_id { get; set; }
    public int subchapter_id { get; set; }
    public string subchapter_name { get; set; }
    public string units { get; set; }
}

public class subChapterTable
{
    public int subchapter_id { get; set; }
    public int workType_id { get; set; }
    public string workType_name { get; set; }
    public string units { get; set; }
}

public class workTypeTable
{
    public int plan_Id { get; set; }
    public string plan_period { get; set; }
    public int section_Id { get; set; }
    public string section_name { get; set; }
}