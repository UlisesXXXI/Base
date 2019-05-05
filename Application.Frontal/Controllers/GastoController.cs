using Application.bbdd.Entities;
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
        public GastoController(IGastoService service)
        {
            _service = service;
        }
        // GET: Gasto
        public ActionResult Index()
        {
            var ListVmGasto = AutoMapper.Mapper.Map<List<Gasto>,List<GastoNewViewModel>>(_service.ObtenerTodosInclyendo(x => x.TipoGasto) as List<Gasto>); 
            
            return View(ListVmGasto);
        }


        public JsonResult ListaDeGastos()
        {
            var lista = _service.ObtenerTodosInclyendo(x => x.TipoGasto);
            return Json(new { data = lista });
        }
    }
}