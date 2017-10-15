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
            ViewBag.AlunoId = new SelectList(_context.Alunos.OrderBy(b => b.Nome), "AlunoId", "Nome");
            ViewBag.IdeiaPaiId = new SelectList(_context.Ideias.OrderBy(b => b.Nome), "IdeiaPaiId", "Nome");
            ViewBag.DepartamentoOpetId = new SelectList(_context.DepartamentosOpet.OrderBy(b => b.Nome), "DepartamentoOpetId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ideia ideia)
        {
            try
            {

                ideia.DataCadastro = DateTime.Now;
                _context.Ideias.Add(ideia);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            catch
            {
                return View(ideia);
            }
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

            ViewBag.AlunoId = new SelectList(_context.Alunos.OrderBy(b => b.Nome), "AlunoId", "Nome", ideia.AlunoId);
            ViewBag.IdeiaPaiId = new SelectList(_context.Ideias.OrderBy(b => b.Nome), "IdeiaPaiId", "Nome", ideia.IdeiaPaiId);
            ViewBag.DepartamentoOpetId = new SelectList(_context.DepartamentosOpet.OrderBy(b => b.Nome), "DepartamentoOpetId", "Nome", ideia.DepartamentoOpetId);

            return View(ideia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ideia ideia)
        {

            try
            {


                if (ModelState.IsValid)
                {
                    _context.Entry(ideia).State = EntityState.Modified;
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(ideia);
            }
            catch
            {
                return View(ideia);

            }

        }


        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ideia ideia = _context.Ideias.Where(i => i.IdeiaId == id).Include(a => a.Aluno).Include(p => p.IdeiaExistente).Include(d => d.DepartamentosOpet).First();


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

            Ideia ideia = _context.Ideias.Where(i => i.IdeiaId == id).Include(a => a.Aluno).Include(p => p.IdeiaExistente).Include(d => d.DepartamentosOpet).First();

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
            try
            {

                Ideia ideia = _context.Ideias.Find(id);
                _context.Ideias.Remove(ideia);
                _context.SaveChanges();
                TempData["Message"] = "Ideia " + ideia.Nome.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }

            catch
            {

                return View();
            }

        }
    }
}