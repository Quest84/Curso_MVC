using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Curso_MVC.Models;

namespace Curso_MVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (CursoMVCEntities db = new CursoMVCEntities())
                {
                    var lst = from d in db.user
                              where d.email == user && d.password == password 
                                    && d.idState == 1
                              select d;
                    if (lst.Count() > 0)
                    {
                        // Crea la sesión con un nuevo objeto oUser
                        // Se agrega al arreglo de objetos global de MVC
                        user oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("¡Usuario Invalido!");
                    }
                }
                
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error: " + ex.Message);
            }
        }
    }
}