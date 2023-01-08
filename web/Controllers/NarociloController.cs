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

namespace SeminarskaNaloga.Controllers
{   
     public class NarociloController : Controller
     {
        private readonly INarociloRepository _narociloRepository;
        private readonly Kosarica _kosarica;
        
        public NarociloController(INarociloRepository narociloRepository,Kosarica kosarica)
        {
            _narociloRepository = narociloRepository;
            _kosarica = kosarica;
        }

        public IActionResult ZakljucekNarocila()
        {
            return View();
        }
     }
}

