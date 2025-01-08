using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class Этаж
    {
        [Key]
        public int ИдЭтаж { get; set; }
        public string НаименованиеЭтаж { get; set; }
        public int НомерЭтажа { get; set; }

    }
}
