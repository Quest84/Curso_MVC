using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Curso_MVC.Models;
using Curso_MVC.Models.TableViewModels;
using Curso_MVC.Models.ViewModels;

namespace Curso_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (CursoMVCEntities db = new CursoMVCEntities())
            {
                lst = (from d in db.user
                      where d.idState == 1
                      orderby d.email
                      select new UserTableViewModel
                      {
                          Email = d.email,
                          Id = d.id,
                          Edad = d.edad
                      }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add( UserViewModel model)
        {
             
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new CursoMVCEntities())
            {
                user oUser = new user();

                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.user.Add(oUser);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        // Si no se pone etiqueta la función recibe por Get
        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new CursoMVCEntities())
            {
                // Find devuelve un objeto basado en el Id que se le pasa
                var oUser = db.user.Find(Id);
                // Cast to int por que se puso la edad como nullable
                // No es necesario si la edad fuera un campo obligatorio
                model.Edad = (int) oUser.edad;
                model.Email = oUser.email;
                model.Id = oUser.id;

            }

                return View(model);
        }

        // Etiqueta que fuerza la funcion a ser usada solo por Post
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new CursoMVCEntities())
            {
                var oUser = db.user.Find(model.Id);
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                
                if( model.Password != null && model.Password.Trim()!= "" )
                {
                    oUser.password = model.Password;
                }
                else
                {

                }

                // Función para editar los campos que se editaron en la base de datos
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }
    

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new CursoMVCEntities())
            {
                var oUser = db.user.Find(Id);
                // En lugar de borrar el registro 
                // Se cambia el idState
                oUser.idState = 3;

                // Función para editar los campos que se editaron en la base de datos
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}