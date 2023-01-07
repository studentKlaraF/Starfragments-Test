using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class Narocilo
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int NarociloId { get; set; }
    public Artikel ArtikelKosarice { get; set; }
    public int kolicina { get; set;}
    public string KosaricaId { get; set; }
}
