using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class ЕИ
    {
        [Key]
        public int EI_Id { get; set; }
        public string EI_Code { get; set; }
        public string EI_Name { get; set; }

    }
}
