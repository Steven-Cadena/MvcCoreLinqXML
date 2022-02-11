using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcCoreLinqXML.Repositories
{
    public class RepositoryJoyerias
    {
        private XDocument document;
        /*para cargar las joyerias del fichero xml*/
        public RepositoryJoyerias(PathProvider provider) 
        {
            string filename = "joyerias.xml";
            string path = provider.MapPath(filename, Folders.Documents);
            this.document = XDocument.Load(path);
        }
        public List<Joyeria> GetJoyerias()
        {
            var consulta = from datos in this.document.Descendants("joyeria")
                           select datos;
            List<Joyeria> joyerias = new List<Joyeria>();
            foreach (var element in consulta)
            {
                Joyeria joyeria = new Joyeria();
                //PARA ACCEDER A UNA ETIQUETA UTILIZAMOS Element
                //PARA ACCEDER A UN ATRIBUTO UTILIZAMOS Attribute
                joyeria.Nombre = element.Element("nombrejoyeria").Value;
                joyeria.CIF = element.Attribute("cif").Value;
                joyeria.Telefono = element.Element("telf").Value;
                joyeria.Direccion = element.Element("direccion").Value;
                joyerias.Add(joyeria);
            }
            return joyerias;
        }
    }
}
