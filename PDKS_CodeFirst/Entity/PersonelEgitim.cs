using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PDKS_CodeFirst.Entity
{
    public class PersonelEgitim
    {
        public int Id { get; set; }
        [Display(Name = "Eğitim Bilgisi")]
        [StringLength(40)]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [MinLength(2, ErrorMessage = "İsim alanı en az 2 Karakter olmalıdır !")]
        [RegularExpression(("[a-zA-ZÇçĞğÜüÖöŞşİıÜü ]*"), ErrorMessage = "Sadece Karakter")]
        public string EgitimBilgisi { get; set; }
        [Display(Name = "Personel Adı")]
        public int PersonelOzlukId { get; set; }
        public virtual PersonelOzluk PersonelOzluk { get; set; }
    }
}