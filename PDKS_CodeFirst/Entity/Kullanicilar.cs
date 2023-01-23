using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDKS_CodeFirst.Entity
{
    public class Kullanicilar
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu Alan Zorunludur")]
        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage ="Bu Alan Zorunludur")]
        [StringLength(50)]
        public string KullaniciParola { get; set; }
    }
}