using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDKS_CodeFirst.Entity
{
    public class PersonelPuantaJ
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        public DateTime CalısmaSaati { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        public DateTime GirisSaati { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        public DateTime CıkısSaati { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Mazeret")]
        public string Mazeret{ get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Personel Adı")]
        public int PersonelOzlukId { get; set; }
        public virtual PersonelOzluk PersonelOzluk { get; set; }

    }
}