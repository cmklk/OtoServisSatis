using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Iletisim : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage ="{0} boş bırakılamaz.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Konu { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Açıklama { get; set; }
    }
}
