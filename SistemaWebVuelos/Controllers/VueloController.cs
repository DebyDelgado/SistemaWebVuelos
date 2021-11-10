using SistemaWebVuelos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWebVuelos.Models;
using System.Data;
using SistemaWebVuelos.Filters;

namespace SistemaWebVuelos.Controllers
{
    [MyFilterAction]
    public class VueloController : Controller
    {

        private VueloDbContext context = new VueloDbContext();
        // GET: Vuelo
        public ActionResult Index()
        {
            return View("Index", AdmVuelo.Listar());
        }



        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();
            return View("Create", vuelo);

        }

        [HttpPost]

        public ActionResult Create (Vuelo vuelo)
        {
            if(ModelState.IsValid)
            {
                AdmVuelo.Cargar(vuelo);
                return RedirectToAction("Index");

            }
            return View("Create", vuelo);

        }

        public ActionResult Detail(int id)
        {
            Vuelo vuelo = AdmVuelo.Listar(id);

            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Delete(int id)
        {
            Vuelo vuelo = AdmVuelo.Listar(id);

            if (vuelo != null)
            {
                return View("Delete", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelo vuelo = AdmVuelo.Listar(id);
            if (vuelo != null)
            {
                AdmVuelo.Borrar(vuelo);
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult BuscarxDestino(string destino)
        {
            return View("Index", AdmVuelo.BuscarPorDestino(destino));

        }
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = AdmVuelo.Listar(id);

            if (vuelo != null)
            {
                return View("Edit", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Edit(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                AdmVuelo.Modificar(vuelo);
                return RedirectToAction("Index");
            }
            return View("Edit", vuelo);

        }
    }
}