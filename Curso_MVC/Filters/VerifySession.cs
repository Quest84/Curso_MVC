using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Curso_MVC.Controllers;
//using Curso_MVC.Models;

namespace Curso_MVC.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // base es como el super de java
            // Se crea una variable que haya recibido de la sesión 
            var oUser = (Curso_MVC.Models.user)HttpContext.Current.Session["User"];

            if(oUser == null)
            {
                // Prefiero no usar los using heh
                /*  Se necesita evaluar que el Access controller == false, ó es diferente 
                    del que venía para poder redirigirse al index
                    Si no se hace esto se crearía un bucle */
                if(filterContext.Controller is Curso_MVC.Controllers.AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is Curso_MVC.Controllers.AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext); 
        }
    }
}