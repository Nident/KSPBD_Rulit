using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class Объект
    {
        [Key]
        public int ИдОбьекта { get; set; }
        public string Район { get; set; }
        public string Улица { get; set; }
        public string Статус { get; set; }
    }
}
