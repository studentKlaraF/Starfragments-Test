using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeminarskaNaloga.Data.interfaces;
using SeminarskaNaloga.Models;

namespace SeminarskaNaloga.Data.Repositories
{
    public class NarociloRepository : INarociloRepository
    {
        private readonly TrgovinaContext _context;
        private readonly Kosarica _kosarica;

        public NarociloRepository(TrgovinaContext context, Kosarica kosarica)
        {
            _context = context;
            _kosarica = kosarica;
        }

        public void ustvariNarocilo(Narocilo narocilo)
        {
            narocilo.datumNarocila = DateTime.Now;
            _context.Narocilo.Add(narocilo);

            var kosaricaArtikli = _kosarica.getArtikliKosarice();
            foreach (var items in kosaricaArtikli)
            {
                var NarociloInfo = new InfoONarocilu()
                {
                    ArtikelId = items.ArtikelKosare.ArtikelId,
                    Kolicina = items.kolicina,
                    NarociloId = narocilo.NarociloId,
                    Cena = items.ArtikelKosare.cena
                };
                _context.InfoONarocilu.Add(NarociloInfo);
            }
            _context.SaveChanges();
        }     
    }
}
