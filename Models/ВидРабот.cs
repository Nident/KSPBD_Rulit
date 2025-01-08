using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class ВидРабот
    {
        [Key]
        public int WorkType_id { get; set; }
        public string WorkType_name { get; set; }
        public int WorkType_number { get; set; }
        public string? WorkComment { get; set; }

    }
}
