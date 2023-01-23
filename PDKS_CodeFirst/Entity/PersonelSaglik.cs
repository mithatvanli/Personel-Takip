using PDKS_CodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PDKS_CodeFirst.DAL
{
    public class PersonelSaglik
    {
        public int Id{ get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Alerji")]
        public bool AlerJi { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Kalp Rahatsızlığı")]
        public bool KalpRahatsizligi { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Kas Eklem")]
        public bool KasEklem { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Görme Durumu")]
        public bool GorneDurumu { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "İşitme Kaybı")]
        public bool IsitmeKaybi { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Bağışıklık Güçlüğü")]
        public bool BagisiklikGuclugu { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Kronik Hastalık")]
        public bool KronikHastalik { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Astım KOA")]
        public bool AstimKoa { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Sindirim Rahatsızlıkları")]
        public bool SindiriRahasizliklari { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Ruhsal Rahatsızlık")]
        public bool RuhsalRahatsizlik { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Zihinsel Hastalık")]
        public string ZihinselHastalik { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Kan Grubu")]
        public string KanGrubu { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [Display(Name = "Personel Adı")]
        public int PersonelId { get; set; }
        public virtual PersonelOzluk PersonelOzluk { get; set; }
    }
}