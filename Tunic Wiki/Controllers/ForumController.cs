using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tunic_Wiki.Models;
using Tunic_Wiki.Datos;

namespace Tunic_Wiki.Controllers
{
    
    public class ForumController : Controller
    {
        Consultas consultas = new Consultas();
        // GET: Forum
        public ActionResult Forum()
        {
            IEnumerable<Post> items = consultas.ConsultarItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Guardar(string titulo, string contenido)
        {
            Post post1 = new Post()
            {
                id = 0,
                titulo = titulo,
                contenido = contenido
            };
            consultas.Guardar(post1);
            return View("Forum");
        }

    }
}
