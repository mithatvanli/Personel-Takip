using PDKS_CodeFirst.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PDKS_CodeFirst.Entity
{
    public class Departman
    {
        [Display(Name = "Departman Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur !")]
        [Display(Name = "Departman Adı")]
        [StringLength(40)]
        public string DepartmanAdi { get; set; }

        public ICollection<PersonelOzluk> PersonelOzluks { get; set; }
        public ICollection<PersonelKiyafet> PersonelKiyafets { get; set; }


    }
}