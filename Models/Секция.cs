﻿using System.ComponentModel.DataAnnotations;

namespace KSPBD_Rulit.Models
{
    public class Секция
    {
        [Key]
        public int Section_id { get; set; }

        public int НомерСекции { get; set; }
        public string НаименованиеСекции { get; set; }
    }
}
