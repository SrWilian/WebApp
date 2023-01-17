using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using CapaEntidad;
using CapaLogica;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PRUEBAS_LOGIN.Controllers
{
    public class AccesoController : Controller
    {


        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(EntUsuario Usuario, EntMensaje Mensaje)
        {
        string mensaje = "no debo estar vacío" +
                "";
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool insertar = LogUsuario.Instancia.RegistrarUsuario(Usuario);

            mensaje= LogUsuario.Instancia.Mensaje(mensaje, Usuario);
            ViewData["Mensaje"] = mensaje;
            

            try
            {
                if (insertar && Usuario.Clave == Usuario.ConfirmarClave)
                {
                    return RedirectToAction("Login","Acceso");
                }
                if (insertar== false)
                {
                    ViewData["Mensaje"] = mensaje;
                    return RedirectToAction("RegistrarUsuario", "Acceso");
                }

                else
                {
                    ViewData["Mensaje"] = "Las contraseñas no coinciden";
                    return View(insertar);
                }
                
            } 
            catch (ApplicationException ex)
            {
                return RedirectToAction("RegistrarUsuario", new { mesjExceptio = ex.Message });
            }
            
         

        }

        [HttpPost]

        public ActionResult Login(EntUsuario Usuario)
        {
            bool insertar = LogUsuario.Instancia.LoginUsuario(Usuario);
           
            EntMensaje Mensaje = new EntMensaje();
            try
            {
                if (Usuario.IdUsuario != 0)
                {

                    Session["usuario"] = Usuario;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Mensaje"] = "usuario no encontrado";
                    return View();
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("Login", new { mesjExceptio = ex.Message });
            }

        }

    }
}

/*
 *         // GET: Acceso
        //modificado por eric-------------------------------------

        //public ActionResult Login()

         /// <summary>
        /// hasta aaqui----------------------------------------------------
        /// 
        /// 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>

 */