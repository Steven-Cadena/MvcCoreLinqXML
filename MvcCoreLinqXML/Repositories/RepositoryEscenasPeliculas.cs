using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcCoreLinqXML.Repositories
{
    public class RepositoryEscenasPeliculas
    {
        private XDocument document;
        private string path;
        public RepositoryEscenasPeliculas(PathProvider pathProvider)
        {
            this.path = pathProvider.MapPath("escenaspeliculas.xml", Folders.Documents);
            this.document = XDocument.Load(path);
        }
        public List<EscenasPeliculas> FindPeliculas(int idpelicula)
        {
            var consulta = from datos in this.document.Descendants("escena")
                           where datos.Attribute("idpelicula").Value == idpelicula.ToString()
                           select datos;

            List<XElement> dato = consulta.ToList();
            List<EscenasPeliculas> peliculas = new List<EscenasPeliculas>();
            foreach(XElement escena in dato)
            {
                EscenasPeliculas pelicula = new EscenasPeliculas
                {
                    IdPelicula = int.Parse(escena.Attribute("idpelicula").Value)
                    ,
                    TituloEscena = escena.Element("tituloescena").Value
                    ,
                    Descripcion = escena.Element("descripcion").Value
                    ,
                    Imagen = escena.Element("imagen").Value
                };
                peliculas.Add(pelicula);
            }
            return peliculas;
        }
    }
}
