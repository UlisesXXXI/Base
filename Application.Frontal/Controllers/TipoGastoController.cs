using Application.Bll.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Controllers
{
    public class TipoGastoController : Controller
    {

        private ITipoGastoService _tipoGastoservice;
        #region Constructor
        public TipoGastoController(ITipoGastoService tipoGastoService)
        {
            _tipoGastoservice = tipoGastoService;
        }

        #endregion

        // GET: TipoGasto
        public ActionResult Index()
        {
            var listado = _tipoGastoservice.GetAll();
            return View(listado);
        }

        // GET: TipoGasto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoGasto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoGasto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoGasto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoGasto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoGasto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoGasto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
