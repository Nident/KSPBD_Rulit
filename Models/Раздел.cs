using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class Раздел
    {
        [Key]
        public int chapter_id { get; set; }
        public string chapter_name { get; set; }
        public int chapter_number { get; set; }
    }
}
