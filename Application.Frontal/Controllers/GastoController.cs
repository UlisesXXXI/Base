using Application.bbdd.Entities;
using Application.bbdd.Entities.Maestros;
using Application.Bll.Interface;
using Application.Frontal.ViewModel.Gasto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Controllers
{
    public class GastoController : Controller
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
            var ListVmGasto = AutoMapper.Mapper.Map<List<Gasto>,List<GastoNewViewModel>>(_service.ObtenerTodosInclyendo(x => x.TipoGasto) as List<Gasto>); 
            
            return View(ListVmGasto);
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


        public JsonResult ListaDeGastos()
        {
            var lista = _service.ObtenerTodosInclyendo(x => x.TipoGasto);
            if (lista == null) lista = new List<Gasto>();
            return Json(new { data = lista },JsonRequestBehavior.AllowGet);
        }
    }
}