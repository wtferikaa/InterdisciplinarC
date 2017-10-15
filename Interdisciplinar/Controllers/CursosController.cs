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
    public class CursosController : Controller
    {
        private readonly EFContext _context = new EFContext();


        // GET: Cursos
        public ActionResult Index()
        {
            return View(_context.Cursos.OrderBy(s => s.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Curso curso)
        {
            _context.Cursos.Add(curso);
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

            var curso = _context.Cursos.Find(id.Value);


            if (curso == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(curso).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(curso);
        }


        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var curso = _context.Cursos.Find(id.Value);

            if (curso == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(curso);
        }



        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var curso = _context.Cursos.Find(id.Value);

            if (curso == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(curso);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            Curso curso = _context.Cursos.Find(id);
            _context.Cursos.Remove(curso);
            _context.SaveChanges();
            TempData["Message"] = "Curso " + curso.Nome.ToUpper() + " foi removido";

            return RedirectToAction("Index");
        }
    }

}