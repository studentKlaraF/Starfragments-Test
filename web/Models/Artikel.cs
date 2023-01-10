using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using SeminarskaNaloga.Data;

namespace SeminarskaNaloga.Models;
public class Artikel
{	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ArtikelId { get; set; }
	[Display(Name="Slika")]
	public string img { get; set; }
	[Display(Name="Ime izdelka")]
	public string naziv { get; set; }
	[Display(Name="Cena")]
	public double cena { get; set; }
	[Display(Name="Opis")]
	public string opis { get; set; }
	[Display(Name="Trgovina")]
	public string trgovina { get; set; }
	#nullable enable
	public AppUser? lastnik { get; set; }
}
