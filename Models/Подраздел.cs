using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class Подраздел
    {
        [Key]
        public int subchapter_id { get; set; }
        public int chapter_id { get; set; }
        public string subchapter_name { get; set; }
        public int subchapter_number { get; set; }

    }
}
