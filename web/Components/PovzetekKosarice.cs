using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeminarskaNaloga.Models;
using SeminarskaNaloga.ViewModels;

namespace SeminarskaNaloga.Components
{
    public class PovzetekKosarice : ViewComponent
    {
        private readonly Kosarica _kosarica;
        public PovzetekKosarice(Kosarica kosarica)
        {
            _kosarica = kosarica;
        }

        public IViewComponentResult Invoke()
        {
            var izdelki = _kosarica.getArtikliKosarice();
            _kosarica.ArtikliKosarice = izdelki;

            var KosaricaViewmod = new KosaricaViewModel
            {
                Kosarica = _kosarica,
                KosaricaSkupaj = _kosarica.GetKosaricaSkupaj()
            };

            return View(KosaricaViewmod);
        }
    }
}