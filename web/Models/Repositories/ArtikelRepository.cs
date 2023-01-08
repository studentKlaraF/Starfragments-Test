using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeminarskaNaloga.Data.interfaces;
using SeminarskaNaloga.Models;

namespace SeminarskaNaloga.Data.Repositories
{
    public class ArtikelRepository : IArtikelRepository
    {
        private readonly TrgovinaContext _context;

        public ArtikelRepository(TrgovinaContext context)
        {
            _context = context;
        }

        public IEnumerable<Artikel> Artikli => _context.Artikel;

        public Artikel getArtikelById(int ArtikelId)
        {
            return _context.Artikel.FirstOrDefault(p => p.ArtikelId == ArtikelId);
        }
    }
}