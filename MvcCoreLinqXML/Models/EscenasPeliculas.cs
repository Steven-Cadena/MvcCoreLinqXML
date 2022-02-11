using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Models
{
    public class EscenasPeliculas
    {
        public int IdPelicula { get; set; }
        public string TituloEscena { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}
