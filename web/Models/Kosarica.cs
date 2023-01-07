using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using SeminarskaNaloga.Data;
namespace SeminarskaNaloga.Models;

public class Kosarica
{
    private readonly TrgovinaContext _appDbContext;

    private Kosarica(TrgovinaContext appDbContext){
            
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string KosaricaId { get; set; }
    public List<Narocilo> ArtikliKosarice { get; set; }

    public static Kosarica GetKosarica(IServiceProvider services){
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
        
        var context = services.GetService<TrgovinaContext>();
        string kosaraId = session.GetString("KosaricaId") ?? Guid.NewGuid().ToString();

        session.SetString("KosaricaId",kosaraId);

        return new Kosarica(context){KosaricaId = kosaraId};
    }

    /*
    public void dodaj(Artikel artikel, int kolicina){
        var ArtikelKosarice = _appDbContext.ArtikliKosarice.SingleOrDefault(
            s => s.Artikel.ArtikelId == Artikel.ArtikelId && s.KosaricaId = KosaricaId
        )

        if(ArtikelKosarice == null){
            ArtikelKosarice = new Narocilo
            {
                KosaricaId = KosaricaId,
                ArtikelKosarice = artikel,
                kolicina = 1
            };

            _appDbContext.ArtikliKosarice.Add(ArtikelKosarice);
        }
        else
        {
            ArtikelKosarice.kolicina++;
        }
        _appDbContext.SaveChanges();
    }*/

}