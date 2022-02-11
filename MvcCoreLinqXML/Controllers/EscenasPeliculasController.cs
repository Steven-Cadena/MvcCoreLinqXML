using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Controllers
{
    public class EscenasPeliculasController : Controller
    {
        private RepositoryEscenasPeliculas repo;
        public EscenasPeliculasController(RepositoryEscenasPeliculas repo)
        {
            this.repo = repo;
        }
        public IActionResult EscenasPeliculasId(int id)
        {
            List<EscenasPeliculas> escenaspeliculas = this.repo.FindPeliculas(id);
            return View(escenaspeliculas);
        }
    }
}
