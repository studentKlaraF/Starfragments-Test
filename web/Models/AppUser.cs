using Microsoft.AspNetCore.Identity;

namespace SeminarskaNaloga.Models;

public class AppUser : IdentityUser
{
    #nullable enable
     public string? ime { get; set; }
     public string? priimek { get; set; }
     public string? mail { get; set; }

     public List<Narocilo>? Narocila { get; set; }
     public string? Trgovina { get; set; }
    public int? TrgovinaId { get; set;}
    public static implicit operator string(AppUser v)
    {
        throw new NotImplementedException();
    }
}