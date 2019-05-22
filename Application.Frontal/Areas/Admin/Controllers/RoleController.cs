using Application.bbdd.Entities;
using Application.Bll.Interface;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private IRoleService _roleService;
        private ApplicationRoleManager _applicationRoleManager;

        public ApplicationRoleManager applicationRoleManager { get {return _applicationRoleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); ; } }
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

        public async Task<JsonResult> Eliminar(string id)
        {
            var role = await applicationRoleManager.FindByIdAsync(id);
            await applicationRoleManager.DeleteAsync(role);

            return Json(new { Resultado = "Ok" },JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Details(string id)
        {
            var role = applicationRoleManager.ObtenerRole(id);
            return PartialView(role);
        }

       


    }
}