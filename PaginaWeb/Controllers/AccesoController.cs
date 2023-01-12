using CapaEntidad;
using CapaLogica;
using System;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PRUEBAS_LOGIN.Controllers
{
    public class AccesoController : Controller
    {

        // GET: Acceso
        //modificado por eric-------------------------------------

        //public ActionResult Login()

        public ActionResult Acceso()
        {
            return View();
        }

       

        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        /*
        public ActionResult Enter(string user, string password)
        {


        }*/
        /// <summary>
        /// hasta aaqui----------------------------------------------------
        /// 
        /// 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>

            [HttpPost]
        public ActionResult RegistrarUsuario(EntUsuario Usuario)
        {
            bool insertar = LogUsuario.Instancia.RegistrarUsuario(Usuario);
            EntMensaje Mensaje = new EntMensaje();

            ViewData["Mensaje"] = Mensaje.mensaje;
            

            try
            {
                if (insertar && Usuario.Clave == Usuario.ConfirmarClave)
                {
                    return RedirectToAction("ListarCliente");
                }
                if (Mensaje.registrado)
                {
                    return RedirectToAction("Login", "Acceso");
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
    }
}