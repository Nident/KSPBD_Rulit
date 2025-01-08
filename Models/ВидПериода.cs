using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class ВидПериода
    {
        [Key]
        public int ИдВидаПериода { get; set; }
        public string НаименованиеВидаПериода { get; set; }
    }
}
