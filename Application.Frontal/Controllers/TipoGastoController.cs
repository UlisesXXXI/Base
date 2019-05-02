using Application.bbdd.Entities.Maestros;
using Application.Bll.Interface;
using Application.Frontal.ViewModel.TipoGasto;
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
            List<TipoGasto> tiposGasto = (List<TipoGasto>)_tipoGastoservice.ObtenerTodos();
            var listado = AutoMapper.Mapper.Map< List<TipoGasto>,List <TipoGastoViewModel>>(tiposGasto);

            
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

        public PartialViewResult NuevoTipo(int id)
        {
            var vm = new TipoGastoViewModel();
            if(id != 0)
            {
                vm = AutoMapper.Mapper.Map<TipoGasto,TipoGastoViewModel>( _tipoGastoservice.Obtener(id));
                if(vm==null || vm.TipoGastoID==0)
                {
                    throw new Exception("No se encontro el registro");
                }
            }

            
            return PartialView("TipoGasto/_TipogGastoModal", vm);
        }

        // GET: TipoGasto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoGasto/Edit/5
        [HttpPost]
        public JsonResult Edit(TipoGastoViewModel vm)
        {
            _tipoGastoservice.Modificar(AutoMapper.Mapper.Map<TipoGastoViewModel,TipoGasto>( vm));
            return Json("OK");
        }


        // POST: TipoGasto/Delete/5
        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            _tipoGastoservice.Eliminar(id);
            return Json("Ok");
        }
        
        public JsonResult ActualizarTablaTiposGasto()
        {
            List<TipoGasto> tiposDeGasto = (List<TipoGasto>)_tipoGastoservice.ObtenerTodos();
            
            return Json(new { data =tiposDeGasto },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Insert(TipoGastoViewModel vm)
        {
            TipoGasto entidad = AutoMapper.Mapper.Map<TipoGastoViewModel,TipoGasto>(vm);
            _tipoGastoservice.Insertar(entidad);
            return Json("Ok");

        }
    }
}
