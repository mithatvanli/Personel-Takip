using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PDKS_CodeFirst.Entity;

namespace PDKS_CodeFirst.DAL
{
    public class PDKSContext :DbContext
    {
        public DbSet<PersonelOzluk>  PersonelOzluks { get; set; }
        public DbSet<Departman> Departmen { get; set; }
        public DbSet<IzinTakip> IzinTakip { get; set; }
        public DbSet<PersonelCocuk> PersonelCocuk  { get; set; }
        public DbSet<PersonelEgitim> PersonelEgitims { get; set; }
       
        public DbSet<PersonelPuantaJ> PersonelPuantaJs { get; set; }
        public DbSet<PersonelSaglik> PersonelSagliks { get; set; }
        public DbSet<Belgeler> Belgelers { get; set; }
        public DbSet<PersonelKiyafet> PersonelKiyafets { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }




    }
}