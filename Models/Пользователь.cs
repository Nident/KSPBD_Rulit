using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class Пользователь
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string CachePassword { get; set; }
        public string Role { get; set; } 
    }

}
