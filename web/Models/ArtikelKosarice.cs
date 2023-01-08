using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class ArtikelKosarice
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ArtikelKosariceId { get; set; }
    public Artikel ArtikelKosare { get; set; }
    public int kolicina { get; set;}
    public string KosaricaId { get; set; }
}
