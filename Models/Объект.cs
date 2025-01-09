using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KSPBD_Rulit.Models
{
    public class Объект
    {
        [Key]
        public int ИдОбьекта { get; set; }

        [JsonPropertyName("Район")]
        public string Район { get; set; }

        [JsonPropertyName("Улица")]
        public string Улица { get; set; }

        [JsonPropertyName("Статус")]
        public string Статус { get; set; }
    }
}
