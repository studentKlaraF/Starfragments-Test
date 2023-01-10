using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskaNaloga.Data;
using SeminarskaNaloga.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SeminarskaNaloga.Data.interfaces;
using SeminarskaNaloga.ViewModels;

namespace SeminarskaNaloga.Controllers
{   
    
    public class KosaricaController : Controller
    {   
        private readonly IArtikelRepository _ArtikelRepository;
        private readonly Kosarica _kosarica;

        public KosaricaController(IArtikelRepository ArtikelRepository, Kosarica kosarica)
        {
            _ArtikelRepository = ArtikelRepository;
            _kosarica = kosarica;
        }

        public ViewResult Index(){
            var izdelki = _kosarica.getArtikliKosarice();
            _kosarica.ArtikliKosarice = izdelki;

            var kosaricaView   = new KosaricaViewModel{
                Kosarica = _kosarica,
                KosaricaSkupaj = _kosarica.GetKosaricaSkupaj()
            };

            return View(kosaricaView);
        }

        public RedirectToActionResult dodajVKosarico(int ArtikelId){
            var izberiArtikel = _ArtikelRepository.Artikli.FirstOrDefault(p => p.ArtikelId == ArtikelId);
            if(izberiArtikel != null){
                _kosarica.dodajVKosarico(izberiArtikel, 1);
            }
            return RedirectToAction("Index");
        }
        
        public RedirectToActionResult odstraniIzKosarice(int ArtikelId){
            var izberiArtikel = _ArtikelRepository.Artikli.FirstOrDefault(p => p.ArtikelId == ArtikelId);
            if(izberiArtikel != null){
                _kosarica.odstraniIzKosarice(izberiArtikel);
            }
            return RedirectToAction("Index");
    }
    
    }
}

