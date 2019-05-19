using Application.bbdd.Entities;
using Application.Bll.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            List<ApplicationRole> lista = new List<ApplicationRole>();
            return View(lista);
        }

        public JsonResult ListaDeRoles()
        {
            var listado = _roleService.GetAll();
            return Json(new { data = listado }, JsonRequestBehavior.AllowGet);
        }
    }
}