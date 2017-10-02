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
    public class DepartamentosOpetController : Controller
    {

        private readonly EFContext _context = new EFContext();


        // GET: DepartamentosOpet
        public ActionResult Index()
        {
            return View(_context.DepartamentosOpet.OrderBy(s => s.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartamentoOpet departamentoOpet)
        {
            _context.DepartamentosOpet.Add(departamentoOpet);
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

            var departamentoOpet = _context.DepartamentosOpet.Find(id.Value);


            if (departamentoOpet == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(departamentoOpet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartamentoOpet departamentoOpet)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(departamentoOpet).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(departamentoOpet);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var departamentoOpet = _context.DepartamentosOpet.Find(id.Value);

            if (departamentoOpet == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(departamentoOpet);
        }

        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var departamentoOpet = _context.DepartamentosOpet.Find(id.Value);

            if (departamentoOpet == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(departamentoOpet);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            DepartamentoOpet departamentoOpet = _context.DepartamentosOpet.Find(id);
            _context.DepartamentosOpet.Remove(departamentoOpet);
            _context.SaveChanges();
            TempData["Message"] = "Departamento " + departamentoOpet.Nome.ToUpper() + " foi removido";

            return RedirectToAction("Index");
        }
    }
}