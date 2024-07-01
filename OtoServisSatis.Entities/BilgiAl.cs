using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class BilgiAl : IEntity
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Adi { get; set; }

        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} boş bırakılamaz.")]

        [StringLength(50)]
        public string Soyadi { get; set; }

        [Display(Name = "TC Numarası")]
        [StringLength(11)]
        public string? TcNo { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name ="Aracın Markası")]

        [StringLength(20)]
        public string Marka { get; set; }


        [Display(Name = "Aracın Modeli")]

        [StringLength(20)]
        public string Model { get; set; }

        [StringLength(15)]
        public string? Telefon { get; set; }
        public string? Notlar { get; set; }
     
    }
}
