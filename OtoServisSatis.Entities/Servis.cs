using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Servis : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Servise Geliş Tarihi")]
        public DateTime ServisGelisTarihi { get; set; }
        [Display(Name = "Araç Sorunu"), Required(ErrorMessage ="{0} boş bırakılamaz.")]
        public string AracSorunu { get; set; }
        [Display(Name ="Araç Ücreti")]
        public decimal ServisUcreti { get; set; }
        [Display(Name = "Servisten Çıkış Tarihi")]
        public DateTime ServisCikisTarihi { get; set; }
        [Display(Name = "Yapılan İşlemler")]
        public string? YapilanIslemler { get; set; }
        [Display(Name = "Garanti Kapsamında Mı?")]
        public bool GarantiKapsamidaMi { get; set; }


        [StringLength(15)]
        [Display(Name = "Araç Plakası"), Required(ErrorMessage ="{0} boş bırakılamaz.")]
        public string AracPlaka { get; set; }

        [StringLength(50)]
        [Display(Name ="Araç Markası"), Required(ErrorMessage ="{0} boş bırakılamaz.")]
        public string Marka { get; set; }
        [StringLength(50)]
        public string? Model { get; set; }
        [StringLength(50)]
        [Display(Name = "Kasa Tipi")]
        public string? KasaTipi { get; set; }
        [StringLength(50)]
        [Display(Name = "Şase Numarası")]
        public string? SaseNo { get; set; }
        public string Notlar { get; set; }
    }
}
