using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Interdisciplinar.Contexts;
using Interdisciplinar.Models;

namespace Interdisciplinar.Controllers
{
    public class IdeiasController : Controller
    {

        private readonly EFContext _context = new EFContext();


        // GET: Ideias
        public ActionResult Index()
        {
            return View(_context.Ideias.OrderBy(s => s.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ideia ideia)
        {
            ideia.DataCadastro = DateTime.Now;
            _context.Ideias.Add(ideia);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var ideia = _context.Ideias.Find(id.Value);


            if (ideia == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(ideia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ideia ideia)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(ideia).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(ideia);
        }


        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ideia = _context.Ideias.Find(id.Value);

            if (ideia == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(ideia);
        }

        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ideia = _context.Ideias.Find(id.Value);

            if (ideia == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(ideia);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

           Ideia ideia = _context.Ideias.Find(id);
            _context.Ideias.Remove(ideia);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}