using Application.bbdd.Entities;
using Application.bbdd.Entities.Maestros;
using Application.Bll.Interface;
using Application.Frontal.Controllers.Interfaces;
using Application.Frontal.ViewModel.Gasto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Controllers
{
    public class GastoController : ControladorBase
    {
        private IGastoService _service;
        private ITipoGastoService _tipoGastoService;
        public GastoController(IGastoService service,ITipoGastoService tipoGastoService)
        {
            _service = service;
            _tipoGastoService = tipoGastoService;
        }
        // GET: Gasto
        public ActionResult Index()
        {
            List<Gasto> lista = _service.ObtenerTodosInclyendo(x => x.TipoGasto) as List<Gasto>;
            var ListVmGasto = AutoMapper.Mapper.Map<List<Gasto>,List<GastoNewViewModel>>(lista); 
            
            return View(ListVmGasto);
        }

        [HttpPost]
        public ActionResult Create(GastoNewViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Gasto gasto = AutoMapper.Mapper.Map<GastoNewViewModel, Gasto>(vm);
                _service.Insertar(gasto);
                return RedirectToAction("Index");
            }
            vm.ComboTipos = AutoMapper.Mapper.Map<List<TipoGasto>, List<SelectListItem>>((List<TipoGasto>)_tipoGastoService.ObtenerTodos());

            return View("Detail", vm);
           
        }

        public ActionResult Detail(int? id)
        {
           var gasto =  _service.Obtener(id);
            GastoNewViewModel viewmodelgasto = null;
           if(gasto == null)
            {
                viewmodelgasto = new GastoNewViewModel();
            }
            else
            {
                viewmodelgasto = AutoMapper.Mapper.Map<Gasto, GastoNewViewModel>(gasto);
            }

            viewmodelgasto.ComboTipos = AutoMapper.Mapper.Map< List <TipoGasto> ,List <SelectListItem>>((List<TipoGasto>)_tipoGastoService.ObtenerTodos());

            return View(viewmodelgasto);
        }

       [HttpPost]
        public JsonResult Eliminar(int Id)
        {
            _service.Eliminar(Id);
            return Json(new { resultado = "Ok" });
        }

        public JsonResult ListaDeGastos()
        {
            var lista = _service.ObtenerTodosInclyendo(x => x.TipoGasto);
            if (lista == null) lista = new List<Gasto>();
            return Json(new { data = lista },JsonRequestBehavior.AllowGet);
        }
    }
}