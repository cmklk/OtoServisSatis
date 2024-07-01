using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Arac : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public int MarkaId { get; set; }


        [StringLength(50), Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Renk { get; set; }


        [Display(Name = "Araç Fiyatı")]
        public decimal Fiyat { get; set; }


        [StringLength(50), Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Model { get; set; }


        [Display(Name = "Kasa Tipi")]
        [StringLength(50), Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string KasaTipi { get; set; }


        [Display(Name = "Model Yılı")]
        public int ModelYil { get; set; }

        public string Vites { get; set; }

        public int Kilometre { get; set; }


        [Display(Name ="Yakıt")]
        public string Yakit { get; set; }


        [Display(Name = "Satışta Mı")]
        public bool SatistaMi { get; set; }


        [Required(ErrorMessage ="{0} boş bırakılamaz.")]
        public string Notlar { get; set; }


        [StringLength(100)]
        public string? Resim1 { get; set; }

        [StringLength(100)]
        public string? Resim2 { get; set; }

        [StringLength(100)]
        public string? Resim3 { get; set; }

        public virtual Marka? Marka { get; set; }
        
    }
}
