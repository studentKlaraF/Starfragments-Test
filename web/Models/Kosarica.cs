using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using SeminarskaNaloga.Data;
namespace SeminarskaNaloga.Models;
using Microsoft.EntityFrameworkCore;


public class Kosarica
{
    private readonly TrgovinaContext _appDbContext;

    private Kosarica(TrgovinaContext appDbContext){
        _appDbContext = appDbContext;
    }

    public string KosaricaId { get; set; }

    public List<ArtikelKosarice> ArtikliKosarice { get; set; }

    public static Kosarica GetKosarica(IServiceProvider services){
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
        
        var context = services.GetService<TrgovinaContext>();
        string kosaraId = session.GetString("KosaricaId") ?? Guid.NewGuid().ToString();

        session.SetString("KosaricaId",kosaraId);

        return new Kosarica(context){KosaricaId = kosaraId};
    }

    public void dodajVKosarico(Artikel artikel, int kolicina)
    {
        var ArtikelKosarice = _appDbContext.ArtikelKosarice.SingleOrDefault(
            s => s.ArtikelKosare.ArtikelId == artikel.ArtikelId && s.KosaricaId == KosaricaId
        );

        if(ArtikelKosarice == null)
        {
            ArtikelKosarice = new ArtikelKosarice
            {
                KosaricaId = KosaricaId,
                ArtikelKosare = artikel,
                kolicina = 1
            };

            _appDbContext.ArtikelKosarice.Add(ArtikelKosarice);
        }
        else
        {
            ArtikelKosarice.kolicina++;
        }
        _appDbContext.SaveChanges();
    }

    public int odstraniIzKosarice(Artikel artikel)
    {
        var ArtikelKosarice = _appDbContext.ArtikelKosarice.SingleOrDefault(
            s => s.ArtikelKosare.ArtikelId == artikel.ArtikelId && s.KosaricaId == KosaricaId
        );

        var localAmount = 0;

        if(ArtikelKosarice != null)
        {
            if(ArtikelKosarice.kolicina > 1)
            {
                ArtikelKosarice.kolicina--;
                localAmount = ArtikelKosarice.kolicina;
            }
            else
            {
                _appDbContext.ArtikelKosarice.Remove(ArtikelKosarice);
            }
        }

        _appDbContext.SaveChanges();

        return localAmount;
    }

    public List<ArtikelKosarice> getArtikliKosarice()
    {
        return ArtikliKosarice ??
               (ArtikliKosarice =
                   _appDbContext.ArtikelKosarice.Where(c => c.KosaricaId == KosaricaId)
                       .Include(s => s.ArtikelKosare)
                       .ToList());
    }

    public void clearKosarica(){
        var kosaricaItems = _appDbContext
            .ArtikelKosarice
            .Where(cart => cart.KosaricaId == KosaricaId);

        _appDbContext.ArtikelKosarice.RemoveRange(kosaricaItems);

        _appDbContext.SaveChanges();
    }

    public double GetKosaricaSkupaj(){
        var skupaj = _appDbContext.ArtikelKosarice.Where(c => c.KosaricaId == KosaricaId)
            .Select(c => c.ArtikelKosare.cena * c.kolicina).Sum();
        return skupaj;
    }
}