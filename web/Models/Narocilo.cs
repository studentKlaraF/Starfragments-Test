using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarskaNaloga.Models
{
    public class Narocilo
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NarociloId { get; set; }
        public List<InfoONarocilu> VrsticeNarocila { get; set; }
        public string ime { get; set; }
        public string priimek { get; set; }
        public string enaslov { get; set; }
        public string naslov { get; set; }
        public string kraj { get; set; }
        public string posta { get; set; }
        public int telefon { get; set; }
        public double vrednostNarocila { get; set; }
        public DateTime datumNarocila { get; set; }
        
    }

}
