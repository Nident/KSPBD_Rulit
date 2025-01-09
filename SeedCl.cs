using Azure;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using KSPBD_Rulit.Models;

namespace KSPBD_Rulit
{
    public class SeedCl
    {
        public static void Seed(Context context)
        {
            // Заполнение ВидПериода
            if (!context.ВидПериода.Any())
            {
                context.ВидПериода.AddRange(
                    new ВидПериода { НаименованиеВидаПериода = "Месяц-неделя" },
                    new ВидПериода { НаименованиеВидаПериода = "Месяц-год" }
                );
                context.SaveChanges();
            }

            // Заполнение ЕИ
            if (!context.ЕИ.Any())
            {
                context.ЕИ.AddRange(
                    new ЕИ { EI_Code = "м2", EI_Name = "Метры квадратные" },
                    new ЕИ { EI_Code = "м3", EI_Name = "Метры кубические" },
                    new ЕИ { EI_Code = "см2", EI_Name = "Сантиметры квадратные" }
                );
                context.SaveChanges();
            }

            // Заполнение Обьект
            if (!context.Объект.Any())
            {
                context.Объект.AddRange(
                    new Объект { Район = "Приокский", Улица = "Октябрьская 31к2", Статус = "Строится" },
                    new Объект { Район = "Приокский", Улица = "Дачная 16", Статус = "Строится" }
                );
                context.SaveChanges();
            }

            // Заполнение Период
            if (!context.Период.Any())
            {
                context.Период.AddRange(
                    new Период { ДатаНачала = "01-06-2024", ДатаОкончания = "07-06-2024" },
                    new Период { ДатаНачала = "08-06-2024", ДатаОкончания = "14-06-2024" },
                    new Период { ДатаНачала = "15-06-2024", ДатаОкончания = "21-06-2024" },
                    new Период { ДатаНачала = "22-06-2024", ДатаОкончания = "28-06-2024" }
                );
                context.SaveChanges();
            }


            // Заполнение Раздел
            if (!context.Раздел.Any())
            {
                context.Раздел.AddRange(
                new Раздел { chapter_name = "Монолитные работы", chapter_number = 1 },
                new Раздел { chapter_name = "Кирпичная кладка", chapter_number = 2 },
                new Раздел { chapter_name = "Вентиляция", chapter_number = 1 }
                );

                context.SaveChanges();
            }

            // Заполнение Подраздел
            if (!context.Подраздел.Any())
            {
                context.Подраздел.AddRange(
                new Подраздел { chapter_id = 1, subchapter_name = "Стены и перекрытия", subchapter_number = 1 },
                new Подраздел { chapter_id = 2, subchapter_name = "Наружные стены", subchapter_number = 1 },
                new Подраздел { chapter_id = 3, subchapter_name = "Стены и перекрытия", subchapter_number = 1 }
                );
                context.SaveChanges();
            }

            // Заполнение ВидРабот
            if (!context.ВидРабот.Any())
            {
                context.ВидРабот.AddRange(
                    new ВидРабот
                    {
                        WorkType_name = "Монтаж асбестовых",
                        subchapter_id = 3,
                        WorkType_number = 0,
                        WorkComment = "В работе"
                    }

                    );
                context.SaveChanges();
            }


            // Заполнение Секции
            if (!context.Секция.Any())
            {
                context.Секция.AddRange(
                new Секция { НомерСекции = 1, НаименованиеСекции = "Столовая" },
                new Секция { НомерСекции = 2, НаименованиеСекции = "Проходная" },
                new Секция { НомерСекции = 3, НаименованиеСекции = "Туалеты" }
                );

                context.SaveChanges();
            }

            // Заполнение ПланРабот
            if (!context.ПланРабот.Any())
            {
                context.ПланРабот.AddRange(
                new ПланРабот { DateOfWork = "02-06-2024", WorkValue = 2473, section_id = 1, WorkType_id = 1 },
                new ПланРабот { DateOfWork = "22-06-2024", WorkValue = 500, section_id = 1, WorkType_id = 1 },
                new ПланРабот { DateOfWork = "10-09-2024", WorkValue = 100, section_id = 1, WorkType_id = 1 }
                );

                context.SaveChanges();
            }

            // Заполнение СправочникАдресов
            if (!context.СправочникАдресов.Any())
            {
                context.СправочникАдресов.AddRange(
                new СправочникАдресов { status = true }
                );

                context.SaveChanges();
            }

            // Заполнение Этаж"
            if (!context.Этаж.Any())
            {
                context.Этаж.AddRange(
                new Этаж { НаименованиеЭтаж = "Цокальный", НомерЭтажа = 1 }
                );
            }

        }
    }
}
