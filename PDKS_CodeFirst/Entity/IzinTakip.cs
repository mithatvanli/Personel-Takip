using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDKS_CodeFirst.Entity
{
    public class IzinTakip
    {
        public int Id { get; set; }
        [Display(Name = "İzin Talep Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        public DateTime IzinTalepTarihi { get; set; }
        [Display(Name = "İzin Başlangıç Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        public DateTime IzinBaslangıcTarihi { get; set; }
        [Display(Name = "İzin Bitiş Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        public DateTime IzinBitisTarihi { get; set; }
        [Display(Name = "İzinli Gün Sayısı")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [RegularExpression("[0-9]*", ErrorMessage = "Lütfen Sadece Sayı Değerlerini Giriniz")]
        public int IzinGunSayisi { get; set; }// kendi hesaplayacak
        [Display(Name = "İzin Tipi")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [RegularExpression("[0-9]*", ErrorMessage = "Lütfen Sadece Sayı Değerlerini Giriniz")]
        public int IzinTipi { get; set; }
        [Display(Name = "Personel Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur !")]
     
        public int  PersonelOzlukId { get; set; }
        public virtual PersonelOzluk PersonelOzluk { get; set; }
    }
}