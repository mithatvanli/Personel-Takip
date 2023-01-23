using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDKS_CodeFirst.Entity
{
    public class PersonelKiyafet
    {
        public int Id{ get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur !")]
        public int PersonelOzlukId { get; set; }
       
        public virtual PersonelOzluk PersonelOzluk { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        public int DepartmanId { get; set; }
       
        public virtual Departman Departman { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [Display(Name = "İstek Nedeni")]
        public string İstekNedeni { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [Display(Name = "Renk")]
        public string Renk { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [RegularExpression("[0-9]*", ErrorMessage = "Lütfen Sayı Değeri Giriniz")]
        public int Model { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [Display(Name = "Üst Beden No")]
        public string ÜstBedenNo { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [Display(Name = "Alt Beden No")]
        public string AltBedenNo { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [Display(Name = "Kaf Beden No")]
        public string KafaBedenNo { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [Display(Name = "Ayakkabı No")]
        [RegularExpression("[0-9]*", ErrorMessage = "Lütfen Sayı Değeri Giriniz")]
        public int AyakkabıNo { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [RegularExpression("[0-9]*", ErrorMessage = "Lütfen Sayı Değeri Giriniz")]
        public int Boy { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [RegularExpression("[0-9]*", ErrorMessage = "Lütfen Sayı Değeri Giriniz")]
        public int Kilo { get; set; }


    }
}