using Application.bbdd.Entities;
using Application.Bll.Interface;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IUsuarioService _usuarioService;
        private IRoleService _roleService;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public UsersController(IUsuarioService userService,IRoleService roleService)
        {
            _usuarioService = userService;
            _roleService = roleService;
        }

        // GET: Admin/Users
        public ActionResult Index()
        {
            List<ApplicationUser> listado = (List<ApplicationUser>)_usuarioService.GetAll();
            
            
            return View(listado);
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
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

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(string id)
        {
            //inicializate
            var vm = new ViewModel.Users.UserViewModel();
            var user = _usuarioService.Find(new Object[] { id });
            
            if(user == null)
            {
                throw new Exception("no existe el usuario");
            }
            //TODO pasar a automapper
            vm.EditRecord = true;
            vm.email = user.Email;
            vm.Id = user.Id;
            

            var roles = AutoMapper.Mapper.Map<List<ApplicationRole>, List<SelectListItem>>((List<ApplicationRole>)_roleService.GetAll());


            return View(vm);
        }

        // POST: Admin/Users/Edit/5
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

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
