using PDKS_CodeFirst.Controllers;
using PDKS_CodeFirst.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace PDKS_CodeFirst.Entity
{
    public class PersonelOzluk
    {
        
        public int Id { get; set; }
       
        [Display(Name="Adı")]
        [StringLength(40)]
        [Required(ErrorMessage ="Bu alan zorunludur !")]
        [MinLength(2,ErrorMessage ="İsim alanı en az 2 Karakter olmalıdır !")]
        [RegularExpression(("[a-zA-ZÇçĞğÜüÖöŞşİıÜü ]*"), ErrorMessage = "Sadece Karakter")]
        public string Adi { get; set; }

        [Display(Name = "Soyadı")]
        [StringLength(40)]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [MinLength(2, ErrorMessage = "İsim alanı en az 2 Karakter olmalıdır !")]
        [RegularExpression(("[a-zA-ZÇçĞğÜüÖöŞşİıÜü ]*"), ErrorMessage = "Sadece Karakter")]
        public string Soyadi { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [MaxLength(11, ErrorMessage = "TC kimlik numarası 11 haneli olmalıdır!")]
        [MinLength(11, ErrorMessage = "TC kimlik numarası 11 haneli olmalıdır!")]
        [Display(Name = "Tc Kimlik Numarası")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Lütfen Sayı Değeri Giriniz")]        
        public string TcKimlik { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "Zorunlu Alan")]
       
        public string Telefon { get; set; }
        [Display(Name = "Doğum Tarihi")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        public DateTime DogumTarihi { get; set; }        
       
        [Display(Name = "Ünvan")]
        [RegularExpression(("[a-zA-ZÇçĞğÜüÖöŞşİıÜü ]*"), ErrorMessage = "Sadece Karakter")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        public string Unvan { get; set; }
        [Display(Name = "Kurum Sicil No")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        public string KurumSicil { get; set; }
        [Display(Name = "E-Posta Adresi")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli Bir E-Posta Adresi Giriniz")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        public string EPosta { get; set; }
        [Display(Name = "Medeni Durumu")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [RegularExpression(("[a-zA-ZÇçĞğÜüÖöŞşİıÜü ]*"), ErrorMessage = "Sadece Karakter")]
        public string MedeniDurum { get; set; }
        [Display(Name = "Ev Adresi")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [RegularExpression(("[a-zA-ZÇçĞğÜüÖöŞşİıÜü */.,:;&()=?]*"), ErrorMessage = "Sadece Karakter")]
        public string EvAdresi { get; set; }
        [Display(Name = "Askerlik Durumu")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        
        public string Askerlik { get; set; }
        [Display(Name = "İşe Giriş Tarihi")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        public DateTime IseGiris { get; set; }
        [Display(Name = "Ehliyet")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        [RegularExpression(("[a-zA-ZÇçĞğÜüÖöŞşİıÜü ]*"), ErrorMessage = "Sadece Karakter")]
        public string Ehliyet { get; set; }
   

        public bool Engelli { get; set; }
        [Display(Name = "Bağlı Olduğu Depatman")]
        [Required(ErrorMessage = "Zorunlu Alan !")]
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
        public ICollection<IzinTakip> IzinTakips { get; set; }
        public ICollection<PersonelCocuk> PersonelCocuks { get; set; }
        public ICollection<PersonelEgitim> PersonelEgitims { get; set; }
       
        public ICollection<PersonelPuantaJ> PersonelPuantaJ { get; set; }
        public ICollection<PersonelSaglik> PersonelSagliks { get; set; }
        public ICollection<Belgeler> Belgelers { get; set; }
        public ICollection<PersonelKiyafet> PersonelKiyafets { get; set; }


    }
}