using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class ПланРабот
    {
        [Key]
        public int WorkPlan_Id { get; set; }
        public string DateOfWork { get; set; }
        public int WorkValue { get; set; }

        //Внешний ключ для связи с Секцией
        public int section_id { get; set; }
        // Навигационное свойство для связи с Секцией
        //public Секция Секция { get; set; }

        public int WorkType_id { get; set; }
        //public ВидРабот ВидРабот { get; set; }
    }
}
