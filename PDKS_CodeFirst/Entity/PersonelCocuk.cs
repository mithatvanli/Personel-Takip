using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PDKS_CodeFirst.Entity
{
    public class PersonelCocuk
    {
        public int Id { get; set; }
        [Display(Name = "Çocuk Adı")]
        [StringLength(40)]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [MinLength(2, ErrorMessage = "İsim alanı en az 2 Karakter olmalıdır !")]
        [RegularExpression(("[a-zA-ZÇçĞğÜüÖöŞşİıÜü ]*"), ErrorMessage = "Sadece Karakter")]
        public string CocukAdı { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        public DateTime CocukDogumTarihi { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        public bool CocukCinsiyet { get; set; }
        [Display(Name = "Personel Adı")]        
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [MinLength(2, ErrorMessage = "İsim alanı en az 2 Karakter olmalıdır !")]        
        public int PersonelOzlukId { get; set; }
        public virtual PersonelOzluk PersonelOzluk { get; set; }
         
        //public enum CocukCinsiyeti 
        //{
        //    Erkek=1,
        //    Kız=2,
        //}
    }
}