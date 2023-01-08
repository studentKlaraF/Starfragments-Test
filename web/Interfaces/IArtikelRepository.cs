using SeminarskaNaloga.Models;

namespace SeminarskaNaloga.Data.interfaces
{   
    public interface IArtikelRepository{
        IEnumerable<Artikel> Artikli { get; }
        Artikel getArtikelById(int ArtikelId);
    }
    
}