using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDKS_CodeFirst.Entity
{
    public class Belgeler
    {
        public int Id { get; set; }
        [Display(Name = "Belge Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        public string BelgeAdi { get; set; }
        [Display(Name = "Belge Yolu")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        public string BelgeYolu { get; set; }
        [Display(Name = "Belge Tipi")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [RegularExpression("[0-9]*", ErrorMessage = "Lütfen Sayı Değeri Giriniz")]
        public  int BelgeTipi { get; set; }
        [Display(Name = "Personel Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]

        public int PersonelOzlukId { get; set; }
        public virtual PersonelOzluk PersonelOzluk { get; set; }

        //public enum BelgeTipi
        //{
        //    Nüfus_Cüzdanı_Fotokopisi = 1,
        //    Nüfus_Kayıt_Örneği=2,
        //    İkametgâh = 3,
        //    Diploma_Fotokopisi = 4,
        //    Sağlık_Raporu = 5,
        //    Kan_Grubu_Kartı = 6,
        //    Adli_Sicil_Kaydı = 7,
        //    Aile_Durumu =8, 
        //    Askerlik_Durum=9,  
        //    //işe giriş için gerekli belgeler
        //}
    }
}