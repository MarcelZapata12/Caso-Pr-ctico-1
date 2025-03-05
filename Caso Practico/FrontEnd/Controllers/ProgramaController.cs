using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProgramaController : Controller
    {
        IProgramaHelper _programaHelper;


        public ProgramaController(IProgramaHelper programaHelper)
        {
            _programaHelper = programaHelper;
        }


        // GET: ProgramaController1
        public ActionResult Index()
        {
            var result = _programaHelper.GetProgramas();
            return View(result);
        }

        // GET: ProgramaController1/Details/5
        public ActionResult Details(int id)
        {
            var result = _programaHelper.GetPrograma(id);
            return View(result);
        }

        // GET: ProgramaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgramaViewModel programa)
        {
            try
            {
                _programaHelper.Add(programa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramaController1/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _programaHelper.GetPrograma(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: ProgramaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProgramaViewModel programa)
        {
            try
            {
                if (id != programa.ProgramaId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _programaHelper.Update(programa);
                    return RedirectToAction(nameof(Index));
                }
                return View(programa);
            }
            catch
            {
                return View(programa);

            }
        }

        // GET: ProgramaController1/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _programaHelper.GetPrograma(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: ProgramaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProgramaViewModel programa)
        {
            try
            {
                _programaHelper.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(programa);
            }
        }
    }
}
