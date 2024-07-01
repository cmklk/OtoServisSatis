using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Slider : IEntity
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name ="Başlık")]
        public string? Baslik {  get; set; }

        [StringLength(500)]
        [Display(Name ="Açıklama")]
        public string? Acikalama { get; set; }

        [Display(Name ="Resim")]
        public string? Resim { get; set; }


    }
}
