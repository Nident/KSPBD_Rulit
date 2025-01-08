using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class Период
    {
        [Key]
        public int periodId { get; set; }
        public string ДатаНачала { get; set; }
        public string ДатаОкончания { get; set; }

    }
}
