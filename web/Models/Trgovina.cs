using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class Trgovina
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TrgovinaId { get; set; }
    [Display(Name="Slika")]
	public string img { get; set; }
    [Display(Name="Naziv trgovine")]
	public string ime { get; set; }
    [Display(Name="Artikli")]
    public List<Artikel> Artikli { get; set;}
    public string lastnik { get; set;}

}
