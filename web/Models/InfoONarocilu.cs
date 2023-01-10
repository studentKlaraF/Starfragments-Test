using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarskaNaloga.Models
{
    public class InfoONarocilu
    {
        public int InfoONarociluId { get; set; }
        public int NarociloId { get; set; } 
        public int ArtikelId { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }
        public virtual Artikel Artikel { get; set; }
        public virtual Narocilo Narocilo { get; set; }
    }
}