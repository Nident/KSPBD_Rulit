using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class СправочникАдресов
    {
        [Key]
        public int dict_id { get; set; }
        public bool status { get; set; }
    }
}
